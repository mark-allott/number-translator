using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NumberTranslator.Interfaces;

namespace NumberTranslator;

public class NumberTranslatorFactory
	: IAutoRegister
{
	#region Fields

	/// <summary>
	/// Holds the cached copies of translators created
	/// </summary>
	private readonly Dictionary<string, INumberTranslator> _translators;

	/// <summary>
	/// Holds cached information about languages for translators and their types, so new instances with different settings can be created
	/// </summary>
	private readonly Dictionary<string, Type> _translatorTypes;

	#endregion Fields

	#region Properties

	/// <summary>
	/// Returns a dictionary of languages supported for translations in language code and language name order
	/// </summary>
	public Dictionary<string, string> TranslatorLanguages
	{
		get
		{
			return _translators
				.OrderBy(o => o.Value.LanguageCodeId)
				.DistinctBy(d => d.Value.LanguageCodeId)
				.ToDictionary(d => d.Value.LanguageCodeId, d => d.Value.LanguageName);
		}
	}

	#endregion Properties

	#region Ctor

	/// <summary>
	/// Standard constructor
	/// </summary>
	/// <param name="services">An instance of a service provider which can supply the list of translators registered</param>
	/// <exception cref="ArgumentNullException"></exception>
	public NumberTranslatorFactory(IServiceProvider services)
	{
		_ = services ?? throw new ArgumentNullException(nameof(services));

		//	Populate cache with basic translators - different languages, but no changes from defaults
		_translators = services.GetServices<INumberTranslator>()
			.ToDictionary(d => d.GetKey(), d => d);
		//	Populate the type dictionary with the services discovered
		_translatorTypes = _translators.Values
			.ToDictionary(d => d.LanguageCodeId, d => d.GetType());
	}

	#endregion Ctor

	#region Methods

	/// <summary>
	/// Returns an instance of an <see cref="INumberTranslator"/> that uses the correct language and numeric settings
	/// </summary>
	/// <param name="languageCodeId">The language code for the translator</param>
	/// <param name="allowCurrency">A flag indicating whether currency translations are permitted</param>
	/// <param name="allowDecimal">A flag indicating whether decimal values are permitted in calculations</param>
	/// <param name="decimalPlaces">The number of decimal places to report</param>
	/// <param name="minValue">The minimum accepted value for translations</param>
	/// <param name="maxValue">The maximum accepted value for translations</param>
	/// <param name="useTitleCase">A flag indicating whether translations should use title-case or only lower-case</param>
	/// <returns>An instance of the number translator with the required parameters</returns>
	public INumberTranslator GetNumberTranslator(string languageCodeId, bool allowCurrency = false,
		bool allowDecimal = false, int decimalPlaces = 0, double minValue = 0.0, double maxValue = 9999.0,
		bool useTitleCase = true)
	{
		//	Check the language is supported
		if (!_translatorTypes.TryGetValue(languageCodeId, out var translatorType))
			throw new NotImplementedException($"No translator supports language code {languageCodeId}");

		//	Calculate the hashcode the instance with the specified settings would use
		var translatorKey = Translators.NumberTranslator
			.CalculateKey(languageCodeId, allowCurrency, allowDecimal, decimalPlaces, minValue, maxValue, useTitleCase);

		//	Attempt to locate an instance of a cached copy of the translator
		if (!_translators.TryGetValue(translatorKey, out var translator) &&
				Activator.CreateInstance(translatorType, args: new object[] { allowDecimal, decimalPlaces, allowCurrency, minValue, maxValue, useTitleCase }, null) is INumberTranslator nt)
		{
			_translators[nt.GetKey()] = translator = nt;
		}

		if (translator is null)
			throw new ArgumentNullException(nameof(languageCodeId), "Unable to create new translator with specified params");

		return translator;
	}

	#endregion Methods
}