using System;
using System.Collections;

namespace Zats_HW5
{
	class NewIterator : IEnumerator
	{
		int[] value;
		 
		int position = -1;
		public NewIterator(int[] v)
		{
			this.value = v;
		}
		public object Current
		{
			get
			{
				if (position == -1 || position >= value.Length)
					throw new InvalidOperationException();
				
				return value[position];
				
								
			}
		}
		public bool MoveNext()
		{

			if (position < value.Length-1)
			{
				position++;
				return IsSimple(value[position]) || MoveNext();
			}
			return false;
		}

		public void Reset()
		{
			position = -1;
		}
		public bool IsSimple(int value)
		{
			if (value <= 1) return false;
			if (value == 2) return true;
			if (value % 2 == 0) return false;

			var boundary = (int)Math.Floor(Math.Sqrt(value));

			for (int i = 3; i <= boundary; i += 2)
				if (value % i == 0)
					return false;

			return true;

		}

	}
	
}
