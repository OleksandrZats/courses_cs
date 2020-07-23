using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Race
{
	class Car
	{
		public const double MAX_SPEED = 372.6;
		public const int AccelerationToAverageSpeed = 3;
		
		public string TeamName { get; set; }
		public double AverageSpeed { get; set; }
		public double Speed { get; set; }
		public int TimeInRace { get; set; }
		public Random Rnd { get; set; }
		public int Position { get; set; }

		public Car(string teamName, Random rnd, int position)
		{
			this.Position = position;
			this.Rnd = rnd;
			this.TeamName = teamName;
			
			this.AverageSpeed = rnd.Next(0,100)<76 ? rnd.Next(250, 260) : rnd.Next(261, 270);
		}
		
		public void PrintInfo()
		{
			Console.WriteLine($"Team name: {TeamName}");
			Console.WriteLine($"Car average speed: {this.AverageSpeed}");
		}
		
		public void AccSpeed()
		{
			Speed += AverageSpeed / AccelerationToAverageSpeed;
		}
		public void ChangingSpeed()
		{
			int percent = this.Rnd.Next(0, 100);
			if (percent<80)
			{
				this.Speed = this.Rnd.Next(250, 320);
			}
			else if (percent==100)
			{
				this.Speed = this.Rnd.Next(360, 370);
			}
			else
			{
				this.Speed = this.Rnd.Next(320, 360);
			}
		}

	}
}
