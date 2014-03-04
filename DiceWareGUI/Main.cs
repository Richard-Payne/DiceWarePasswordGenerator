using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DiceWarePasswordGenerator
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			PasswordGenerator.WordListPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "WordLists");

			// Fill in the language combo
			IEnumerable<string> wordListFiles = Directory.EnumerateFiles(PasswordGenerator.WordListPath)
													.Select(s => Path.GetFileNameWithoutExtension(s));
			LanguageCombo.Items.AddRange(wordListFiles.ToArray());
			// Default to English
			LanguageCombo.SelectedIndex = LanguageCombo.Items.IndexOf("English");

			// Default the number of words
			NumWordsTrackbar.Value = 4;

			// Run the generator
			GenerateButton_Click(GenerateButton, null);
		}

		private void GenerateButton_Click(object sender, EventArgs e)
		{
			PassphraseText.Text = PasswordGenerator.Generate(NumWordsTrackbar.Value, RandomLanguageCheckbox.Checked ? "*" : LanguageCombo.Text);
		}

		private void RandomLanguageCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			LanguageCombo.Enabled = !RandomLanguageCheckbox.Checked;
		}
	}
}
