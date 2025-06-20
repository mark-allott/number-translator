using Microsoft.Extensions.DependencyInjection;

namespace NumberTranslator.WinForms
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var services = ConfigureServices(new ServiceCollection());

			using (var provider = services.BuildServiceProvider())
			{
				var form = provider.GetRequiredService<NumberTranslatorForm>();
				Application.Run(form);
			}
		}

		private static ServiceCollection ConfigureServices(ServiceCollection services)
		{
			services.AddScoped(typeof(NumberTranslatorForm));
			return services;
		}
	}
}