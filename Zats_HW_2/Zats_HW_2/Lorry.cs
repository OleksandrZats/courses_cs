namespace Zats_HW_2
{
	class Lorry:Car
	{
		public int CarryCapacity;

		public Lorry(string _Mark, int _Weight, int _Power , int _carryCapacity) : base(_Mark, _Weight, _Power)
		{
			this.CarryCapacity = _carryCapacity;
		}

		public void setMark(string _Mark)
		{
			base.Mark = _Mark;
		}

		public void setCarryCappacity(int _CarryCapacity)
		{
			this.CarryCapacity = _CarryCapacity;
		}
	}
}
