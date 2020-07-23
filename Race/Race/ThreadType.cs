using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race
{
	class ThreadType
	{
		public double Distance { get; set; }
		public Car Car { get; set; }

		public ThreadType(Car car, double distance)
		{
			this.Car = car;
			this.Distance = distance;
		}
	}
}
