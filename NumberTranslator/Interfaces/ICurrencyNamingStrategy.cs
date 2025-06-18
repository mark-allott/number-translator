namespace NumberTranslator.Interfaces;

public interface ICurrencyNamingStrategy
{
	/// <summary>
	/// Returns the currency name part for whole units, e.g. pound(s) for UK, dollar(s) for USA, etc.
	/// </summary>
	/// <param name="value">The whole part of the currency to be named</param>
	/// <returns>The name of the currency unit</returns>
	public string CurrencyIntegralPartName(long value);

	/// <summary>
	/// Returns the currency name part for whole units, e.g. penny/pence for UK, cent(s) for USA, etc.
	/// </summary>
	/// <param name="value">The fractional part of the currency to be named</param>
	/// <returns>The name of the fractional currency unit</returns>
	public string CurrencyFractionalPartName(long value);
}