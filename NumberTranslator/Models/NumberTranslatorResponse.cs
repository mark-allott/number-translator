namespace NumberTranslator.Models;

public class NumberTranslatorResponse
{
	#region Properties

	/// <summary>
	/// The text to be translated
	/// </summary>
	public string InputText { get; }

	/// <summary>
	/// The translation result (if successful)
	/// </summary>
	public string Translation { get; }

	/// <summary>
	/// Flag indicating success or failure of the translation operation
	/// </summary>
	public bool HasError { get; }

	/// <summary>
	/// The error message returned from the translator (if translation was unsuccessful)
	/// </summary>
	public string ErrorMessage { get; }

	#endregion Properties

	#region Ctors

	/// <summary>
	/// Hidden constructor - responses are created using the static methods
	/// </summary>
	/// <param name="inputText">The text that was to be translated</param>
	/// <param name="hasError">A flag indicating success or failure</param>
	/// <param name="message">The message to be either the translation result or error message, dependant upon the value of <paramref name="hasError"/></param>
	private NumberTranslatorResponse(string inputText, bool hasError, string message)
	{
		InputText = inputText;
		HasError = hasError;
		Translation = hasError
			? string.Empty
			: message;
		ErrorMessage = hasError
			? message
			: string.Empty;
	}

	/// <summary>
	/// Public constructor for successful translations
	/// </summary>
	/// <param name="inputText">The text that was for translation</param>
	/// <param name="translation">The response from the translator</param>
	/// <returns></returns>
	public static NumberTranslatorResponse Success(string inputText, string translation)
	{
		return new NumberTranslatorResponse(inputText, false, translation);
	}

	/// <summary>
	/// Public constructor for unsuccessful translations
	/// </summary>
	/// <param name="inputText">The text that was for translation</param>
	/// <param name="errorMessage">The error response from the translator</param>
	/// <returns></returns>
	public static NumberTranslatorResponse Failure(string inputText, string errorMessage)
	{
		return new NumberTranslatorResponse(inputText, true, errorMessage);
	}

	#endregion Ctors
}