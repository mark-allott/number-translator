using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NumberTranslator.Extensions;
using NumberTranslator.Interfaces;
using NumberTranslator.Translators;
using NumberTranslator.Translators.Languages;

namespace NumberTranslator.Tests;

[TestClass]
public class NumberTranslatorFactoryTests
{
	private static ServiceProvider _serviceProvider = null!;

	private static NumberTranslatorFactory? _factory = null;

	[ClassInitialize]
	public static void ClassInit(TestContext context)
	{
		ServiceCollection services = new ServiceCollection();
		services.AddAutoRegisterServices(typeof(NumberTranslatorFactory).Assembly);
		_serviceProvider = services.BuildServiceProvider();
	}

	[ClassCleanup]
	public static void ClassCleanup()
	{
		_serviceProvider.Dispose();
	}

	[TestInitialize]
	public void TestInit()
	{
		_factory ??= _serviceProvider.GetRequiredService<NumberTranslatorFactory>();
		_factory.Should().NotBeNull();
	}

	[TestMethod]
	public void FactoryContainsExpectedLanguages()
	{
		_factory?.TranslatorLanguages.Keys.Should().Contain(new[] { "en", "en-GB", "en-US" });
	}

	[TestMethod]
	[DataRow("en", typeof(EnglishNumberTranslator))]
	[DataRow("en-GB", typeof(BritishEnglishNumberTranslator))]
	[DataRow("en-US", typeof(AmericanEnglishNumberTranslator))]
	public void FactoryContainsCorrectTypesForLanguageCode(string code, Type expectedType)
	{
		INumberTranslator translator = _factory?.GetNumberTranslator(code) ?? null!;
		translator.Should().NotBeNull();
		translator.LanguageCodeId.Should().Be(code);
		translator.GetType().Should().Be(expectedType);
	}
}