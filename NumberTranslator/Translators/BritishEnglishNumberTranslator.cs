namespace NumberTranslator.Translators;

public class BritishEnglishNumberTranslator
	: EnglishNumberTranslator
{
	#region Ctor

	public BritishEnglishNumberTranslator()
		: this(false, 0, false, 0.0d, 9999.0d)
	{
	}

	public BritishEnglishNumberTranslator(bool allowDecimals, int decimalPlaces, bool allowCurrency, double minimumValue, double maximumValue)
		: base("en-gb", allowDecimals, decimalPlaces, allowCurrency, minimumValue, maximumValue)
	{
		CurrencyIntegerName = "pound";
		CurrencyFractionalName = "pence";
	}

	#endregion Ctor
}