using System;
using System.Text;
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
		base.Translator = new EnglishNumberTranslator();
	}

	#endregion ctor

	#region TranslatorService overrides

	/// <inheritdoc />
	/// <remarks>Any errors are captured and the message is returned</remarks>
	public override string Translate(string text)
	{
		try
		{
			return Translator.Translate(text);
		}
		catch (Exception e)
		{
			var sb = new StringBuilder();
			sb.AppendLine($"Unable to translate '{text}'. Translator issued the following error message:")
				.AppendLine($"'{e.Message}'");
			return sb.ToString();
		}
	}

	#endregion TranslatorService overrides
}