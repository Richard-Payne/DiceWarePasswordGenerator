using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace DiceWarePasswordGenerator
{
	class Program
	{			
		public static string WordListPath
		{
			get { return Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "WordLists"); }
		}

		static void Main(string[] args)
		{
			int numWords = 4;
			string wordListFile = "English";		
			string curArg = "";

			try
			{
				foreach (string arg in args)
				{
					curArg = arg;

					// length arg is number of words in phrase
					if (arg.StartsWith("/length:", StringComparison.OrdinalIgnoreCase))
					{
						numWords = Int16.Parse(arg.Substring(8));
					}
					// multi-lang allows for a randomly choosen word file
					else if (arg.StartsWith("/lang:", StringComparison.OrdinalIgnoreCase))
					{
						if (arg.Length == 6)
							throw new ArgumentException();

						wordListFile = arg.Substring(6);
					}
					else
					{
						throw new ArgumentException();
					}
				}
			}
			catch
			{
				Console.WriteLine("Invalid Parameter: " + curArg);
				Console.WriteLine(GetUsage(Console.BufferWidth));
				return;
			}

			PasswordGenerator.WordListPath = WordListPath;
			Console.WriteLine(PasswordGenerator.Generate(numWords, wordListFile));
		}

		public static string GetUsage(int lineLength)
		{
			string[] lines = new string[] {				
				"Usage:",
				"\tdicepassgen [/length:<x>]",
				"\t            [/lang:<*|y>]",
				""
			};
			lines = lines.Concat(SplitLine("length:", 8, lineLength, "x is the number of randomly chosen words to comprise the password. Defaults to 4."))
						 .Concat(new string[] { "" })
						 .Concat(SplitLine("lang:", 8, lineLength, "Specifies the language file to use. Use the filename (without extension) of a file in the WordLists folder.  Alternatively, use '*' to randomly chose a language. Defaults to English."))
						 .Concat(new string[] { "" })
					     .ToArray();
			
			
			return string.Join(Environment.NewLine, lines);			
		}

		private static string[] SplitLine(string param, int paramLen, int lineLength, string description)
		{
			List<string> chunks = new List<string>();

			param = param.SafeSubString(0, paramLen - 1).PadRight(paramLen);

			foreach (string chunk in SplitStringFixed(description, lineLength - param.Length))
			{
				chunks.Add(param + chunk.TrimStart());
				param = new string(' ', param.Length);
			}

			return chunks.ToArray();
		}

		static IEnumerable<string> SplitStringFixed(string str, int chunkSize)
		{
			int iPos = 0;
			while (iPos < str.Length)
			{
				// Get next chunk
				string chunk = str.SafeSubString(iPos, chunkSize);
				if (iPos + chunk.Length < str.Length)
				{
					// Search back for the last word boundary
					chunk = chunk.Substring(0, chunk.LastIndexOf(' '));
				}
				iPos += chunk.Length;

				yield return chunk;
			}
		}
	}
}
