using NumberTranslator.Strategies;

namespace NumberTranslator.Translators.Languages;

public class BritishEnglishNumberTranslator
	: EnglishNumberTranslator
{
	#region Ctor

	public BritishEnglishNumberTranslator()
		: this(false, 0, false, 0.0d, 9999.0d, true)
	{
	}

	public BritishEnglishNumberTranslator(bool allowDecimals, int decimalPlaces, bool allowCurrency,
		double minimumValue, double maximumValue, bool useTitleCase)
		: base("en-gb", allowDecimals, decimalPlaces, allowCurrency, minimumValue, maximumValue, useTitleCase,
			new BritishCurrencyNamingStrategy(), new EnglishNumberConcatenationStrategy())
	{
	}

	#endregion Ctor
}