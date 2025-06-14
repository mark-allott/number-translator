using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NumberTranslator.Interfaces;

namespace NumberTranslator.Extensions;

public static class AutoRegisterExtensions
{
	#region Assembly scanning methods

	/// <summary>
	/// Internal class to hold type information
	/// </summary>
	private class TypeAndInterfaces
	{
		public TypeAndInterfaces(Type exportedType, List<Type> interfaces)
		{
			ExportedType = exportedType ?? throw new ArgumentNullException(nameof(exportedType));
			Interfaces = interfaces ?? throw new ArgumentNullException(nameof(interfaces));
		}

		public Type ExportedType { get; set; }
		public List<Type> Interfaces { get; set; }
	}

	/// <summary>
	/// Returns a list of concrete types with matching <param name="interfaceTypes"></param>
	/// </summary>
	/// <param name="assemblies">The assembly array to scan</param>
	/// <param name="interfaceTypes">The array of interface types</param>
	/// <returns></returns>
	private static List<TypeAndInterfaces> GetTypesAndInterfaces(Assembly[] assemblies, Type[] interfaceTypes)
	{
		return assemblies.SelectMany(s => s.ExportedTypes)
			.Where(q => q is { IsAbstract: false, IsClass: true, BaseType: not null })
			.Select(s => new
			{
				ExportedType = s,
				ImplementedInterfaces = s.GetInterfaces().Where(q => interfaceTypes.Contains(q)).ToList()
			})
			.Where(q => q.ImplementedInterfaces.Count > 0)
			.Select(s => new TypeAndInterfaces(s.ExportedType, s.ImplementedInterfaces))
			.ToList();
	}

	#endregion Assembly scanning methods

	/// <summary>
	/// Search for and execute any startup registration methods in the specified <param name="assemblies"></param>
	/// </summary>
	/// <param name="services"></param>
	/// <param name="assemblies"></param>
	/// <returns>The updated collection of services</returns>
	/// <exception cref="ArgumentException"></exception>
	public static IServiceCollection AddStartupRegistrations(this IServiceCollection services,
		params Assembly[] assemblies)
	{
		//	Must have some services to append to
		_ = services ?? throw new ArgumentNullException(nameof(services));

		//	MUST have at least one assembly to scan for startup registration code
		if (assemblies.Length == 0)
			throw new ArgumentException("No assemblies selected", nameof(assemblies));

		//	Define the interface(s) to detect for auto-registration
		var interfaceTypes = new[] { typeof(IStartupRegistration) };

		// Locate startup code with class inheritance of the interfaceTypes which
		// are not abstract classes, then locate all classes whose interfaces that
		// are not in the interfaceTypes list and present for auto-registration
		var startupRegistration = GetTypesAndInterfaces(assemblies, interfaceTypes);

		// For the list of startup registrations found...
		startupRegistration.ForEach(c =>
		{
			//	Add the service as a singleton
			services.AddSingleton(c.ExportedType);
			//	Interfaces should be transient and link back to the singleton
			c.Interfaces.ForEach(i =>
			{
				services.AddTransient(i, c.ExportedType);
			});

			//	Run the startup code by creating an instance and calling its ConfigureServices
			if (Activator.CreateInstance(c.ExportedType, null) is IStartupRegistration startup)
				startup.ConfigureServices(services);
		});

		return services;
	}

	/// <summary>
	/// Auto-register classes decorated with the <see cref="IAutoRegister"/> interface as transient services
	/// </summary>
	/// <param name="services">An existing collection of services</param>
	/// <param name="assembly">The assembly to be scanned for services to be auto-registered</param>
	/// <returns>The updated collection of services</returns>
	/// <exception cref="ArgumentNullException"></exception>
	public static IServiceCollection AddAutoRegisterServices(this IServiceCollection services, Assembly assembly)
	{
		//	Must have some services to append to
		_ = services ?? throw new ArgumentNullException(nameof(services));

		//	MUST have an assembly to scan for auto registration code
		_ = assembly ?? throw new ArgumentNullException(nameof(assembly));

		//	Extract classes implementing IAutoRegister
		var autoRegistrations = GetTypesAndInterfaces(new[] { assembly }, new[] { typeof(IAutoRegister) });

		autoRegistrations.ForEach(c =>
		{
			services.AddTransient(c.ExportedType);
			c.Interfaces.ForEach(i => services.AddTransient(i, c.ExportedType));
		});
		return services;
	}
}