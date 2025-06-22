using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace NumberTranslator.Models;

public class NumberTranslatorRequest
{
	#region Properties

	/// <summary>
	/// The digits to be converted / translated to words
	/// </summary>
	[Required]
	public string Text { get; }

	/// <summary>
	/// The language code for translations (see <seealso cref="CultureInfo.Name"/>)
	/// </summary>
	[Required]
	public string LanguageCodeId { get; }

	/// <summary>
	/// Flag to indicate whether to allow fractional parts of numbers in translation
	/// </summary>
	public bool AllowDecimals { get; }

	/// <summary>
	/// Defines the number of decimal places permitted
	/// </summary>
	public int DecimalPlaces { get; }

	/// <summary>
	/// Flag to indicate whether to translate using currency
	/// </summary>
	public bool AllowCurrency { get; }

	/// <summary>
	/// Defines what the minimum value of the input is
	/// </summary>
	public double MinimumValue { get; }

	/// <summary>
	/// Defines the maximum permitted value for the input
	/// </summary>
	public double MaximumValue { get; }

	/// <summary>
	/// Indicates whether output should use title-case rather than lower-case
	/// </summary>
	public bool UseTitleCase { get; }

	#endregion Properties

	#region Ctors

	/// <summary>
	/// Standard constructor
	/// </summary>
	/// <param name="text">The text to be translated</param>
	/// <remarks>Defaults to using the English invariant culture translator</remarks>
	public NumberTranslatorRequest(string text)
		: this(text, "en")
	{
	}

	/// <summary>
	/// Extended constructor to permit fine-grained settings for the translation
	/// </summary>
	/// <param name="text">The digits to be converted / translated to words</param>
	/// <param name="languageCodeId">The language settings</param>
	/// <param name="allowDecimals">Indicates whether decimal places are permitted in the translation</param>
	/// <param name="decimalPlaces">Determines the number of decimal places to permit</param>
	/// <param name="allowCurrency">Indicates whether currency forms should be included in translations</param>
	/// <param name="minimumValue">The minimum value for the translation</param>
	/// <param name="maximumValue">The maximum value for the translation</param>
	/// <param name="useTitleCase">Indicates whether output should use title-case or lower-case in the response</param>
	/// <remarks>If using defaults, the translator will not use decimals, nor currency, has a range of 0-9999 and will emit responses using title-case</remarks>
	[JsonConstructor]
	public NumberTranslatorRequest(string text, string languageCodeId, bool allowDecimals = false,
		int decimalPlaces = 0, bool allowCurrency = false, double minimumValue = 0.0d, double maximumValue = 9999.0d,
		bool useTitleCase = true)
	{
		Text = text;
		LanguageCodeId = languageCodeId;
		AllowDecimals = allowDecimals;
		DecimalPlaces = decimalPlaces;
		AllowCurrency = allowCurrency;
		MinimumValue = minimumValue;
		MaximumValue = maximumValue;
		UseTitleCase = useTitleCase;
	}

	#endregion Ctors
}