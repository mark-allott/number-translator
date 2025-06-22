using NumberTranslator.Interfaces;

namespace NumberTranslator.Strategies;

public class EnglishNumberConcatenationStrategy
	: IConcatenationStrategy
{
	#region IConcatenationStrategy implementation

	/// <inheritdoc />
	public string Concatenator { get; } = "and";

	/// <inheritdoc />
	public string DecimalConcatenator { get; } = "point";

	/// <inheritdoc />
	public string[] Concatenators
	{
		get
		{
			return [Concatenator, DecimalConcatenator];
		}
	}

	#endregion IConcatenationStrategy implementation
}