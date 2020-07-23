using System;

namespace Zats_HW3
{
	class StringParsing
	{
		public static string[] Parsing(string expresion)
		{
			if (expresion.EndsWith("*")
			    || expresion.EndsWith("/")
			    || expresion.EndsWith("-")
			    || expresion.EndsWith("+")
			    || expresion.Contains("*-")
			    || expresion.Contains("/-"))
			{
				Console.WriteLine();
				throw new FormatException();
			}

			string tempString = null;
			int counter = Array
				.FindAll<char>(expresion.ToCharArray(), a => a == '*' || a == '/' || a == '+' || a == '-').Length;
			if (expresion.Contains("+-") || expresion.Contains("--"))
			{
				expresion = expresion.Replace("+-", "+0-");
				expresion = expresion.Replace("--", "-0-");
			}

			if (expresion.StartsWith("-")) expresion = "0" + expresion;
			var operArr = new string[(counter * 2) + 1];

			counter = 0;

			foreach (var item in expresion)
			{
				if (item != '+' && item != '-' && item != '*' && item != '/')
				{
					tempString += item;
				}
				else
				{
					operArr[counter++] = tempString;

					tempString = null;

					operArr[counter++] = item.ToString();
				}

				operArr[counter] = tempString;
			}

			return operArr;
		}
	}
}