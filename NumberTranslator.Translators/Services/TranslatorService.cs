using NumberTranslator.Interfaces;

namespace NumberTranslator.Services;

/// <summary>
/// Forms the basis of a translation service
/// </summary>
public abstract class TranslatorService
	: IAutoRegister, ITranslatorService
{
	/// <summary>
	/// Performs the conversion of <paramref name="text"/> to its translated equivalent
	/// </summary>
	/// <param name="text">The message to translate</param>
	/// <returns>The translated equivalent of <paramref name="text"/></returns>
	public abstract string Translate(string text);
}