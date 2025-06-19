using FluentAssertions;
using NumberTranslator.Translators;

namespace NumberTranslator.Tests.Translators;

[TestClass]
public class BritishEnglishNumberTranslatorTests
{
	private static readonly BritishEnglishNumberTranslator DefaultTranslator = new(true, 5, true, -9999.0d, 9999.0d);

	[TestMethod]
	public void DefaultTranslatorHasExpectedDefaults()
	{
		DefaultTranslator.LanguageCodeId.Should().Be("en-GB");
		DefaultTranslator.LanguageName.Should().Be("English (United Kingdom)");
		DefaultTranslator.AllowCurrency.Should().Be(true);
		DefaultTranslator.AllowDecimals.Should().Be(true);
		DefaultTranslator.DecimalPlaces.Should().Be(2);
		DefaultTranslator.MinimumValue.Should().Be(-9999.0d);
		DefaultTranslator.MaximumValue.Should().Be(9999.0d);
		DefaultTranslator.CurrencyIntegralPartSingularName.Should().Be("pound");
		DefaultTranslator.CurrencyIntegralPartPluralName.Should().Be("pounds");
		DefaultTranslator.CurrencyFractionalPartSingularName.Should().Be("penny");
		DefaultTranslator.CurrencyFractionalPartPluralName.Should().Be("pence");
	}

	[TestMethod]
	[DataRow(1.0d, "one pound")]
	[DataRow(1.1d, "one pound and ten pence")]
	[DataRow(1.12d, "one pound and twelve pence")]
	[DataRow(1.123d, "one pound and twelve pence")]
	[DataRow(1.1234d, "one pound and twelve pence")]
	[DataRow(1.12345d, "one pound and twelve pence")]
	//	Verify rounding of values to decimal places works as intended
	[DataRow(1.124d, "one pound and twelve pence")]
	[DataRow(1.125d, "one pound and thirteen pence")]
	[DataRow(1.126d, "one pound and thirteen pence")]
	//	Verify zero is not truncated if numbers are present afterwards
	[DataRow(0.1d, "zero pounds and ten pence")]
	[DataRow(0.01d, "zero pounds and one penny")]
	[DataRow(0.001d, "zero pounds")]
	//	Check some negatives
	[DataRow(-1, "negative one pound")]
	[DataRow(-2, "negative two pounds")]
	[DataRow(-10, "negative ten pounds")]
	[DataRow(-11, "negative eleven pounds")]
	[DataRow(-20, "negative twenty pounds")]
	[DataRow(-21, "negative twenty-one pounds")]
	[DataRow(-99, "negative ninety-nine pounds")]
	[DataRow(-100, "negative one hundred pounds")]
	public void DefaultTranslatorReturnsExpected(double value, string expected)
	{
		string actual = DefaultTranslator.Translate($"{value}");
		actual.Should().Be(expected);
	}
}