using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Race
{
	class PrintRaceInfo
	{
		public static void PrintingStartScreen(List<Car> teams)
		{
			Console.WriteLine("Racers info");
			Console.WriteLine("==================================================================");

			foreach (var team in teams)
			{
				team.PrintInfo();
				Console.WriteLine("==================================================================");
			}

			Console.Write("Press any key to start...");
		}

		public static void PrintingReversCounting()
		{
			Console.Clear();
			Console.WriteLine("=============3==============");
			Thread.Sleep(1000);
			Console.WriteLine("=============2==============");
			Thread.Sleep(1000);
			Console.WriteLine("=============1==============");
			Thread.Sleep(1000);
			Console.WriteLine("===========START============");
			Thread.Sleep(1000);
		}

		public static void PrintingTeamRaceInfo(Car team, double distance)
		{
			Console.SetCursorPosition(0, team.Position);
			Console.Write($"Team: {team.TeamName} --- Speed: {Math.Round(team.Speed, 2)} --- Left: {distance} \n");
			Console.SetCursorPosition(0, 10);
		}
	}
}
