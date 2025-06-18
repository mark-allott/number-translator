using System;
using NumberTranslator.Interfaces;

namespace NumberTranslator.Strategies;

public class BritishCurrencyNamingStrategy
	: ICurrencyNamingStrategy, IAutoRegister
{
	#region ICurrencyNamingStrategy implementation

	/// <inheritdoc />
	public string CurrencyIntegralPartName(long value)
	{
		return Math.Abs(value) switch
		{
			1 => "pound",
			_ => "pounds"
		};
	}

	/// <inheritdoc />
	public string CurrencyFractionalPartName(long value)
	{
		return Math.Abs(value) switch
		{
			1 => "penny",
			_ => "pence"
		};
	}

	#endregion ICurrencyNamingStrategy implementation
}