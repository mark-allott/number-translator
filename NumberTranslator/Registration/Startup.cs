using Microsoft.Extensions.DependencyInjection;
using NumberTranslator.Extensions;
using NumberTranslator.Interfaces;

namespace NumberTranslator.Registration;

public class Startup
	: IStartupRegistration
{
	#region IStartupRegistration implementation

	/// <inheritdoc />
	public IServiceCollection ConfigureServices(IServiceCollection services)
	{
		//	Add services decorated with the IAutoRegister from within the assembly containing this class
		return services.AddAutoRegisterServices(GetType().Assembly);
	}

	#endregion IStartupRegistration implementation
}