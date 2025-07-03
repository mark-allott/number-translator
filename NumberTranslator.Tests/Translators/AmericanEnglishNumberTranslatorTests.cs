using FluentAssertions;
using NumberTranslator.Translators.Languages;

namespace NumberTranslator.Tests.Translators;

[TestClass]
public class AmericanEnglishNumberTranslatorTests
{
	private static readonly AmericanEnglishNumberTranslator DefaultTitleCaseTranslator = new(true, 5, true, -9999.0d, 9999.0d, true);
	private static readonly AmericanEnglishNumberTranslator DefaultLowerCaseTranslator = new(true, 5, true, -9999.0d, 9999.0d, false);

	[TestMethod]
	public void DefaultTranslatorHasExpectedDefaults()
	{
		DefaultLowerCaseTranslator.LanguageCodeId.Should().Be("en-US");
		DefaultLowerCaseTranslator.LanguageName.Should().Be("English (United States)");
		DefaultLowerCaseTranslator.AllowCurrency.Should().Be(true);
		DefaultLowerCaseTranslator.AllowDecimals.Should().Be(true);
		DefaultLowerCaseTranslator.DecimalPlaces.Should().Be(2);
		DefaultLowerCaseTranslator.MinimumValue.Should().Be(-9999.0d);
		DefaultLowerCaseTranslator.MaximumValue.Should().Be(9999.0d);
		DefaultLowerCaseTranslator.CurrencyIntegralPartSingularName.Should().Be("dollar");
		DefaultLowerCaseTranslator.CurrencyIntegralPartPluralName.Should().Be("dollars");
		DefaultLowerCaseTranslator.CurrencyFractionalPartSingularName.Should().Be("cent");
		DefaultLowerCaseTranslator.CurrencyFractionalPartPluralName.Should().Be("cents");
		DefaultLowerCaseTranslator.UseTitleCase.Should().Be(false);
		DefaultTitleCaseTranslator.UseTitleCase.Should().Be(true);
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
	public void DefaultLowerCaseTranslatorReturnsExpected(double value, string expected)
	{
		string actual = DefaultLowerCaseTranslator.Translate($"{value}");
		actual.Should().Be(expected);
	}

	[TestMethod]
	[DataRow(1.0d, "One Dollar")]
	[DataRow(1.1d, "One Dollar and Ten Cents")]
	[DataRow(1.12d, "One Dollar and Twelve Cents")]
	[DataRow(1.123d, "One Dollar and Twelve Cents")]
	[DataRow(1.1234d, "One Dollar and Twelve Cents")]
	[DataRow(1.12345d, "One Dollar and Twelve Cents")]
	//	Verify rounding of values to decimal places works as intended
	[DataRow(1.124d, "One Dollar and Twelve Cents")]
	[DataRow(1.125d, "One Dollar and Thirteen Cents")]
	[DataRow(1.126d, "One Dollar and Thirteen Cents")]
	//	Verify zero is not truncated if numbers are present afterwards
	[DataRow(0.1d, "Zero Dollars and Ten Cents")]
	[DataRow(0.01d, "Zero Dollars and One Cent")]
	[DataRow(0.001d, "Zero Dollars")]
	//	Check some negatives
	[DataRow(-1, "Negative One Dollar")]
	[DataRow(-2, "Negative Two Dollars")]
	[DataRow(-10, "Negative Ten Dollars")]
	[DataRow(-11, "Negative Eleven Dollars")]
	[DataRow(-20, "Negative Twenty Dollars")]
	[DataRow(-21, "Negative Twenty-One Dollars")]
	[DataRow(-99, "Negative Ninety-Nine Dollars")]
	[DataRow(-100, "Negative One Hundred Dollars")]
	public void DefaultTitleCaseTranslatorReturnsExpected(double value, string expected)
	{
		string actual = DefaultTitleCaseTranslator.Translate($"{value}");
		actual.Should().Be(expected);
	}
}