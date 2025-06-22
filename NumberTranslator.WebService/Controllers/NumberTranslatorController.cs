using Microsoft.AspNetCore.Mvc;
using NumberTranslator.Interfaces;
using NumberTranslator.Models;

namespace NumberTranslator.WebService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NumberTranslatorController
		: ControllerBase
	{
		#region Fields

		private readonly NumberTranslatorFactory _translatorFactory;

		#endregion Fields

		#region Ctor

		/// <summary>
		/// Constructor for number translations
		/// </summary>
		/// <param name="translatorFactory">An instance of the <see cref="NumberTranslatorFactory"/> class which can supply the required translator</param>
		/// <exception cref="ArgumentNullException"></exception>
		public NumberTranslatorController(NumberTranslatorFactory translatorFactory)
		{
			_translatorFactory = translatorFactory ?? throw new ArgumentNullException(nameof(translatorFactory));
		}

		#endregion Ctor

		#region Methods

		/// <summary>
		/// Performs the translation using the <paramref name="translator"/> passed to the method, then
		/// checks to see if the result needs to be updated if <paramref name="titleCase"/> is requested
		/// </summary>
		/// <param name="text">The digits to translate</param>
		/// <param name="titleCase">A flag to indicate if the response is required using title case</param>
		/// <param name="translator">The translator to use for the translation</param>
		/// <returns></returns>
		private (string translation, bool isError) GetTranslation(string text, bool titleCase, INumberTranslator translator)
		{
			var isError = false;
			string translation;
			try
			{
				translation = translator.Translate(text.Trim());
			}
			catch (Exception e)
			{
				isError = true;
				translation = e.Message;
			}

			return (translation, isError);
		}

		/// <summary>
		/// Performs a simple translation of the supplied <paramref name="text"/>
		/// </summary>
		/// <param name="text">The numbers to be translated</param>
		/// <param name="titleCase">An indicator as to whether the response should be changed to title-case in the response</param>
		/// <returns>The response from the translator</returns>
		[Route("translateNumber/{text:required}/{titleCase:bool?}")]
		[HttpGet]
		[ProducesDefaultResponseType(typeof(NumberTranslatorResponse))]
		[ProducesErrorResponseType(typeof(StatusCodeResult))]
		public IActionResult SimpleNumberTranslation([FromRoute] string text, [FromRoute] bool titleCase = true)
		{
			if (string.IsNullOrWhiteSpace(text))
				return new BadRequestResult();

			try
			{
				var translator = _translatorFactory.GetNumberTranslator("en", useTitleCase: titleCase);
				var (translation, isError) = GetTranslation(text.Trim(), titleCase, translator);

				var response = isError
					? NumberTranslatorResponse.Failure(text, translation)
					: NumberTranslatorResponse.Success(text, translation);
				return new JsonResult(response);
			}
			catch
			{
				return new StatusCodeResult(501);
			}
		}

		/// <summary>
		/// Allows querying of the translator factory to get the languages supported
		/// </summary>
		/// <returns>An instance of <see cref="NumberTranslatorLanguagesResponse"/> as JSON</returns>
		[Route("getSupportedLanguages")]
		[HttpGet]
		[ProducesDefaultResponseType(typeof(NumberTranslatorLanguagesResponse))]
		public IActionResult GetTranslatorLanguages()
		{
			var response = new NumberTranslatorLanguagesResponse(_translatorFactory.TranslatorLanguages);
			return new JsonResult(response);
		}

		/// <summary>
		/// Performs a more granular conversion using parameters supplied in <see cref="NumberTranslatorRequest"/>
		/// </summary>
		/// <param name="request">The request parameters, including language etc.</param>
		/// <returns>The response from the translator</returns>
		[Route("translateNumber")]
		[HttpPost]
		[ProducesDefaultResponseType(typeof(NumberTranslatorResponse))]
		[ProducesErrorResponseType(typeof(StatusCodeResult))]
		public IActionResult NumberTranslation([FromBody] NumberTranslatorRequest request)
		{
			try
			{
				var translator = _translatorFactory.GetNumberTranslator(request.LanguageCodeId, request.AllowCurrency,
					request.AllowDecimals, request.DecimalPlaces, request.MinimumValue, request.MaximumValue,
					request.UseTitleCase);
				var (translation, isError) = GetTranslation(request.Text.Trim(), request.UseTitleCase, translator);

				var response = isError
					? NumberTranslatorResponse.Failure(request.Text, translation)
					: NumberTranslatorResponse.Success(request.Text, translation);
				return new JsonResult(response);
			}
			catch
			{
				return new StatusCodeResult(501);
			}
		}

		#endregion Methods
	}
}