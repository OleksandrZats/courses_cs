using System;

namespace Zats_HW_Flowers
{
	class Bouquet
	{
		public int Cost;

		public Flower[] Flowers;

		public Bouquet(params Flower[] _Flowers)
		{
			this.Flowers = _Flowers;

			foreach (var item in Flowers)
			{
				Cost += item.Price;
			}
		}

		public void BouqetInfo()
		{
			foreach (var item in Flowers)
			{
				Console.WriteLine($"{item.Name} {item.Colour}");
			}
			Console.WriteLine($"Total cost: {Cost}");
		}
		
	}
}
