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
			capitaliseNumbersCheckBox = new CheckBox();
			clearTranslationsButton = new Button();
			translateButton = new Button();
			valueTextBox = new TextBox();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
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
			splitContainer1.Panel2.Controls.Add(capitaliseNumbersCheckBox);
			splitContainer1.Panel2.Controls.Add(clearTranslationsButton);
			splitContainer1.Panel2.Controls.Add(translateButton);
			splitContainer1.Panel2.Controls.Add(valueTextBox);
			splitContainer1.Panel2.Margin = new Padding(5, 6, 5, 6);
			splitContainer1.Size = new Size(1008, 785);
			splitContainer1.SplitterDistance = 693;
			splitContainer1.SplitterWidth = 6;
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
			translationTextBox.Size = new Size(1008, 693);
			translationTextBox.TabIndex = 0;
			// 
			// capitaliseNumbersCheckBox
			// 
			capitaliseNumbersCheckBox.AutoSize = true;
			capitaliseNumbersCheckBox.Checked = true;
			capitaliseNumbersCheckBox.CheckState = CheckState.Checked;
			capitaliseNumbersCheckBox.Location = new Point(601, 11);
			capitaliseNumbersCheckBox.Name = "capitaliseNumbersCheckBox";
			capitaliseNumbersCheckBox.Size = new Size(96, 25);
			capitaliseNumbersCheckBox.TabIndex = 3;
			capitaliseNumbersCheckBox.Text = "Capitalise";
			capitaliseNumbersCheckBox.UseVisualStyleBackColor = true;
			capitaliseNumbersCheckBox.CheckedChanged += capitliseNumbersCheckBox_CheckedChanged;
			// 
			// clearTranslationsButton
			// 
			clearTranslationsButton.Location = new Point(489, 11);
			clearTranslationsButton.Margin = new Padding(4);
			clearTranslationsButton.Name = "clearTranslationsButton";
			clearTranslationsButton.Size = new Size(93, 50);
			clearTranslationsButton.TabIndex = 2;
			clearTranslationsButton.Text = "Clear";
			clearTranslationsButton.UseVisualStyleBackColor = true;
			clearTranslationsButton.Click += clearTranslationsButton_Click;
			// 
			// translateButton
			// 
			translateButton.Location = new Point(357, 11);
			translateButton.Margin = new Padding(4);
			translateButton.Name = "translateButton";
			translateButton.Size = new Size(123, 50);
			translateButton.TabIndex = 1;
			translateButton.Text = "Translate";
			translateButton.UseVisualStyleBackColor = true;
			translateButton.Click += translateButton_Click;
			// 
			// valueTextBox
			// 
			valueTextBox.Location = new Point(10, 22);
			valueTextBox.Margin = new Padding(4);
			valueTextBox.Name = "valueTextBox";
			valueTextBox.PlaceholderText = "Enter value to translate";
			valueTextBox.Size = new Size(328, 29);
			valueTextBox.TabIndex = 0;
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
			Name = "NumberTranslatorForm";
			Text = "Number Translator";
			Activated += NumberTranslatorForm_Activated;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private TextBox translationTextBox;
		private Button translateButton;
		private TextBox valueTextBox;
		private Button clearTranslationsButton;
		private CheckBox capitaliseNumbersCheckBox;
	}
}
