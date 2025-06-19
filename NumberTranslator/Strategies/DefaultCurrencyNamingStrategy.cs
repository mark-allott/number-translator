using NumberTranslator.Interfaces;

namespace NumberTranslator.Strategies;

public class DefaultCurrencyNamingStrategy
	: ICurrencyNamingStrategy, IAutoRegister
{
	#region ICurrencyNamingStrategy implementation

	/// <inheritdoc />
	/// <remarks>The default strategy returns no currency names</remarks>
	public string CurrencyIntegralPartName(long value)
	{
		return string.Empty;
	}

	/// <inheritdoc />
	/// <remarks>The default strategy returns no currency names</remarks>
	public string CurrencyFractionalPartName(long value)
	{
		return string.Empty;
	}

	#endregion ICurrencyNamingStrategy implementation
}