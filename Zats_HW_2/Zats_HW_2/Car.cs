namespace Zats_HW_2
{
	class Car
	{

		public string Mark;
		public int Weight;
		public int Power;

		public Car(string _Mark, int _Weight, int _Power)
		{
			this.Mark = _Mark;
			this.Weight = _Weight;
			this.Power = _Power;
		}

		public void setPower(int _Power)
		{
			this.Power = _Power;
		}

	}
}
