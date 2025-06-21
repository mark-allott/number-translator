using System.Globalization;

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
			var translator = _factory.GetNumberTranslator("en");
			var input = valueTextBox.Text.Trim();
			try
			{
				var response = translator.Translate(input);
				if (capitaliseNumbersCheckBox.Checked)
				{
					var ti = new CultureInfo(translator.LanguageCodeId).TextInfo;
					var parts = response.Split(' ', StringSplitOptions.TrimEntries)
						.Select(s => !s.Equals("and") ? ti.ToTitleCase(s) : s)
						.ToArray();
					response = string.Join(' ', parts);
				}
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