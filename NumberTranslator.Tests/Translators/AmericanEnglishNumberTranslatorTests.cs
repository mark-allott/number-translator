using FluentAssertions;
using NumberTranslator.Translators;

namespace NumberTranslator.Tests.Translators;

[TestClass]
public class AmericanEnglishNumberTranslatorTests
{
	private static readonly AmericanEnglishNumberTranslator DefaultTranslator = new(true, 5, true, -9999.0d, 9999.0d);

	[TestMethod]
	public void DefaultTranslatorHasExpectedDefaults()
	{
		DefaultTranslator.LanguageCodeId.Should().Be("en-US");
		DefaultTranslator.LanguageName.Should().Be("English (United States)");
		DefaultTranslator.AllowCurrency.Should().Be(true);
		DefaultTranslator.AllowDecimals.Should().Be(true);
		DefaultTranslator.DecimalPlaces.Should().Be(2);
		DefaultTranslator.MinimumValue.Should().Be(-9999.0d);
		DefaultTranslator.MaximumValue.Should().Be(9999.0d);
		DefaultTranslator.CurrencyIntegralPartSingularName.Should().Be("dollar");
		DefaultTranslator.CurrencyIntegralPartPluralName.Should().Be("dollars");
		DefaultTranslator.CurrencyFractionalPartSingularName.Should().Be("cent");
		DefaultTranslator.CurrencyFractionalPartPluralName.Should().Be("cents");
	}

	[TestMethod]
	[DataRow(1.0d, "one dollar")]
	[DataRow(1.1d, "one dollar and ten cents")]
	[DataRow(1.12d, "one dollar and twelve cents")]
	[DataRow(1.123d, "one dollar and twelve cents")]
	[DataRow(1.1234d, "one dollar and twelve cents")]
	[DataRow(1.12345d, "one dollar and twelve cents")]
	//	Verify rounding of values to decimal places works as intended
	[DataRow(1.124d, "one dollar and twelve cents")]
	[DataRow(1.125d, "one dollar and thirteen cents")]
	[DataRow(1.126d, "one dollar and thirteen cents")]
	//	Verify zero is not truncated if numbers are present afterwards
	[DataRow(0.1d, "zero dollars and ten cents")]
	[DataRow(0.01d, "zero dollars and one cent")]
	[DataRow(0.001d, "zero dollars")]
	//	Check some negatives
	[DataRow(-1, "negative one dollar")]
	[DataRow(-2, "negative two dollars")]
	[DataRow(-10, "negative ten dollars")]
	[DataRow(-11, "negative eleven dollars")]
	[DataRow(-20, "negative twenty dollars")]
	[DataRow(-21, "negative twenty-one dollars")]
	[DataRow(-99, "negative ninety-nine dollars")]
	[DataRow(-100, "negative one hundred dollars")]
	public void DefaultTranslatorReturnsExpected(double value, string expected)
	{
		string actual = DefaultTranslator.Translate($"{value}");
		actual.Should().Be(expected);
	}
}