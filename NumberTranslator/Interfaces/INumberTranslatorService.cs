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

	/// <summary>
	/// Supplies the minimum value allowed by the service
	/// </summary>
	double MinimumValue { get; }

	/// <summary>
	/// Supplies the maximum value allowed by the service
	/// </summary>
	double MaximumValue { get; }
}