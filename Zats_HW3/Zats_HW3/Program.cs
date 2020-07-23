using System;

namespace Zats_HW3
{
	class Program
	{
		delegate string CalculateDelegate(string Expresion);

		delegate string AnonimMethodCalculateDelegate(string Expresion);

		delegate string LambdaCalculateDelegate(string Expresion);

		static void Main(string[] args)
		{
			string fullExpresion = null;
			char tempChar;

			CalculateDelegate Calc = Calculation;

			AnonimMethodCalculateDelegate AnonimMethodCalc = delegate(string Expresion)
			{
				if (Expresion.Contains("/") | Expresion.Contains("*"))
				{
					throw new FormatException();
				}

				double tempSolution;
				string tempString = null;

				string[] parsedExpresion = StringParsing.Parsing(Expresion);
				int count = Array.FindAll<string>(parsedExpresion, a => a == "+" || a == "-").Length;

				for (int i = 0; i < count; i++)
				{
					parsedExpresion = StringParsing.Parsing(Expresion);
					for (int j = 0; j < parsedExpresion.Length; j++)
					{
						if (parsedExpresion[j] == "+")
						{
							tempString = null;
							tempSolution = Convert.ToDouble(parsedExpresion[j - 1]) *
							               Convert.ToDouble(parsedExpresion[j + 1]);
							parsedExpresion[j - 1] = tempSolution.ToString();
							parsedExpresion[j] = "";
							parsedExpresion[j + 1] = "";
							foreach (var item in parsedExpresion)
							{
								tempString += item;
							}

							break;
						}
						else if (parsedExpresion[j] == "-")
						{
							tempString = null;
							tempSolution = Convert.ToDouble(parsedExpresion[j - 1]) /
							               Convert.ToDouble(parsedExpresion[j + 1]);
							parsedExpresion[j - 1] = tempSolution.ToString();
							parsedExpresion[j] = "";
							parsedExpresion[j + 1] = "";
							foreach (var item in parsedExpresion)
							{
								tempString += item;
							}

							break;
						}
					}

					Expresion = tempString;
				}

				return Expresion;
			};

			LambdaCalculateDelegate LambdaCalc = Expresion =>
			{
				if (Expresion.Contains("+") | Expresion.Contains("-"))
				{
					throw new FormatException();
				}

				double tempSolution;
				string tempString = null;

				string[] parsedExpresion = StringParsing.Parsing(Expresion);
				int count = Array.FindAll<string>(parsedExpresion, a => a == "*" || a == "/").Length;

				for (int i = 0; i < count; i++)
				{
					if (Expresion.Contains("/0"))
					{
						Console.WriteLine("Деление на ноль");
						throw new FormatException();
					}

					parsedExpresion = StringParsing.Parsing(Expresion);
					for (int j = 0; j < parsedExpresion.Length; j++)
					{
						if (parsedExpresion[j] == "*")
						{
							tempString = null;
							tempSolution = Convert.ToDouble(parsedExpresion[j - 1]) *
							               Convert.ToDouble(parsedExpresion[j + 1]);
							parsedExpresion[j - 1] = tempSolution.ToString();
							parsedExpresion[j] = "";
							parsedExpresion[j + 1] = "";
							foreach (var item in parsedExpresion)
							{
								tempString += item;
							}

							break;
						}
						else if (parsedExpresion[j] == "/")
						{
							tempString = null;
							tempSolution = Convert.ToDouble(parsedExpresion[j - 1]) /
							               Convert.ToDouble(parsedExpresion[j + 1]);
							parsedExpresion[j - 1] = tempSolution.ToString();
							parsedExpresion[j] = "";
							parsedExpresion[j + 1] = "";
							foreach (var item in parsedExpresion)
							{
								tempString += item;
							}

							break;
						}
					}

					Expresion = tempString;
				}

				return Expresion;
			};

			Console.WriteLine(" Введите выражение с +,-,*,/");

			for (;;)
			{
				try
				{
					tempChar = Console.ReadKey().KeyChar;
					if (tempChar == '=')
					{
						Console.Write(Convert.ToDouble(Calc(fullExpresion)));
						break;
					}
					else
					{
						fullExpresion += tempChar;
					}
				}
				catch (Exception ex)
				{
					if (ex is FormatException || ex is NullReferenceException)
					{
						fullExpresion = null;
						Console.WriteLine("\n Не коректное условие. Введите повторно: ");
					}
				}
			}

			fullExpresion = null;
			Console.WriteLine("\n Введите выражение с +,-");

			for (;;)
			{
				try
				{
					tempChar = Console.ReadKey().KeyChar;
					if (tempChar == '=')
					{
						Console.Write(Convert.ToDouble(AnonimMethodCalc(fullExpresion)));
						break;
					}
					else
					{
						fullExpresion += tempChar;
					}
				}
				catch (Exception ex)
				{
					if (ex is FormatException || ex is NullReferenceException)
					{
						fullExpresion = null;
						Console.WriteLine("\n Не коректное условие. Введите повторно: ");
					}
				}
			}

			fullExpresion = null;
			Console.WriteLine("\n Введите выражение с *,/");

			for (;;)
			{
				try
				{
					tempChar = Console.ReadKey().KeyChar;
					if (tempChar == '=')
					{
						Console.Write(Convert.ToDouble(LambdaCalc(fullExpresion)));
						break;
					}
					else
					{
						fullExpresion += tempChar;
					}
				}
				catch (Exception ex)
				{
					if (ex is FormatException || ex is NullReferenceException)
					{
						fullExpresion = null;
						Console.WriteLine("\n Не коректное условие. Введите повторно: ");
					}
				}
			}

			Console.ReadLine();
		}


		private static string Calculation(string Expresion)
		{
			double tempSolution;
			string tempString = null;

			string[] parsedExpresion = StringParsing.Parsing(Expresion);
			int count = Array.FindAll<string>(parsedExpresion, a => a == "*" || a == "/").Length;

			for (int i = 0; i < count; i++)
			{
				parsedExpresion = StringParsing.Parsing(Expresion);
				for (int j = 0; j < parsedExpresion.Length; j++)
				{
					if (Expresion.Contains("/0"))
					{
						Console.WriteLine(" Деление на ноль");
						throw new FormatException();
					}

					if (parsedExpresion[j] == "*")
					{
						tempString = null;
						tempSolution = Convert.ToDouble(parsedExpresion[j - 1]) *
						               Convert.ToDouble(parsedExpresion[j + 1]);
						parsedExpresion[j - 1] = tempSolution.ToString();
						parsedExpresion[j] = "";
						parsedExpresion[j + 1] = "";
						foreach (var item in parsedExpresion)
						{
							tempString += item;
						}

						break;
					}
					else if (parsedExpresion[j] == "/")
					{
						tempString = null;
						tempSolution = Convert.ToDouble(parsedExpresion[j - 1]) /
						               Convert.ToDouble(parsedExpresion[j + 1]);
						parsedExpresion[j - 1] = tempSolution.ToString();
						parsedExpresion[j] = "";
						parsedExpresion[j + 1] = "";
						foreach (var item in parsedExpresion)
						{
							tempString += item;
						}

						break;
					}
				}

				Expresion = tempString;
			}

			count = Array.FindAll<string>(parsedExpresion, a => a == "+" || a == "-").Length;

			for (int i = 0; i < count; i++)
			{
				parsedExpresion = StringParsing.Parsing(Expresion);
				for (int j = 0; j < parsedExpresion.Length; j++)
				{
					if (parsedExpresion[j] == "+")
					{
						tempString = null;
						tempSolution = Convert.ToDouble(parsedExpresion[j - 1]) +
						               Convert.ToDouble(parsedExpresion[j + 1]);
						parsedExpresion[j - 1] = tempSolution.ToString();
						parsedExpresion[j] = "";
						parsedExpresion[j + 1] = "";
						foreach (var item in parsedExpresion)
						{
							tempString += item;
						}

						break;
					}
					else if (parsedExpresion[j] == "-")
					{
						tempString = null;
						tempSolution = Convert.ToDouble(parsedExpresion[j - 1]) -
						               Convert.ToDouble(parsedExpresion[j + 1]);
						parsedExpresion[j - 1] = tempSolution.ToString();
						parsedExpresion[j] = "";
						parsedExpresion[j + 1] = "";
						foreach (var item in parsedExpresion)
						{
							tempString += item;
						}

						break;
					}
				}

				Expresion = tempString;
			}

			return Expresion;
		}
	}
}