using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Zats_HW4
{
	class Program
	{
		static void Main(string[] args)
		{
			var timer = new Stopwatch();

			BTree<int> NewBTree = new BTree<int>();

			List<int> list = new List<int> { 999, 0, 2, 4 ,6 ,8 ,10 ,9, 7 ,5 ,3 ,1 };

			NewBTree.Add(list);

			Console.WriteLine("Tree:");

			NewBTree.PrintTree();

			Console.WriteLine("After searching:");
			try
			{
				timer.Start();

				NewBTree.Search(4);	//Searching

				timer.Stop();

				Console.WriteLine($@"Time:"+timer.Elapsed);
			}
			catch (Exception ex)
			{

				Console.WriteLine("Error:" + ex.Message);
			}
			
		}
	}
}
