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
			valueTextBox = new TextBox();
			translateButton = new Button();
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
			splitContainer1.Panel2.Controls.Add(translateButton);
			splitContainer1.Panel2.Controls.Add(valueTextBox);
			splitContainer1.Panel2.Margin = new Padding(4);
			splitContainer1.Size = new Size(784, 561);
			splitContainer1.SplitterDistance = 500;
			splitContainer1.TabIndex = 1;
			// 
			// translationTextBox
			// 
			translationTextBox.Dock = DockStyle.Fill;
			translationTextBox.Location = new Point(0, 0);
			translationTextBox.Multiline = true;
			translationTextBox.Name = "translationTextBox";
			translationTextBox.ReadOnly = true;
			translationTextBox.Size = new Size(784, 500);
			translationTextBox.TabIndex = 0;
			// 
			// valueTextBox
			// 
			valueTextBox.Location = new Point(8, 16);
			valueTextBox.Name = "valueTextBox";
			valueTextBox.PlaceholderText = "Enter value to translate";
			valueTextBox.Size = new Size(256, 23);
			valueTextBox.TabIndex = 0;
			// 
			// translateButton
			// 
			translateButton.Location = new Point(278, 9);
			translateButton.Name = "translateButton";
			translateButton.Size = new Size(96, 36);
			translateButton.TabIndex = 1;
			translateButton.Text = "Translate";
			translateButton.UseVisualStyleBackColor = true;
			// 
			// NumberTranslatorForm
			// 
			AcceptButton = translateButton;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(784, 561);
			Controls.Add(splitContainer1);
			MinimizeBox = false;
			Name = "NumberTranslatorForm";
			Text = "Number Translator";
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
	}
}
