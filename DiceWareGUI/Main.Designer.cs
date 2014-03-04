namespace DiceWarePasswordGenerator
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.PassphraseText = new System.Windows.Forms.TextBox();
			this.GenerateButton = new System.Windows.Forms.Button();
			this.NumWordsLabel = new System.Windows.Forms.Label();
			this.NumWordsTrackbar = new System.Windows.Forms.TrackBar();
			this.RandomLanguageCheckbox = new System.Windows.Forms.CheckBox();
			this.LanguageCombo = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.NumWordsTrackbar)).BeginInit();
			this.SuspendLayout();
			// 
			// PassphraseText
			// 
			this.PassphraseText.BackColor = System.Drawing.SystemColors.Control;
			this.PassphraseText.Location = new System.Drawing.Point(12, 12);
			this.PassphraseText.Name = "PassphraseText";
			this.PassphraseText.Size = new System.Drawing.Size(272, 20);
			this.PassphraseText.TabIndex = 0;
			// 
			// GenerateButton
			// 
			this.GenerateButton.Image = ((System.Drawing.Image)(resources.GetObject("GenerateButton.Image")));
			this.GenerateButton.Location = new System.Drawing.Point(290, 9);
			this.GenerateButton.Name = "GenerateButton";
			this.GenerateButton.Size = new System.Drawing.Size(25, 24);
			this.GenerateButton.TabIndex = 1;
			this.GenerateButton.UseVisualStyleBackColor = true;
			this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
			// 
			// NumWordsLabel
			// 
			this.NumWordsLabel.AutoSize = true;
			this.NumWordsLabel.Location = new System.Drawing.Point(12, 45);
			this.NumWordsLabel.Name = "NumWordsLabel";
			this.NumWordsLabel.Size = new System.Drawing.Size(93, 13);
			this.NumWordsLabel.TabIndex = 2;
			this.NumWordsLabel.Text = "Number of Words:";
			// 
			// NumWordsTrackbar
			// 
			this.NumWordsTrackbar.Location = new System.Drawing.Point(15, 61);
			this.NumWordsTrackbar.Minimum = 1;
			this.NumWordsTrackbar.Name = "NumWordsTrackbar";
			this.NumWordsTrackbar.Size = new System.Drawing.Size(126, 45);
			this.NumWordsTrackbar.TabIndex = 3;
			this.NumWordsTrackbar.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.NumWordsTrackbar.Value = 1;
			// 
			// RandomLanguageCheckbox
			// 
			this.RandomLanguageCheckbox.AutoSize = true;
			this.RandomLanguageCheckbox.Location = new System.Drawing.Point(155, 44);
			this.RandomLanguageCheckbox.Name = "RandomLanguageCheckbox";
			this.RandomLanguageCheckbox.Size = new System.Drawing.Size(117, 17);
			this.RandomLanguageCheckbox.TabIndex = 4;
			this.RandomLanguageCheckbox.Text = "Random Language";
			this.RandomLanguageCheckbox.UseVisualStyleBackColor = true;
			this.RandomLanguageCheckbox.CheckedChanged += new System.EventHandler(this.RandomLanguageCheckbox_CheckedChanged);
			// 
			// LanguageCombo
			// 
			this.LanguageCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LanguageCombo.FormattingEnabled = true;
			this.LanguageCombo.Location = new System.Drawing.Point(155, 67);
			this.LanguageCombo.Name = "LanguageCombo";
			this.LanguageCombo.Size = new System.Drawing.Size(160, 21);
			this.LanguageCombo.TabIndex = 5;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(326, 111);
			this.Controls.Add(this.LanguageCombo);
			this.Controls.Add(this.RandomLanguageCheckbox);
			this.Controls.Add(this.NumWordsTrackbar);
			this.Controls.Add(this.NumWordsLabel);
			this.Controls.Add(this.GenerateButton);
			this.Controls.Add(this.PassphraseText);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Main";
			this.Text = "Diceware Password Generator";
			this.Load += new System.EventHandler(this.Main_Load);
			((System.ComponentModel.ISupportInitialize)(this.NumWordsTrackbar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox PassphraseText;
		private System.Windows.Forms.Button GenerateButton;
		private System.Windows.Forms.Label NumWordsLabel;
		private System.Windows.Forms.TrackBar NumWordsTrackbar;
		private System.Windows.Forms.CheckBox RandomLanguageCheckbox;
		private System.Windows.Forms.ComboBox LanguageCombo;
	}
}