namespace Zats_HW_Flowers
{
	class Program
	{
		static void Main(string[] args)
		{
			var Flower1 = new Iris("Pink", 20);
			var Flower2 = new Pion("Red", 22);
			var Flower3 = new Rose("Pink", 78);
			var Flower4 = new Iris("Blue", 23);
			var Flower5 = new Scaevola("Blue", 67);

			var Bouquet = new Bouquet(Flower1, Flower2, Flower3, Flower4, Flower5);

			System.Console.WriteLine("Bouquet information");

			Bouquet.BouqetInfo();
		}
	}
}
