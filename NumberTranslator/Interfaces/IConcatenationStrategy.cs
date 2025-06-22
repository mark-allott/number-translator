namespace NumberTranslator.Interfaces;

public interface IConcatenationStrategy
{
	/// <summary>
	/// Used to provide the word joining two parts of the word groups
	/// </summary>
	/// <remarks>For English, the word is "and", etc.</remarks>
	string Concatenator { get; }

	/// <summary>
	/// Used to provide the word joining the integral and decimal parts of the word groups
	/// </summary>
	/// <remarks>For English, the word would be "point", e.g. Pi would start three point one four one...</remarks>
	string DecimalConcatenator { get; }

	/// <summary>
	/// Provides the concatenators used within the strategy that would be excluded from title-case conversions
	/// </summary>
	string[] Concatenators { get; }
}