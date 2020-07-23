namespace Zats_HW_Flowers
{
	class Flower
	{
		public string Name { get; set; }
		public string Colour { get; set; }
		public int Price { get; set; }

		public Flower(string _name, string _colour, int _prise)
		{
			this.Name = _name;
			this.Colour = _colour;
			this.Price = _prise;
		}
	}
}
