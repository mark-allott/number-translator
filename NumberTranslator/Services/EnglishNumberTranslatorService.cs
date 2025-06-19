using System;
using NumberTranslator.Interfaces;
using NumberTranslator.Translators;

namespace NumberTranslator.Services;

public class EnglishNumberTranslatorService
	: NumberTranslatorService
{
	#region Fields

	private readonly INumberTranslator _translator;

	#endregion Fields

	#region ctor

	/// <summary>
	/// Default constructor yields a generic English translator for numbers to words
	/// </summary>
	public EnglishNumberTranslatorService()
		: base("en")
	{
		_translator = new EnglishNumberTranslator();
	}

	#endregion ctor

	#region TranslatorService overrides

	/// <inheritdoc />
	/// <remarks>Any errors are captured and the message is returned</remarks>
	public override string Translate(string text)
	{
		try
		{
			return _translator.Translate(text);
		}
		catch (Exception e)
		{
			return $"Unable to translate '{text}'. Translator issued the following error message: '{e.Message}'";
		}
	}

	#endregion TranslatorService overrides
}