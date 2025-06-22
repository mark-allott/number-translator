using System;
using System.Collections.Generic;

namespace NumberTranslator.Models;

public class NumberTranslatorLanguagesResponse
{
	/// <summary>
	/// A dictionary of languages supported by the translation services
	/// </summary>
	public Dictionary<string, string> TranslatorLanguages { get; }

	/// <summary>
	/// Standard constructor
	/// </summary>
	/// <param name="languages"></param>
	/// <exception cref="ArgumentNullException"></exception>
	public NumberTranslatorLanguagesResponse(Dictionary<string, string> languages)
	{
		TranslatorLanguages = languages ?? throw new ArgumentNullException(nameof(languages));
	}
}