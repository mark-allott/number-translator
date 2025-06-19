using System;
using NumberTranslator.Interfaces;

namespace NumberTranslator.Strategies;

public class AmericanCurrencyNamingStrategy
	: ICurrencyNamingStrategy, IAutoRegister
{
	#region ICurrencyNamingStrategy implementation

	/// <inheritdoc />
	public string CurrencyIntegralPartName(long value)
	{
		return Math.Abs(value) switch
		{
			1 => "dollar",
			_ => "dollars"
		};
	}

	/// <inheritdoc />
	public string CurrencyFractionalPartName(long value)
	{
		return Math.Abs(value) switch
		{
			1 => "cent",
			_ => "cents"
		};
	}

	#endregion ICurrencyNamingStrategy implementation
}