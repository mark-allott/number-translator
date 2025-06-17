namespace NumberTranslator.Translators;

public class EnglishNumberTranslator
	: NumberTranslator
{
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
		: base("en", allowDecimals, decimalPlaces, allowCurrency, minimumValue, maximumValue)
	{
	}

	#endregion Ctor

	#region NumberTranslator overloads

	/// <summary>
	/// Handles the conversion of <param name="text"></param> into the british word-form equivalent
	/// </summary>
	/// <param name="text">The text to convert (which will have been pre-sanitised</param>
	/// <returns>The word form for the digits provided</returns>
	/// <exception cref="System.NotImplementedException"></exception>
	protected override string DoTranslation(string text)
	{
		throw new System.NotImplementedException();
	}

	#endregion NumberTranslator overloads
}