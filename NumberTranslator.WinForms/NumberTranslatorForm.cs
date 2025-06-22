namespace NumberTranslator.WinForms
{
	public partial class NumberTranslatorForm : Form
	{
		private readonly NumberTranslatorFactory _factory;

		public NumberTranslatorForm(NumberTranslatorFactory factory)
		{
			_factory = factory ?? throw new ArgumentNullException(nameof(factory));
			InitializeComponent();
		}

		private void SetDefaultFocus()
		{
			valueTextBox.SelectAll();
			valueTextBox.Focus();
		}

		private void translateButton_Click(object sender, EventArgs e)
		{
			var translator = _factory.GetNumberTranslator("en", useTitleCase: capitaliseNumbersCheckBox.Checked);
			var input = valueTextBox.Text.Trim();
			try
			{
				var response = translator.Translate(input);
				translationTextBox.AppendText($"'{input}' translates to {response}" + Environment.NewLine);
			}
			catch (Exception exception)
			{
				translationTextBox.AppendText($"'{input}' cannot be translated because '{exception.Message}'" + Environment.NewLine);
			}
			SetDefaultFocus();
		}

		private void NumberTranslatorForm_Activated(object sender, EventArgs e)
		{
			SetDefaultFocus();
		}

		private void clearTranslationsButton_Click(object sender, EventArgs e)
		{
			translationTextBox.Clear();
			valueTextBox.Clear();
			SetDefaultFocus();
		}

		private void capitliseNumbersCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SetDefaultFocus();
		}
	}
}