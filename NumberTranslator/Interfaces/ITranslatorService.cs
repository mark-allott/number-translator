namespace NumberTranslator.Interfaces;

public interface ITranslatorService
{
	/// <summary>
	/// Performs the translation from one text form into another
	/// </summary>
	/// <param name="text">The text to be translated</param>
	/// <returns>The translation of <paramref name="text"/></returns>
	string Translate(string text);
}