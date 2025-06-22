using System.Globalization;
using FluentAssertions;
using NumberTranslator.Translators;

namespace NumberTranslator.Tests.Translators;

[TestClass]
public class EnglishNumberTranslatorTests
{
	private static readonly EnglishNumberTranslator DefaultTranslator = new();
	private static readonly EnglishNumberTranslator DefaultTranslatorWithNegatives = new(false, 0, false, -9999.0d, 9999.0d, true);
	private static readonly EnglishNumberTranslator DefaultTranslatorWithDecimalPlaces = new(true, 5, false, 0.0d, 9999.0d, true);
	private static readonly EnglishNumberTranslator DefaultTranslatorWithCurrencyAndNegatives = new(true, 5, true, -9999.0d, 9999.0d, true);
	private static readonly EnglishNumberTranslator LowerCaseTranslatorWithNegatives = new(false, 0, false, -9999.0d, 9999.0d, false);
	private static readonly EnglishNumberTranslator LowerCaseTranslatorWithDecimalPlaces = new(true, 5, false, 0.0d, 9999.0d, false);
	private static readonly EnglishNumberTranslator LowerCaseTranslatorWithCurrencyAndNegatives = new(true, 5, true, -9999.0d, 9999.0d, false);

	#region Test defaults

	[TestMethod]
	public void DefaultTranslatorHasExpectedDefaults()
	{
		DefaultTranslator.LanguageCodeId.Should().Be("en");
		DefaultTranslator.LanguageName.Should().Be("English");
		DefaultTranslator.AllowCurrency.Should().Be(false);
		DefaultTranslator.AllowDecimals.Should().Be(false);
		DefaultTranslator.DecimalPlaces.Should().Be(0);
		DefaultTranslator.MinimumValue.Should().Be(0.0d);
		DefaultTranslator.MaximumValue.Should().Be(9999.0d);
		DefaultTranslator.CurrencyIntegralPartSingularName.Should().Be("");
		DefaultTranslator.CurrencyIntegralPartPluralName.Should().Be("");
		DefaultTranslator.CurrencyFractionalPartSingularName.Should().Be("");
		DefaultTranslator.CurrencyFractionalPartPluralName.Should().Be("");
		DefaultTranslator.UseTitleCase.Should().Be(true);
	}

	[TestMethod]
	[DataRow(int.MinValue)]
	[DataRow(-10000)]
	[DataRow(-1)]
	[DataRow(10000)]
	[DataRow(int.MaxValue)]
	[DataRow(1.1d)]
	public void DefaultTranslatorThrowsExpectedExceptions(double value)
	{
		Assert.Throws<ArgumentOutOfRangeException>(() => DefaultTranslator.Translate($"{value}"));
	}

	[TestMethod]
	[DataRow(0, "Zero")]
	[DataRow(1, "One")]
	[DataRow(2, "Two")]
	[DataRow(10, "Ten")]
	[DataRow(20, "Twenty")]
	[DataRow(21, "Twenty-One")]
	[DataRow(99, "Ninety-Nine")]
	[DataRow(100, "One Hundred")]
	[DataRow(101, "One Hundred and One")]
	[DataRow(121, "One Hundred and Twenty-One")]
	[DataRow(999, "Nine Hundred and Ninety-Nine")]
	[DataRow(1000, "One Thousand")]
	[DataRow(1001, "One Thousand and One")]
	[DataRow(1100, "One Thousand, One Hundred")]
	[DataRow(1101, "One Thousand, One Hundred and One")]
	[DataRow(9999, "Nine Thousand, Nine Hundred and Ninety-Nine")]
	public void DefaultTranslatorReturnsExpected(int value, string expected)
	{
		string actual = DefaultTranslator.Translate($"{value}");
		actual.Should().Be(expected);
	}

	#endregion Test defaults

	#region Test specific translation settings

	[TestMethod]
	public void DefaultTranslatorWithNegativesHasExpectedDefaults()
	{
		DefaultTranslatorWithNegatives.LanguageCodeId.Should().Be("en");
		DefaultTranslatorWithNegatives.LanguageName.Should().Be("English");
		DefaultTranslatorWithNegatives.AllowCurrency.Should().Be(false);
		DefaultTranslatorWithNegatives.AllowDecimals.Should().Be(false);
		DefaultTranslatorWithNegatives.DecimalPlaces.Should().Be(0);
		DefaultTranslatorWithNegatives.MinimumValue.Should().Be(-9999.0d);
		DefaultTranslatorWithNegatives.MaximumValue.Should().Be(9999.0d);
		DefaultTranslatorWithNegatives.CurrencyIntegralPartSingularName.Should().Be("");
		DefaultTranslatorWithNegatives.CurrencyIntegralPartPluralName.Should().Be("");
		DefaultTranslatorWithNegatives.CurrencyFractionalPartSingularName.Should().Be("");
		DefaultTranslatorWithNegatives.CurrencyFractionalPartPluralName.Should().Be("");
	}

	[TestMethod]
	[DataRow(int.MinValue)]
	[DataRow(-10000)]
	[DataRow(10000)]
	[DataRow(int.MaxValue)]
	public void DefaultTranslatorWithNegativesThrowsExpectedExceptions(int value)
	{
		Assert.Throws<ArgumentOutOfRangeException>(() => DefaultTranslatorWithNegatives.Translate($"{value}"));
	}

	[TestMethod]
	[DataRow(0, "Zero")]
	[DataRow(1, "One")]
	[DataRow(2, "Two")]
	[DataRow(10, "Ten")]
	[DataRow(20, "Twenty")]
	[DataRow(21, "Twenty-One")]
	[DataRow(99, "Ninety-Nine")]
	[DataRow(100, "One Hundred")]
	[DataRow(101, "One Hundred and One")]
	[DataRow(121, "One Hundred and Twenty-One")]
	[DataRow(999, "Nine Hundred and Ninety-Nine")]
	[DataRow(1000, "One Thousand")]
	[DataRow(1001, "One Thousand and One")]
	[DataRow(1100, "One Thousand, One Hundred")]
	[DataRow(1101, "One Thousand, One Hundred and One")]
	[DataRow(9999, "Nine Thousand, Nine Hundred and Ninety-Nine")]
	[DataRow(-1, "Negative One")]
	[DataRow(-2, "Negative Two")]
	[DataRow(-10, "Negative Ten")]
	[DataRow(-20, "Negative Twenty")]
	[DataRow(-21, "Negative Twenty-One")]
	[DataRow(-99, "Negative Ninety-Nine")]
	[DataRow(-100, "Negative One Hundred")]
	[DataRow(-101, "Negative One Hundred and One")]
	[DataRow(-121, "Negative One Hundred and Twenty-One")]
	[DataRow(-999, "Negative Nine Hundred and Ninety-Nine")]
	[DataRow(-1000, "Negative One Thousand")]
	[DataRow(-1001, "Negative One Thousand and One")]
	[DataRow(-1100, "Negative One Thousand, One Hundred")]
	[DataRow(-1101, "Negative One Thousand, One Hundred and One")]
	[DataRow(-9999, "Negative Nine Thousand, Nine Hundred and Ninety-Nine")]
	public void DefaultTranslatorWithNegativesReturnsExpected(int value, string expected)
	{
		string actual = DefaultTranslatorWithNegatives.Translate($"{value}");
		actual.Should().Be(expected);
	}

	[TestMethod]
	public void DefaultTranslatorWithDecimalPlacesHasExpectedDefaults()
	{
		DefaultTranslatorWithDecimalPlaces.LanguageCodeId.Should().Be("en");
		DefaultTranslatorWithDecimalPlaces.LanguageName.Should().Be("English");
		DefaultTranslatorWithDecimalPlaces.AllowCurrency.Should().Be(false);
		DefaultTranslatorWithDecimalPlaces.AllowDecimals.Should().Be(true);
		DefaultTranslatorWithDecimalPlaces.DecimalPlaces.Should().Be(5);
		DefaultTranslatorWithDecimalPlaces.MinimumValue.Should().Be(0.0d);
		DefaultTranslatorWithDecimalPlaces.MaximumValue.Should().Be(9999.0d);
		DefaultTranslatorWithDecimalPlaces.CurrencyIntegralPartSingularName.Should().Be("");
		DefaultTranslatorWithDecimalPlaces.CurrencyIntegralPartPluralName.Should().Be("");
		DefaultTranslatorWithDecimalPlaces.CurrencyFractionalPartSingularName.Should().Be("");
		DefaultTranslatorWithDecimalPlaces.CurrencyFractionalPartPluralName.Should().Be("");
	}

	[TestMethod]
	[DataRow(int.MinValue)]
	[DataRow(-10000)]
	[DataRow(-1)]
	[DataRow(10000)]
	[DataRow(int.MaxValue)]
	public void DefaultTranslatorWithDecimalPlacesThrowsExpectedExceptions(int value)
	{
		Assert.Throws<ArgumentOutOfRangeException>(() => DefaultTranslatorWithDecimalPlaces.Translate($"{value}"));
	}

	[TestMethod]
	[DataRow(1.0d, "One")]
	[DataRow(1.1d, "One point One")]
	[DataRow(1.12d, "One point One Two")]
	[DataRow(1.123d, "One point One Two Three")]
	[DataRow(1.1234d, "One point One Two Three Four")]
	[DataRow(1.12345d, "One point One Two Three Four Five")]
	//	Verify rounding of values to decimal places works as intended
	[DataRow(1.123454d, "One point One Two Three Four Five")]
	[DataRow(1.123455d, "One point One Two Three Four Six")]
	[DataRow(1.123456d, "One point One Two Three Four Six")]
	//	Verify zero is not truncated if numbers are present afterwards
	[DataRow(0.1d, "Zero point One")]
	[DataRow(0.01d, "Zero point Zero One")]
	[DataRow(0.001d, "Zero point Zero Zero One")]
	[DataRow(0.0001d, "Zero point Zero Zero Zero One")]
	[DataRow(0.00001d, "Zero point Zero Zero Zero Zero One")]
	[DataRow(0.000001d, "Zero")]
	[DataRow(0.000005d, "Zero")]
	[DataRow(0.000006d, "Zero point Zero Zero Zero Zero One")]
	public void DefaultTranslatorWithDecimalPlacesReturnsExpected(double value, string expected)
	{
		string actual = DefaultTranslatorWithDecimalPlaces.Translate($"{value}");
		actual.Should().Be(expected);
	}

	[TestMethod]
	public void DefaultTranslatorWithCurrencyAndNegativesHasExpectedDefaults()
	{
		DefaultTranslatorWithCurrencyAndNegatives.LanguageCodeId.Should().Be("en");

		CultureInfo ci = new CultureInfo(DefaultTranslatorWithCurrencyAndNegatives.LanguageCodeId);

		DefaultTranslatorWithCurrencyAndNegatives.LanguageName.Should().Be("English");
		DefaultTranslatorWithCurrencyAndNegatives.AllowCurrency.Should().Be(true);
		DefaultTranslatorWithCurrencyAndNegatives.AllowDecimals.Should().Be(true);
		DefaultTranslatorWithCurrencyAndNegatives.DecimalPlaces.Should().Be(ci.NumberFormat.CurrencyDecimalDigits);
		DefaultTranslatorWithCurrencyAndNegatives.MinimumValue.Should().Be(-9999.0d);
		DefaultTranslatorWithCurrencyAndNegatives.MaximumValue.Should().Be(9999.0d);
		DefaultTranslatorWithCurrencyAndNegatives.CurrencyIntegralPartSingularName.Should().Be("");
		DefaultTranslatorWithCurrencyAndNegatives.CurrencyIntegralPartPluralName.Should().Be("");
		DefaultTranslatorWithCurrencyAndNegatives.CurrencyFractionalPartSingularName.Should().Be("");
		DefaultTranslatorWithCurrencyAndNegatives.CurrencyFractionalPartPluralName.Should().Be("");
	}

	[TestMethod]
	[DataRow(1.0d, "One")]
	[DataRow(1.1d, "One and Ten")]
	[DataRow(1.12d, "One and Twelve")]
	[DataRow(1.123d, "One and Twelve")]
	[DataRow(1.1234d, "One and Twelve")]
	[DataRow(1.12345d, "One and Twelve")]
	//	Verify rounding of values to decimal places works as intended
	[DataRow(1.124d, "One and Twelve")]
	[DataRow(1.125d, "One and Thirteen")]
	[DataRow(1.126d, "One and Thirteen")]
	//	Verify zero is not truncated if numbers are present afterwards
	[DataRow(0.1d, "Zero and Ten")]
	[DataRow(0.01d, "Zero and One")]
	[DataRow(0.001d, "Zero")]
	//	Check some negatives
	[DataRow(-1, "Negative One")]
	[DataRow(-2, "Negative Two")]
	[DataRow(-10, "Negative Ten")]
	[DataRow(-11, "Negative Eleven")]
	[DataRow(-20, "Negative Twenty")]
	[DataRow(-21, "Negative Twenty-One")]
	[DataRow(-99, "Negative Ninety-Nine")]
	[DataRow(-100, "Negative One Hundred")]
	public void DefaultTranslatorWithCurrencyAndNegativesReturnsExpected(double value, string expected)
	{
		string actual = DefaultTranslatorWithCurrencyAndNegatives.Translate($"{value}");
		actual.Should().Be(expected);
	}

	#endregion Test specific translation settings

	#region Test lower-case translations

	[TestMethod]
	public void LowerCaseTranslatorHasExpectedDefaults()
	{
		LowerCaseTranslatorWithNegatives.LanguageCodeId.Should().Be("en");
		LowerCaseTranslatorWithNegatives.LanguageName.Should().Be("English");
		LowerCaseTranslatorWithNegatives.AllowCurrency.Should().Be(false);
		LowerCaseTranslatorWithNegatives.AllowDecimals.Should().Be(false);
		LowerCaseTranslatorWithNegatives.DecimalPlaces.Should().Be(0);
		LowerCaseTranslatorWithNegatives.MinimumValue.Should().Be(-9999.0d);
		LowerCaseTranslatorWithNegatives.MaximumValue.Should().Be(9999.0d);
		LowerCaseTranslatorWithNegatives.CurrencyIntegralPartSingularName.Should().Be("");
		LowerCaseTranslatorWithNegatives.CurrencyIntegralPartPluralName.Should().Be("");
		LowerCaseTranslatorWithNegatives.CurrencyFractionalPartSingularName.Should().Be("");
		LowerCaseTranslatorWithNegatives.CurrencyFractionalPartPluralName.Should().Be("");
		LowerCaseTranslatorWithNegatives.UseTitleCase.Should().Be(false);
	}

	[TestMethod]
	[DataRow(0, "zero")]
	[DataRow(1, "one")]
	[DataRow(2, "two")]
	[DataRow(10, "ten")]
	[DataRow(20, "twenty")]
	[DataRow(21, "twenty-one")]
	[DataRow(99, "ninety-nine")]
	[DataRow(100, "one hundred")]
	[DataRow(101, "one hundred and one")]
	[DataRow(121, "one hundred and twenty-one")]
	[DataRow(999, "nine hundred and ninety-nine")]
	[DataRow(1000, "one thousand")]
	[DataRow(1001, "one thousand and one")]
	[DataRow(1100, "one thousand, one hundred")]
	[DataRow(1101, "one thousand, one hundred and one")]
	[DataRow(9999, "nine thousand, nine hundred and ninety-nine")]
	[DataRow(-1, "negative one")]
	[DataRow(-2, "negative two")]
	[DataRow(-10, "negative ten")]
	[DataRow(-20, "negative twenty")]
	[DataRow(-21, "negative twenty-one")]
	[DataRow(-99, "negative ninety-nine")]
	[DataRow(-100, "negative one hundred")]
	[DataRow(-101, "negative one hundred and one")]
	[DataRow(-121, "negative one hundred and twenty-one")]
	[DataRow(-999, "negative nine hundred and ninety-nine")]
	[DataRow(-1000, "negative one thousand")]
	[DataRow(-1001, "negative one thousand and one")]
	[DataRow(-1100, "negative one thousand, one hundred")]
	[DataRow(-1101, "negative one thousand, one hundred and one")]
	[DataRow(-9999, "negative nine thousand, nine hundred and ninety-nine")]
	public void LowerCaseTranslatorReturnsExpected(int value, string expected)
	{
		string actual = LowerCaseTranslatorWithNegatives.Translate($"{value}");
		actual.Should().Be(expected);
	}

	[TestMethod]
	[DataRow(1.0d, "one")]
	[DataRow(1.1d, "one point one")]
	[DataRow(1.12d, "one point one two")]
	[DataRow(1.123d, "one point one two three")]
	[DataRow(1.1234d, "one point one two three four")]
	[DataRow(1.12345d, "one point one two three four five")]
	//	verify rounding of values to decimal places works as intended
	[DataRow(1.123454d, "one point one two three four five")]
	[DataRow(1.123455d, "one point one two three four six")]
	[DataRow(1.123456d, "one point one two three four six")]
	//	verify zero is not truncated if numbers are present afterwards
	[DataRow(0.1d, "zero point one")]
	[DataRow(0.01d, "zero point zero one")]
	[DataRow(0.001d, "zero point zero zero one")]
	[DataRow(0.0001d, "zero point zero zero zero one")]
	[DataRow(0.00001d, "zero point zero zero zero zero one")]
	[DataRow(0.000001d, "zero")]
	[DataRow(0.000005d, "zero")]
	[DataRow(0.000006d, "zero point zero zero zero zero one")]
	public void LowerCaseTranslatorWithDecimalPlacesReturnsExpected(double value, string expected)
	{
		string actual = LowerCaseTranslatorWithDecimalPlaces.Translate($"{value}");
		actual.Should().Be(expected);
	}

	[TestMethod]
	[DataRow(1.0d, "one")]
	[DataRow(1.1d, "one and ten")]
	[DataRow(1.12d, "one and twelve")]
	[DataRow(1.123d, "one and twelve")]
	[DataRow(1.1234d, "one and twelve")]
	[DataRow(1.12345d, "one and twelve")]
	//	Verify rounding of values to decimal places works as intended
	[DataRow(1.124d, "one and twelve")]
	[DataRow(1.125d, "one and thirteen")]
	[DataRow(1.126d, "one and thirteen")]
	//	Verify zero is not truncated if numbers are present afterwards
	[DataRow(0.1d, "zero and ten")]
	[DataRow(0.01d, "zero and one")]
	[DataRow(0.001d, "zero")]
	//	Check some negatives
	[DataRow(-1, "negative one")]
	[DataRow(-2, "negative two")]
	[DataRow(-10, "negative ten")]
	[DataRow(-11, "negative eleven")]
	[DataRow(-20, "negative twenty")]
	[DataRow(-21, "negative twenty-one")]
	[DataRow(-99, "negative ninety-nine")]
	[DataRow(-100, "negative one hundred")]
	public void LowerCaseWithCurrencyAndNegativesReturnsExpected(double value, string expected)
	{
		string actual = LowerCaseTranslatorWithCurrencyAndNegatives.Translate($"{value}");
		actual.Should().Be(expected);
	}

	#endregion Test lower-case translations
}