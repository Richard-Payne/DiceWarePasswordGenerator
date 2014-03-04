using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceWarePasswordGenerator
{
	public static class StringExtensions
	{
		public static string SafeSubString(this string str, int start, int length)
		{
			return str.Substring(start, (int)Math.Min(length, str.Length - start));
		}
	}
}
