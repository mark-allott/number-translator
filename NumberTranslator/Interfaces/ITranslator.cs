namespace NumberTranslator.Interfaces;

public interface ITranslator
{
	/// <summary>
	/// Performs the translation for <param name="text"></param> into the required output
	/// </summary>
	/// <param name="text">The text value to be converted</param>
	/// <returns>The value of <param name="text"></param> translated to the appropriate format</returns>
	string Translate(string text);

	/// <summary>
	/// Defines the language for the translation
	/// </summary>
	/// <remarks>The language code identifiers are to be taken from the product behaviour details located at https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-lcid/a9eac961-e77d-41a6-90a5-ce1a8b0cdb9c</remarks>
	string LanguageCodeId { get; }

	/// <summary>
	/// Returns the display name for the culture, suitable for inclusion in display lists etc.
	/// </summary>
	string LanguageName { get; }
}