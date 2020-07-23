using System;

namespace Zats_HW5
{
	class Program
	{
		static void Main(string[] args)
		{
			var rnd = new Random();
			int[] temp = new int[]{1, 2, 3 ,4, 5 ,6, 7, 8,325 ,24136,5246};
			//for (int i = 0; i < temp.Length; i++)
			//{
			//	temp[i] = rnd.Next(1,10);
			//}
			Console.WriteLine();
			IntCollection coll = new IntCollection(temp);

			foreach (var item in coll)
			{
				Console.WriteLine(item);
			}

		}
	}
}
