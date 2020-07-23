using System.Collections;

namespace Zats_HW5
{
	class IntCollection : IEnumerable
	{
		private int[] value;

		public IntCollection(int[] value)
		{
			this.value = value;
		}
						
		public IEnumerator GetEnumerator()
		{
			return new NewIterator(value);
		}
		
	}
}
