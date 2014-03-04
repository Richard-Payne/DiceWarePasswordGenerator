using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using IO = System.IO;
using System.Diagnostics;

namespace DiceWarePasswordGenerator
{
	public static class PasswordGenerator
	{
		private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

		public static string WordListPath { get; set; }

		public static string Generate(int numWords, string wordListFile)
		{
			if (wordListFile == null)
				throw new ArgumentNullException("wordListFile");
			if ("".Equals(wordListFile))
				throw new ArgumentException("Blank Language File");
			if (numWords < 1)
				throw new ArgumentOutOfRangeException("numWords", "Number of Word must be greater than zero!");

			// If * is passed in, choose a random language
			if ("*".Equals(wordListFile))
			{
				// Choose word list at random	
				IEnumerable<string> wordListFiles = IO.Directory.EnumerateFiles(WordListPath);
				wordListFile = wordListFiles.ElementAt(RollDice((byte)wordListFiles.Count()) - 1);
			} 
			else
			{
				wordListFile += ".txt";
			}			

			// Generate the word key list
			string[] wordKeys = new string[numWords];
			for (int wordNum = 0; wordNum < numWords; wordNum++)
			{
				// Generate the 5 digit word lookup number
				string wordKey = "";
				for (int digit = 0; digit < 5; digit++)
				{
					wordKey += RollDice(6).ToString("0");
				}
				wordKeys[wordNum] = wordKey;
			}


			// Read in the words fromt the list file
			string[] words = new string[numWords];
			IO.TextReader reader = new IO.StreamReader(new IO.FileStream(IO.Path.Combine(WordListPath, wordListFile), IO.FileMode.Open, IO.FileAccess.Read));
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				string[] parts = line.Split('\t');
				if (parts.Count() == 2)
				{
					// Find the matching word from the list	
					for (int wordNum = 0; wordNum < wordKeys.Length; wordNum++)
					{
						if (parts[0].Equals(wordKeys[wordNum]))
						{
							words[wordNum] = parts[1];
						}
					}
				}
			}

			return string.Join(" ", words);
		}

		// This method simulates a roll of the dice. The input parameter is the 
		// number of sides of the dice. 
		private static byte RollDice(byte numberSides)
		{
			if (numberSides <= 0)
				throw new ArgumentOutOfRangeException("numberSides");

			// Create a byte array to hold the random value. 
			byte[] randomNumber = new byte[1];
			do
			{
				// Fill the array with a random value.
				rngCsp.GetBytes(randomNumber);
			}
			while (!IsFairRoll(randomNumber[0], numberSides));
			// Return the random number mod the number 
			// of sides.  The possible values are zero- 
			// based, so we add one. 
			return (byte)((randomNumber[0] % numberSides) + 1);
		}

		private static bool IsFairRoll(byte roll, byte numSides)
		{
			// There are MaxValue / numSides full sets of numbers that can come up 
			// in a single byte.  For instance, if we have a 6 sided die, there are 
			// 42 full sets of 1-6 that come up.  The 43rd set is incomplete. 
			int fullSetsOfValues = Byte.MaxValue / numSides;

			// If the roll is within this range of fair values, then we let it continue. 
			// In the 6 sided die case, a roll between 0 and 251 is allowed.  (We use 
			// < rather than <= since the = portion allows through an extra 0 value). 
			// 252 through 255 would provide an extra 0, 1, 2, 3 so they are not fair 
			// to use. 
			return roll < numSides * fullSetsOfValues;
		}
	}
}
