using NumberTranslator.Strategies;

namespace NumberTranslator.Translators;

public class AmericanEnglishNumberTranslator
	: EnglishNumberTranslator
{
	#region Ctor

	public AmericanEnglishNumberTranslator()
		: this(false, 0, false, 0.0d, 9999.0d)
	{
	}

	public AmericanEnglishNumberTranslator(bool allowDecimals, int decimalPlaces, bool allowCurrency, double minimumValue, double maximumValue)
		: base("en-us", allowDecimals, decimalPlaces, allowCurrency, minimumValue, maximumValue, new AmericanCurrencyNamingStrategy())
	{
	}

	#endregion Ctor
}