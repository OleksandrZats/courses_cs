using System;
using System.Collections.Generic;
using System.Threading;

namespace Race
{
	class Program
	{
		private static object locker = new object();
		static void Main(string[] args)
		{
			const int raceDistance = 10340;
			var rnd = new Random();
			Car winer = null;
			Car redBullCar = new Car("Red Bull", rnd, 1); 
			Car brawnGpCar = new Car("Brawn GP", rnd,2); 
			Car mcLarenCar = new Car("McLaren", rnd,3); 
			Car mercedesCar = new Car("Mercedes", rnd,4); 
			Car renaultCar = new Car("Renault", rnd,5); 
			Car williamsCar = new Car("Williams", rnd,6); 
			Car bmwCar = new Car("BMW", rnd,7); 
			Car ferrariCar = new Car("Ferrari", rnd,8);

			List<Car> teams = new List<Car>()
			{
				redBullCar, brawnGpCar, mcLarenCar,
				mercedesCar, renaultCar, williamsCar,
				bmwCar, ferrariCar
			};
			
			List<ThreadType> teamInfo = new List<ThreadType>();

			foreach (var team in teams)
			{
				teamInfo.Add(new ThreadType(team, raceDistance));
			}

			PrintRaceInfo.PrintingStartScreen(teams);
			Console.ReadKey();
			PrintRaceInfo.PrintingReversCounting();
			Console.Clear();

			for (int i = raceDistance; i>0; i-=250)
			{
				Thread.Sleep(1000);
				Console.Clear();
				foreach (var car in teamInfo)
				{
					new Thread(new ParameterizedThreadStart(Race)).Start(car);
				}
				if (FindMin(teamInfo).Distance<=0)
				{
					winer = FindMin(teamInfo).Car;
					break;
				}
			}

			Console.Clear();
			Console.SetCursorPosition(0, 0);
			if (winer != null) Console.WriteLine($"Winer is {winer.TeamName}");
			Console.ReadKey();

		}
		public static void Race(object _info)
		{
			lock (locker)
			{

				ThreadType info = (ThreadType) _info;

				if (info.Car.TimeInRace < 4)
				{
					info.Car.AccSpeed();
				}
				else
				{
					info.Car.ChangingSpeed();
				}

				info.Distance = info.Distance - info.Car.Speed;
				info.Car.TimeInRace++;
				
				if (info.Distance > 0)
				{
					PrintRaceInfo.PrintingTeamRaceInfo(info.Car, Math.Round(info.Distance, 2));
				}
				else
				{
					PrintRaceInfo.PrintingTeamRaceInfo(info.Car, 0);
				}
			}
		}
		public static ThreadType FindMin(List<ThreadType> list)
		{
			ThreadType temp = list[0];

			foreach (var element in list)
			{
				if (element.Distance < temp.Distance)
				{
					temp = element;
				}
			}

			return temp;
		}
	}
}
