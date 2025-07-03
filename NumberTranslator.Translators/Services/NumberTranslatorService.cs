using System.Globalization;
using NumberTranslator.Interfaces;

namespace NumberTranslator.Translators.Services;

/// <summary>
/// Base class for all numeric translations
/// </summary>
public abstract class NumberTranslatorService
	: TranslatorService, INumberTranslatorService
{
	#region Fields

	protected INumberTranslator Translator = null!;

	#endregion Fields

	#region Properties

	/// <inheritdoc />
	public string LanguageCodeId { get; }

	/// <inheritdoc />
	public string LanguageName { get; }

	public double MinimumValue => Translator?.MinimumValue ?? double.MinValue;

	public double MaximumValue => Translator?.MaximumValue ?? double.MaxValue;

	#endregion Properties

	#region ctor

	/// <summary>
	/// Protected constructor to yield a specific language translator defined in subclasses
	/// </summary>
	/// <param name="languageCodeId">The appropriate code from <see cref="CultureInfo.Name"/></param>
	/// <exception cref="ArgumentNullException"></exception>
	protected NumberTranslatorService(string languageCodeId)
	{
		if (string.IsNullOrWhiteSpace(languageCodeId))
			throw new ArgumentNullException(nameof(languageCodeId));

		//	If a culture is unknown, an error will occur here
		var ci = new CultureInfo(languageCodeId);
		LanguageCodeId = ci.Name;
		LanguageName = ci.DisplayName;
	}

	#endregion ctor
}