using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NumberTranslator.Extensions;
using NumberTranslator.Interfaces;

namespace NumberTranslator.Console
{
	internal class Program
	{
		private static readonly CancellationTokenSource TokenSource = new CancellationTokenSource();

		private static void Main(string[] args)
		{
			System.Console.CancelKeyPress += Console_CancelKeyPress;
			var host = GetHostBuilder(args)
				.Build();
			host.RunAsync(TokenSource.Token);
		}

		private static void Console_CancelKeyPress(object? sender, System.ConsoleCancelEventArgs e)
		{
			//	Do NOT use default behaviour
			e.Cancel = true;
			TokenSource.Cancel();
		}

		private static IHostBuilder GetHostBuilder(string[] args)
		{
			var hostBuilder = Host.CreateDefaultBuilder(args);

			//	Add services for the application
			hostBuilder.ConfigureServices(services =>
			{
				//	Auto-register any startup code
				var assemblies = new[]
				{
					typeof(IStartupRegistration).Assembly,
					typeof(Program).Assembly,
					typeof(Translators.NumberTranslator).Assembly
				};
				services.AddStartupRegistrations(assemblies);

				//	Add hosted service (program to run)
				services.AddHostedService<TranslationRunner>();
			});

			return hostBuilder;
		}
	}
}