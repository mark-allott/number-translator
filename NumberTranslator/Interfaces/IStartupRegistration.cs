using Microsoft.Extensions.DependencyInjection;

namespace NumberTranslator.Interfaces;

public interface IStartupRegistration
{
	/// <summary>
	/// Perform service configuration and registration during a startup sequence
	/// </summary>
	/// <param name="services">The current collection of services</param>
	/// <returns>The updated collection of services</returns>
	IServiceCollection ConfigureServices(IServiceCollection services);
}