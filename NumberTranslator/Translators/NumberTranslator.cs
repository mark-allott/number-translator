using System;
using System.Globalization;
using NumberTranslator.Interfaces;

namespace NumberTranslator.Translators;

public abstract class NumberTranslator
	: INumberTranslator, IAutoRegister
{
	#region Fields

	/// <summary>
	/// An instance of the <see cref="CultureInfo"/> object the translator was initialised with
	/// </summary>
	protected CultureInfo Culture { get; }

	/// <summary>
	/// An instance of a currency naming strategy used to put names to currency units
	/// </summary>
	protected ICurrencyNamingStrategy CurrencyNamingStrategy { get; }

	#endregion Fields

	#region Ctor

	/// <summary>
	/// Default constructor, allowing specification of culture, decimal provision, inclusion of
	/// currency as well as min/max values
	/// </summary>
	/// <param name="languageCode">The language code for the culture</param>
	/// <param name="allowDecimals">Specifies whether the translation allows decimals</param>
	/// <param name="decimalPlaces">Specifies the number of decimal places to report (if permitted)</param>
	/// <param name="allowCurrency">Specifies whether the translation should include currency</param>
	/// <param name="minimumValue">The minimum value permitted for the translator</param>
	/// <param name="maximumValue">The maximum value permitted for the translator</param>
	/// <param name="currencyNamingStrategy">The strategy used to define currency unit naming</param>
	protected NumberTranslator(string languageCode, bool allowDecimals, int decimalPlaces, bool allowCurrency,
		double minimumValue, double maximumValue, ICurrencyNamingStrategy currencyNamingStrategy)
	{
		//	Attempt to initialise a culture with the passed parameter
		//	If it does not work, we won't proceed with it
		Culture = new CultureInfo(languageCode);

		//	Store property values
		AllowDecimals = allowDecimals;
		AllowCurrency = allowCurrency;
		CurrencyNamingStrategy = currencyNamingStrategy;
		//	Decimal places are one of:
		//		Zero - allowDecimals is false
		//		The value of decimalPlaces if currency is not being used
		//		The number of places reported by the Culture's NumberFormat information
		DecimalPlaces = allowDecimals
			? allowCurrency
				? Culture.NumberFormat.CurrencyDecimalDigits
				: decimalPlaces
			: 0;
		//	Ensure min/max are the correct way around and also adhere to declared decimal place precision
		MinimumValue = Math.Round(Math.Min(minimumValue, maximumValue), DecimalPlaces);
		MaximumValue = Math.Round(Math.Max(minimumValue, maximumValue), DecimalPlaces);

		var absMax = Math.Max(Math.Abs(MinimumValue), Math.Abs(MaximumValue));
		if (absMax > long.MaxValue)
			throw new ArgumentOutOfRangeException(absMax == Math.Abs(MaximumValue)
				? nameof(maximumValue)
				: nameof(minimumValue), "Number exceeds precision capability");
	}

	#endregion Ctor

	#region ITranslator implementation

	/// <inheritdoc />
	public string Translate(string text)
	{
		text = ValidateAndSanitise(text);
		return DoTranslation(text);
	}

	/// <inheritdoc />
	public string LanguageCodeId
	{
		get
		{
			return Culture.Name;
		}
	}

	/// <inheritdoc />
	public string LanguageName
	{
		get
		{
			return Culture.DisplayName;
		}
	}

	#endregion ITranslator implementation

	#region INumberTranslator implementation

	/// <inheritdoc />
	public bool AllowDecimals { get; }

	/// <inheritdoc />
	public int DecimalPlaces { get; }

	/// <inheritdoc />
	public bool AllowCurrency { get; }

	/// <inheritdoc />
	public double MinimumValue { get; }

	/// <inheritdoc />
	public double MaximumValue { get; }

	#endregion INumberTranslator implementation

	#region Overrides from base classes

	/// <summary>
	/// Override base hashcode calculation to use properties of this class which can be used to
	/// determine uniqueness
	/// </summary>
	/// <returns>The new hashcode</returns>
	public override int GetHashCode()
	{
		return HashCode.Combine(LanguageCodeId, AllowCurrency, AllowDecimals, DecimalPlaces, MinimumValue,
			MaximumValue);
	}

	#endregion Overrides from base classes

	#region Methods

	/// <summary>
	/// Validates and sanitises the input <paramref name="text"/> to the translator ensuring the input matches the requirements
	/// </summary>
	/// <param name="text">The text input to be validated</param>
	/// <returns>The sanitised version of the text</returns>
	/// <exception cref="ArgumentNullException"></exception>
	private string ValidateAndSanitise(string text)
	{
		//	Nothing present is an error
		if (string.IsNullOrWhiteSpace(text))
			throw new ArgumentNullException(nameof(text));

		//	Tidy the input text, removing expected currency symbols if permitted
		var input = (AllowCurrency && !Culture.IsNeutralCulture
			? text.Replace(Culture.NumberFormat.CurrencySymbol, "")
			: text).Trim();

		//	Extract the value from
		var value = GetValue(input, true);

		if (!AllowDecimals && Math.Abs(Math.Floor(value) - Math.Ceiling(value)) > 0)
			throw new ArgumentOutOfRangeException(nameof(text), value, "Decimal parts are not permitted");

		//	Perform rounding on the input text value to the correct number of places
		value = Math.Round(value, DecimalPlaces, AllowCurrency ? MidpointRounding.AwayFromZero : MidpointRounding.ToEven);

		//	Bounds check
		if (value < MinimumValue || value > MaximumValue)
			throw new ArgumentOutOfRangeException(nameof(text), value, $"Value for translation must be between {MinimumValue} and {MaximumValue}");

		return $"{value}";
	}

	/// <summary>
	/// Performs the translation of the numeric value into textual form
	/// </summary>
	/// <param name="text">The digits to convert to word form</param>
	/// <returns>The word form for <param name="text"></param></returns>
	/// <exception cref="System.NotImplementedException"></exception>
	protected virtual string DoTranslation(string text)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Performs conversion of the <paramref name="input"></paramref> to a double
	/// </summary>
	/// <param name="input">The text to convert</param>
	/// <param name="isValidating">A flag to indicate whether validation is being performed</param>
	/// <returns>The <paramref name="input"></paramref> as a double</returns>
	/// <exception cref="ArgumentException"></exception>
	/// <remarks>
	/// If <paramref name="isValidating"></paramref> is true, then the raw value is returned; if false,
	/// rounding is performed to the required number of decimal places
	/// </remarks>
	protected double GetValue(string input, bool isValidating = false)
	{
		//	If the value does not parse to a number, it's a junk string
		if (!double.TryParse(input, out var value))
			throw new ArgumentException($"The value '{input}' is not a valid number", nameof(input));

		return isValidating
			? value
			: Math.Round(value, DecimalPlaces);
	}

	#endregion Methods
}