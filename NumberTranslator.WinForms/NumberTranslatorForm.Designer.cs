namespace NumberTranslator.WinForms
{
	partial class NumberTranslatorForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			splitContainer1 = new SplitContainer();
			translationTextBox = new TextBox();
			splitContainer2 = new SplitContainer();
			settingsToggleButton = new Button();
			valueTextBox = new TextBox();
			translateButton = new Button();
			clearTranslationsButton = new Button();
			capitaliseNumbersCheckBox = new CheckBox();
			allowMultilingualCheckbox = new CheckBox();
			languagesCombobox = new ComboBox();
			maximumValueTextbox = new TextBox();
			label3 = new Label();
			minimumValueTextbox = new TextBox();
			label2 = new Label();
			label1 = new Label();
			decimalPlacesUpDown = new NumericUpDown();
			includeDecimalPlacesCheckbox = new CheckBox();
			includeCurrencyCheckbox = new CheckBox();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)decimalPlacesUpDown).BeginInit();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.FixedPanel = FixedPanel.Panel2;
			splitContainer1.IsSplitterFixed = true;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Margin = new Padding(4);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.AutoScroll = true;
			splitContainer1.Panel1.Controls.Add(translationTextBox);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(splitContainer2);
			splitContainer1.Panel2.Margin = new Padding(5);
			splitContainer1.Size = new Size(1008, 785);
			splitContainer1.SplitterDistance = 656;
			splitContainer1.TabIndex = 1;
			// 
			// translationTextBox
			// 
			translationTextBox.Dock = DockStyle.Fill;
			translationTextBox.Location = new Point(0, 0);
			translationTextBox.Margin = new Padding(4);
			translationTextBox.Multiline = true;
			translationTextBox.Name = "translationTextBox";
			translationTextBox.ReadOnly = true;
			translationTextBox.ScrollBars = ScrollBars.Both;
			translationTextBox.Size = new Size(1008, 656);
			translationTextBox.TabIndex = 0;
			// 
			// splitContainer2
			// 
			splitContainer2.Dock = DockStyle.Fill;
			splitContainer2.FixedPanel = FixedPanel.Panel1;
			splitContainer2.Location = new Point(0, 0);
			splitContainer2.Margin = new Padding(0);
			splitContainer2.Name = "splitContainer2";
			splitContainer2.Orientation = Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(settingsToggleButton);
			splitContainer2.Panel1.Controls.Add(valueTextBox);
			splitContainer2.Panel1.Controls.Add(translateButton);
			splitContainer2.Panel1.Controls.Add(clearTranslationsButton);
			splitContainer2.Panel1.Controls.Add(capitaliseNumbersCheckBox);
			// 
			// splitContainer2.Panel2
			// 
			splitContainer2.Panel2.Controls.Add(allowMultilingualCheckbox);
			splitContainer2.Panel2.Controls.Add(languagesCombobox);
			splitContainer2.Panel2.Controls.Add(maximumValueTextbox);
			splitContainer2.Panel2.Controls.Add(label3);
			splitContainer2.Panel2.Controls.Add(minimumValueTextbox);
			splitContainer2.Panel2.Controls.Add(label2);
			splitContainer2.Panel2.Controls.Add(label1);
			splitContainer2.Panel2.Controls.Add(decimalPlacesUpDown);
			splitContainer2.Panel2.Controls.Add(includeDecimalPlacesCheckbox);
			splitContainer2.Panel2.Controls.Add(includeCurrencyCheckbox);
			splitContainer2.Size = new Size(1008, 125);
			splitContainer2.SplitterDistance = 48;
			splitContainer2.SplitterWidth = 1;
			splitContainer2.TabIndex = 4;
			splitContainer2.TabStop = false;
			// 
			// settingsToggleButton
			// 
			settingsToggleButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			settingsToggleButton.Location = new Point(764, 4);
			settingsToggleButton.Margin = new Padding(4);
			settingsToggleButton.Name = "settingsToggleButton";
			settingsToggleButton.Size = new Size(240, 40);
			settingsToggleButton.TabIndex = 8;
			settingsToggleButton.Text = "Settings";
			settingsToggleButton.UseVisualStyleBackColor = true;
			settingsToggleButton.Click += settingsToggleButton_Click;
			// 
			// valueTextBox
			// 
			valueTextBox.Location = new Point(8, 12);
			valueTextBox.Margin = new Padding(4);
			valueTextBox.Name = "valueTextBox";
			valueTextBox.PlaceholderText = "Enter value to translate";
			valueTextBox.Size = new Size(328, 29);
			valueTextBox.TabIndex = 7;
			// 
			// translateButton
			// 
			translateButton.Location = new Point(344, 4);
			translateButton.Margin = new Padding(4);
			translateButton.Name = "translateButton";
			translateButton.Size = new Size(120, 40);
			translateButton.TabIndex = 6;
			translateButton.Text = "Translate";
			translateButton.UseVisualStyleBackColor = true;
			translateButton.Click += translateButton_Click;
			// 
			// clearTranslationsButton
			// 
			clearTranslationsButton.Location = new Point(472, 4);
			clearTranslationsButton.Margin = new Padding(4);
			clearTranslationsButton.Name = "clearTranslationsButton";
			clearTranslationsButton.Size = new Size(120, 40);
			clearTranslationsButton.TabIndex = 5;
			clearTranslationsButton.Text = "Clear";
			clearTranslationsButton.UseVisualStyleBackColor = true;
			clearTranslationsButton.Click += clearTranslationsButton_Click;
			// 
			// capitaliseNumbersCheckBox
			// 
			capitaliseNumbersCheckBox.AutoSize = true;
			capitaliseNumbersCheckBox.Checked = true;
			capitaliseNumbersCheckBox.CheckState = CheckState.Checked;
			capitaliseNumbersCheckBox.Location = new Point(600, 12);
			capitaliseNumbersCheckBox.Name = "capitaliseNumbersCheckBox";
			capitaliseNumbersCheckBox.Size = new Size(96, 25);
			capitaliseNumbersCheckBox.TabIndex = 4;
			capitaliseNumbersCheckBox.Text = "Capitalise";
			capitaliseNumbersCheckBox.UseVisualStyleBackColor = true;
			capitaliseNumbersCheckBox.CheckedChanged += capitaliseNumbersCheckBox_CheckedChanged;
			// 
			// allowMultilingualCheckbox
			// 
			allowMultilingualCheckbox.AutoSize = true;
			allowMultilingualCheckbox.Location = new Point(684, 4);
			allowMultilingualCheckbox.Name = "allowMultilingualCheckbox";
			allowMultilingualCheckbox.Size = new Size(208, 25);
			allowMultilingualCheckbox.TabIndex = 9;
			allowMultilingualCheckbox.Text = "Allow Multiple Languages";
			allowMultilingualCheckbox.UseVisualStyleBackColor = true;
			allowMultilingualCheckbox.CheckedChanged += Checkboxes_CheckedChanged;
			// 
			// languagesCombobox
			// 
			languagesCombobox.FormattingEnabled = true;
			languagesCombobox.Location = new Point(684, 41);
			languagesCombobox.Name = "languagesCombobox";
			languagesCombobox.Size = new Size(320, 29);
			languagesCombobox.TabIndex = 8;
			// 
			// maximumValueTextbox
			// 
			maximumValueTextbox.Location = new Point(433, 40);
			maximumValueTextbox.Name = "maximumValueTextbox";
			maximumValueTextbox.Size = new Size(168, 29);
			maximumValueTextbox.TabIndex = 7;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(302, 43);
			label3.Name = "label3";
			label3.Size = new Size(125, 21);
			label3.TabIndex = 6;
			label3.Text = "Maximum Value:";
			// 
			// minimumValueTextbox
			// 
			minimumValueTextbox.Location = new Point(128, 40);
			minimumValueTextbox.Name = "minimumValueTextbox";
			minimumValueTextbox.Size = new Size(168, 29);
			minimumValueTextbox.TabIndex = 5;
			minimumValueTextbox.KeyPress += textBox1_KeyPress;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(4, 43);
			label2.Name = "label2";
			label2.Size = new Size(123, 21);
			label2.TabIndex = 4;
			label2.Text = "Minimum Value:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(379, 5);
			label1.Name = "label1";
			label1.Size = new Size(136, 21);
			label1.TabIndex = 3;
			label1.Text = "Number of places:";
			// 
			// decimalPlacesUpDown
			// 
			decimalPlacesUpDown.Location = new Point(521, 4);
			decimalPlacesUpDown.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			decimalPlacesUpDown.Name = "decimalPlacesUpDown";
			decimalPlacesUpDown.Size = new Size(80, 29);
			decimalPlacesUpDown.TabIndex = 2;
			// 
			// includeDecimalPlacesCheckbox
			// 
			includeDecimalPlacesCheckbox.AutoSize = true;
			includeDecimalPlacesCheckbox.Location = new Point(187, 4);
			includeDecimalPlacesCheckbox.Name = "includeDecimalPlacesCheckbox";
			includeDecimalPlacesCheckbox.Size = new Size(186, 25);
			includeDecimalPlacesCheckbox.TabIndex = 1;
			includeDecimalPlacesCheckbox.Text = "Include Decimal Places";
			includeDecimalPlacesCheckbox.UseVisualStyleBackColor = true;
			includeDecimalPlacesCheckbox.CheckedChanged += Checkboxes_CheckedChanged;
			// 
			// includeCurrencyCheckbox
			// 
			includeCurrencyCheckbox.AutoSize = true;
			includeCurrencyCheckbox.Location = new Point(4, 4);
			includeCurrencyCheckbox.Name = "includeCurrencyCheckbox";
			includeCurrencyCheckbox.Size = new Size(146, 25);
			includeCurrencyCheckbox.TabIndex = 0;
			includeCurrencyCheckbox.Text = "Include Currency";
			includeCurrencyCheckbox.UseVisualStyleBackColor = true;
			// 
			// NumberTranslatorForm
			// 
			AcceptButton = translateButton;
			AutoScaleDimensions = new SizeF(9F, 21F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1008, 785);
			Controls.Add(splitContainer1);
			Font = new Font("Segoe UI", 12F);
			Margin = new Padding(4);
			MinimizeBox = false;
			MinimumSize = new Size(1024, 824);
			Name = "NumberTranslatorForm";
			Text = "Number Translator";
			Activated += NumberTranslatorForm_Activated;
			Shown += NumberTranslatorForm_Shown;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel1.PerformLayout();
			splitContainer2.Panel2.ResumeLayout(false);
			splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)decimalPlacesUpDown).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private TextBox translationTextBox;
		private SplitContainer splitContainer2;
		private TextBox valueTextBox;
		private Button translateButton;
		private Button clearTranslationsButton;
		private CheckBox capitaliseNumbersCheckBox;
		private Button settingsToggleButton;
		private CheckBox includeDecimalPlacesCheckbox;
		private CheckBox includeCurrencyCheckbox;
		private Label label2;
		private Label label1;
		private NumericUpDown decimalPlacesUpDown;
		private TextBox minimumValueTextbox;
		private TextBox maximumValueTextbox;
		private Label label3;
		private CheckBox allowMultilingualCheckbox;
		private ComboBox languagesCombobox;
	}
}
