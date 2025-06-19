using System.Globalization;

namespace NumberTranslator.Interfaces;

public interface INumberTranslatorService
	: ITranslatorService
{
	/// <summary>
	/// Holds the value from <seealso cref="CultureInfo.Name"/>
	/// </summary>
	string LanguageCodeId { get; }

	/// <summary>
	/// Holds the value from <seealso cref="CultureInfo.DisplayName"/>
	/// </summary>
	string LanguageName { get; }
}