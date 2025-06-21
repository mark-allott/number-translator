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

	#region Properites

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

	#endregion Properites

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
	/// <param name="languageCodeId"></param>
	/// <param name="allowCurrency"></param>
	/// <param name="allowDecimal"></param>
	/// <param name="decimalPlaces"></param>
	/// <param name="minValue"></param>
	/// <param name="maxValue"></param>
	/// <returns>An instance of the number translator with the required parameters</returns>
	public INumberTranslator GetNumberTranslator(string languageCodeId, bool allowCurrency = false,
		bool allowDecimal = false, int decimalPlaces = 0, double minValue = 0.0, double maxValue = 9999.0)
	{
		Type translatorType;
		//	Check the language is supported
		if (!_translatorTypes.TryGetValue(languageCodeId, out translatorType!))
			throw new NotImplementedException($"No translator supports language code {languageCodeId}");

		//	Calculate the hashcode the instance with the specified settings would use
		var translatorKey = Translators.NumberTranslator.CalculateKey(languageCodeId, allowCurrency, allowDecimal,
			decimalPlaces, minValue, maxValue);

		//	Attempt to locate an instance of a cached copy of the translator
		if (!_translators.TryGetValue(translatorKey, out var translator) &&
				Activator.CreateInstance(translatorType, args: new object[] { languageCodeId, allowCurrency, allowDecimal, decimalPlaces, minValue, maxValue }, null) is INumberTranslator nt)
		{
			_translators[nt.GetKey()] = translator = nt;
		}

		if (translator is null)
			throw new ArgumentNullException(nameof(languageCodeId), "Unable to create new translator with specified params");

		return translator;
	}

	#endregion Methods
}