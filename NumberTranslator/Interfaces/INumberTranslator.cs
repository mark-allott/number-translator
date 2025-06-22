namespace NumberTranslator.Interfaces;

public interface INumberTranslator
	: ITranslator
{
	/// <summary>
	/// Flag to indicate whether to allow fractional parts of numbers in translation
	/// </summary>
	bool AllowDecimals { get; }

	/// <summary>
	/// Defines the number of decimal places permitted
	/// </summary>
	int DecimalPlaces { get; }

	/// <summary>
	/// Flag to indicate whether to translate using currency
	/// </summary>
	bool AllowCurrency { get; }

	/// <summary>
	/// Defines what the minimum value of the input is
	/// </summary>
	double MinimumValue { get; }

	/// <summary>
	/// Defines the maximum permitted value for the input
	/// </summary>
	double MaximumValue { get; }

	/// <summary>
	/// Returns a key for the translator based on values specified in other properties
	/// </summary>
	string GetKey();

	/// <summary>
	/// Indicates whether output should use title-case, or all lower-case
	/// </summary>
	bool UseTitleCase { get; }
}