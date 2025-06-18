using System;
using System.Linq;
using System.Text;
using NumberTranslator.Interfaces;
using NumberTranslator.Strategies;

namespace NumberTranslator.Translators;

public class EnglishNumberTranslator
	: NumberTranslator
{
	#region Fields

	private static readonly string[] UnderTwenty = new[]
	{
		"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve",
		"thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
	};

	private static readonly string[] Decadal = new[]
	{
		"", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
	};

	/// <summary>
	/// Holds names for number groupings from 10^3 to 10^18 (double maxes out at ~1.8x10^308), but
	/// precision is only approx. 17 digits. Naming system retrieved from https://simple.wikipedia.org/wiki/Names_of_large_numbers#Names_for_large_numbers
	/// </summary>
	private static readonly string[] NumberGroupName = new[]
	{
		"",
		"thousand",		//	10^3
		"million",		//	10^6
		"billion",		//	10^9
		"trillion",		//	10^12
		"quadrillion",	//	10^15
		"quintillion",	//	10^18
	};

	#endregion Fields

	#region Properties

	/// <summary>
	/// Returns the singular name for the currency unit
	/// </summary>
	public string CurrencyIntegralPartSingularName
	{
		get
		{
			return base.CurrencyNamingStrategy.CurrencyIntegralPartName(1);
		}
	}

	/// <summary>
	/// Returns the plural name for the currency unit
	/// </summary>
	public string CurrencyIntegralPartPluralName
	{
		get
		{
			return base.CurrencyNamingStrategy.CurrencyIntegralPartName(2);
		}
	}

	/// <summary>
	/// Returns the singular name for the fractional currency unit
	/// </summary>
	public string CurrencyFractionalPartSingularName
	{
		get
		{
			return base.CurrencyNamingStrategy.CurrencyFractionalPartName(1);
		}
	}

	/// <summary>
	/// Returns the plural name for the fractional currency unit
	/// </summary>
	public string CurrencyFractionalPartPluralName
	{
		get
		{
			return base.CurrencyNamingStrategy.CurrencyFractionalPartName(2);
		}
	}

	#endregion Properties

	#region Ctor

	/// <summary>
	/// Default constructor
	/// </summary>
	public EnglishNumberTranslator()
		: this(false, 0, false, 0.0d, 9999.0d)
	{
	}

	/// <summary>
	/// Alternate constructor which allows specification of decimal, currency and min/max values
	/// </summary>
	/// <param name="allowDecimals">Specifies whether the translation allows decimals</param>
	/// <param name="decimalPlaces">Specifies the number of decimal places to report (if permitted)</param>
	/// <param name="allowCurrency">Specifies whether the translation should include currency</param>
	/// <param name="minimumValue">The minimum value permitted for the translator</param>
	/// <param name="maximumValue">The maximum value permitted for the translator</param>
	public EnglishNumberTranslator(bool allowDecimals, int decimalPlaces, bool allowCurrency, double minimumValue, double maximumValue)
		: this("en", allowDecimals, decimalPlaces, allowCurrency, minimumValue, maximumValue, new DefaultCurrencyNamingStrategy())
	{
	}

	/// <summary>
	/// Alternate constructor for use by subclasses which need to set the specific language code - e.g. en-gb or en-us, etc.
	/// </summary>
	/// <param name="languageCode">The language code for the culture</param>
	/// <param name="allowDecimals">Specifies whether the translation allows decimals</param>
	/// <param name="decimalPlaces">Specifies the number of decimal places to report (if permitted)</param>
	/// <param name="allowCurrency">Specifies whether the translation should include currency</param>
	/// <param name="minimumValue">The minimum value permitted for the translator</param>
	/// <param name="maximumValue">The maximum value permitted for the translator</param>
	/// <param name="currencyNamingStrategy">The naming strategy for currency units</param>
	protected EnglishNumberTranslator(string languageCode, bool allowDecimals, int decimalPlaces, bool allowCurrency,
		double minimumValue, double maximumValue, ICurrencyNamingStrategy currencyNamingStrategy)
		: base(languageCode, allowDecimals, decimalPlaces, allowCurrency, minimumValue, maximumValue, currencyNamingStrategy)
	{
	}

	#endregion Ctor

	#region NumberTranslator overloads

	/// <summary>
	/// Handles the conversion of <param name="text"></param> into the English word-form equivalent
	/// </summary>
	/// <param name="text">The text to convert (which will have been pre-sanitised beforehand)</param>
	/// <returns>The word form for the digits provided</returns>
	/// <exception cref="System.NotImplementedException"></exception>
	protected override string DoTranslation(string text)
	{
		//	Convert text to numeric value
		var value = GetValue(text);
		//	Determine if negative
		var isNegative = Math.Sign(value) == -1;
		//	Convert to absolute value
		value = Math.Abs(value);
		//	Extract integer portion of value
		var integerPart = Convert.ToInt64(value);
		//	Extract fractional part of value and convert to integer equivalent
		var fractionalPart = Convert.ToInt64(Math.Pow(10, DecimalPlaces) * (value % 1));

		var sb = new StringBuilder();

		//	If negative, prepend everything with the "negative" word
		if (isNegative)
			sb.Append("negative ");

		//	Add grouped textual values
		sb.Append(ConvertToGroupedText(integerPart));

		//	If currency is being reported, add the whole unit word
		if (AllowCurrency && !string.IsNullOrWhiteSpace(CurrencyIntegralPartSingularName))
			sb.Append($" {CurrencyNamingStrategy.CurrencyIntegralPartName(integerPart)}");

		//	If decimals are permitted, add any fractional parts (if present)
		if (AllowDecimals && fractionalPart > 0)
		{
			//	If using currency, report the two-digit value and the fractional currency unit name
			if (AllowCurrency)
				sb.Append(" and ")
					.Append(ConvertTwoDigit(fractionalPart))
					.Append(string.IsNullOrWhiteSpace(CurrencyFractionalPartSingularName) ? "" : $" {CurrencyNamingStrategy.CurrencyFractionalPartName(fractionalPart)}");
			else
			{
				// non-currency fractional parts are listed as single digit words separated by spaces - e.g.
				// the fractional part of PI to 3 places would be "point one four one"
				var digits = $"{fractionalPart.ToString(new string('0', DecimalPlaces))}".ToCharArray()
					.Select(s => int.Parse($"{s}"))
					.Select(i => ConvertTwoDigit(i))
					//	Reverse the order so checking of trailing zero can be performed
					.Reverse()
					.ToList();
				//	Remove all trailing zero values as these should not be reported
				while (digits[0] == UnderTwenty[0])
					digits = digits[1..];
				//	Put digits back into correct order
				digits.Reverse();
				//	Append the digits of interest
				sb.Append(" point ")
					.Append(string.Join(" ", digits));
			}
		}

		return sb.ToString();
	}

	#endregion NumberTranslator overloads

	#region Methods

	/// <summary>
	/// Converts the <paramref name="value"/> supplied into word form for a two-digit number
	/// </summary>
	/// <param name="value">The number to translate to words in the range 0-99</param>
	/// <returns>The word form for <paramref name="value"/></returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	private string ConvertTwoDigit(long value)
	{
		if (value > 99)
			throw new ArgumentOutOfRangeException(nameof(value), value, "Exceeds two-digit value");

		if (value < 20)
			return UnderTwenty[value];

		var tens = Math.DivRem(value, 10, out var units);
		return units > 0
			? $"{Decadal[tens]}-{UnderTwenty[units]}"
			: $"{Decadal[tens]}";
	}

	/// <summary>
	/// Converts the <paramref name="value"/> supplied into word form for a three-digit number.
	/// Checks are made to verify whether a series of words should be emitted - e.g. a zero value should not return anything as it should have been handled elsewhere
	/// </summary>
	/// <param name="value">The number to translate to words in the range 0-99</param>
	/// <returns>The word form for <paramref name="value"/></returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	private string ConvertThreeDigit(long value)
	{
		if (value > 999)
			throw new ArgumentOutOfRangeException(nameof(value), value, "Exceeds three-digit value");

		if (value == 0)
			return "";

		var sb = new StringBuilder();
		var hundreds = Math.DivRem(value, 100, out var twoDigits);
		if (hundreds > 0)
		{
			sb.Append(UnderTwenty[hundreds])
				.Append(" hundred");
			if (twoDigits > 0)
				sb.Append(" and ");
		}

		if (twoDigits > 0)
			sb.Append(ConvertTwoDigit(twoDigits));
		return sb.ToString();
	}

	private string ConvertToGroupedText(long value)
	{
		if (value < 100)
			return ConvertTwoDigit(value);

		if (value < 1000)
			return ConvertThreeDigit(value);

		var sb = new StringBuilder();
		for (var i = NumberGroupName.Length - 1; i >= 0; i--)
		{
			var p = Convert.ToInt64(Math.Pow(1000, i));

			var v = Math.DivRem(value, p, out var remainder);
			if (v > 0)
				sb.Append(ConvertThreeDigit(v))
					.Append(i > 0 ? $" {NumberGroupName[i]}" : "")
					.Append(remainder switch { 0 => "", < 100 => " and ", _ => ", " });
			value = remainder;
		}

		return sb.ToString();
	}

	#endregion Methods
}