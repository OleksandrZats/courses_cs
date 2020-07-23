using System;

namespace Zats_HW_2
{
	class Program
	{
		static void Main(string[] args)
		{
			var car1 = new Car("BMW", 100, 700);
			var lorry1 = new Lorry("Tesla", 400, 500, 3000);

			Console.WriteLine($"{car1.Mark} {car1.Power}л.с. {car1.Weight}кг");
			Console.WriteLine($"{lorry1.Mark} {lorry1.Power}л.с. {lorry1.Weight}кг грузоподъемность:{lorry1.CarryCapacity}");

			car1.setPower(800);

			Console.WriteLine($"{car1.Mark} {car1.Power}л.с. {car1.Weight}кг");

			lorry1.setMark("Nissan");
			lorry1.setCarryCappacity(5000);

			Console.WriteLine($"{lorry1.Mark} {lorry1.Power}л.с. {lorry1.Weight}кг грузоподъемность:{lorry1.CarryCapacity}");


		}
	}
}
