using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NumberTranslator.Interfaces;
using NumberTranslator.Services;

namespace NumberTranslator.Console;

public class TranslationRunner
	: IHostedService
{
	#region Fields

	private readonly INumberTranslatorService _translatorService;

	#endregion Fields

	#region ctor

	public TranslationRunner(IServiceProvider serviceProvider)
	{
		_translatorService = serviceProvider.GetService<EnglishNumberTranslatorService>()!;

		if (_translatorService is null)
			throw new NotImplementedException("Cannot locate translator");
		//	TBC
	}

	#endregion ctor

	#region IHostedService implementation

	public Task StartAsync(CancellationToken cancellationToken)
	{
		System.Console.WriteLine("Welcome to the translator service for Numbers to English");
		System.Console.WriteLine("");
		System.Console.WriteLine($"Please enter a number between {_translatorService.MinimumValue} and {_translatorService.MaximumValue} to convert to numbers, or 'quit' to exit");

		while (true && !cancellationToken.IsCancellationRequested)
		{
			var input = System.Console.ReadLine();

			if (cancellationToken.IsCancellationRequested)
				break;

			if (string.IsNullOrWhiteSpace(input))
			{
				var oldForeground = System.Console.ForegroundColor;
				System.Console.ForegroundColor = ConsoleColor.Red;
				System.Console.WriteLine("Must supply a value!");
				System.Console.ForegroundColor = oldForeground;
				continue;
			}

			if (input.ToLower().Equals("quit"))
				break;

			System.Console.WriteLine(_translatorService.Translate(input));
		}
		return Task.CompletedTask;
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}

	#endregion IHostedService implementation
}