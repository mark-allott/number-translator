using FluentAssertions;
using NumberTranslator.Translators.Languages;

namespace NumberTranslator.Tests.Translators;

[TestClass]
public class BritishEnglishNumberTranslatorTests
{
	private static readonly BritishEnglishNumberTranslator DefaultTitleCaseTranslator = new(true, 5, true, -9999.0d, 9999.0d, true);
	private static readonly BritishEnglishNumberTranslator DefaultLowerCaseTranslator = new(true, 5, true, -9999.0d, 9999.0d, false);

	[TestMethod]
	public void DefaultTranslatorHasExpectedDefaults()
	{
		DefaultLowerCaseTranslator.LanguageCodeId.Should().Be("en-GB");
		DefaultLowerCaseTranslator.LanguageName.Should().Be("English (United Kingdom)");
		DefaultLowerCaseTranslator.AllowCurrency.Should().Be(true);
		DefaultLowerCaseTranslator.AllowDecimals.Should().Be(true);
		DefaultLowerCaseTranslator.DecimalPlaces.Should().Be(2);
		DefaultLowerCaseTranslator.MinimumValue.Should().Be(-9999.0d);
		DefaultLowerCaseTranslator.MaximumValue.Should().Be(9999.0d);
		DefaultLowerCaseTranslator.CurrencyIntegralPartSingularName.Should().Be("pound");
		DefaultLowerCaseTranslator.CurrencyIntegralPartPluralName.Should().Be("pounds");
		DefaultLowerCaseTranslator.CurrencyFractionalPartSingularName.Should().Be("penny");
		DefaultLowerCaseTranslator.CurrencyFractionalPartPluralName.Should().Be("pence");
		DefaultLowerCaseTranslator.UseTitleCase.Should().Be(false);
		DefaultTitleCaseTranslator.UseTitleCase.Should().Be(true);
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
	//	Test to make sure rounding when using the Convert.ToInt64 routines is handled correctly
	[DataRow(1234.666, "one thousand, two hundred and thirty-four pounds and sixty-seven pence")]
	public void DefaultLowerCaseTranslatorReturnsExpected(double value, string expected)
	{
		string actual = DefaultLowerCaseTranslator.Translate($"{value}");
		actual.Should().Be(expected);
	}

	[TestMethod]
	[DataRow(1.0d, "One Pound")]
	[DataRow(1.1d, "One Pound and Ten Pence")]
	[DataRow(1.12d, "One Pound and Twelve Pence")]
	[DataRow(1.123d, "One Pound and Twelve Pence")]
	[DataRow(1.1234d, "One Pound and Twelve Pence")]
	[DataRow(1.12345d, "One Pound and Twelve Pence")]
	//	Verify rounding of values to decimal places works as intended
	[DataRow(1.124d, "One Pound and Twelve Pence")]
	[DataRow(1.125d, "One Pound and Thirteen Pence")]
	[DataRow(1.126d, "One Pound and Thirteen Pence")]
	//	Verify zero is not truncated if numbers are present afterwards
	[DataRow(0.1d, "Zero Pounds and Ten Pence")]
	[DataRow(0.01d, "Zero Pounds and One Penny")]
	[DataRow(0.001d, "Zero Pounds")]
	//	Check some negatives
	[DataRow(-1, "Negative One Pound")]
	[DataRow(-2, "Negative Two Pounds")]
	[DataRow(-10, "Negative Ten Pounds")]
	[DataRow(-11, "Negative Eleven Pounds")]
	[DataRow(-20, "Negative Twenty Pounds")]
	[DataRow(-21, "Negative Twenty-One Pounds")]
	[DataRow(-99, "Negative Ninety-Nine Pounds")]
	[DataRow(-100, "Negative One Hundred Pounds")]
	public void DefaultTitleCaseTranslatorReturnsExpected(double value, string expected)
	{
		string actual = DefaultTitleCaseTranslator.Translate($"{value}");
		actual.Should().Be(expected);
	}
}