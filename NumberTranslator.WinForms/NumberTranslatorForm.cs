using NumberTranslator.Interfaces;
using NumberTranslator.Translators;

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

		private void SetSettingsButtonText(bool state)
		{
			settingsToggleButton.Text = state
				? "Advanced Settings"
				: "Simple Settings";
		}

		private void SetControlStates()
		{
			//	Decimal place changes are only allowed if the translation settings allow them
			decimalPlacesUpDown.Enabled = includeDecimalPlacesCheckbox.Checked;

			//	Alternate languages are only used in translations if settings permit
			languagesCombobox.Enabled = allowMultilingualCheckbox.Checked;
			if (!languagesCombobox.Enabled)
				languagesCombobox.SelectedIndex = -1;

			SetSettingsButtonText(splitContainer2.Panel2Collapsed);
		}

		private void NumberTranslatorForm_Shown(object sender, EventArgs e)
		{
			languagesCombobox.Items.AddRange(_factory.TranslatorLanguages.Values.Cast<object>().ToArray());
			splitContainer2.Panel2Collapsed = true;
			SetControlStates();
		}

		private void translateButton_Click(object sender, EventArgs e)
		{
			var input = valueTextBox.Text.Trim();
			try
			{
				INumberTranslator translator;
				if (splitContainer2.Panel2Collapsed)
				{
					translator = _factory.GetNumberTranslator("en", useTitleCase: capitaliseNumbersCheckBox.Checked);
				}
				else
				{
					if (!double.TryParse(minimumValueTextbox.Text, out var minValue))
						minValue = 0.0d;
					if (!double.TryParse(maximumValueTextbox.Text, out var maxValue))
						maxValue = 9999.0d;

					//	Get the selected language, or use English as default if no selection made
					var languageCode = languagesCombobox.SelectedIndex != -1
						? _factory.TranslatorLanguages.First(kvp => kvp.Value == languagesCombobox.Text).Key
						: "en";
					translator = _factory.GetNumberTranslator(languageCode, includeCurrencyCheckbox.Checked,
						includeDecimalPlacesCheckbox.Checked, (int)decimalPlacesUpDown.Value, minValue, maxValue,
						capitaliseNumbersCheckBox.Checked);
				}
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

		private void capitaliseNumbersCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SetDefaultFocus();
		}

		private void settingsToggleButton_Click(object sender, EventArgs e)
		{
			splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
			SetSettingsButtonText(splitContainer2.Panel2Collapsed);
		}

		private static char[] allowedChars = ['\b', '\t', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '-'];

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			//	Do not permit non-numeric characters, except backspace, tab, point and minus
			var handled = !allowedChars.Contains(e.KeyChar);

			//	Only perform additional checks if not already flagged as an ignored character, or the sender is not a TextBox
			if (!handled && sender is TextBox textBox)
			{
				//	minus character must be first character
				handled = (textBox.Text.Length > 0 && e.KeyChar == '-') ||
									//	If decimals are permitted, make sure there's only one decimal point character!!
									(e.KeyChar == '.' && (!includeDecimalPlacesCheckbox.Checked || textBox.Text.Contains('.')));
			}
			e.Handled = handled;
		}

		private void Checkboxes_CheckedChanged(object sender, EventArgs e)
		{
			SetControlStates();
		}
	}
}