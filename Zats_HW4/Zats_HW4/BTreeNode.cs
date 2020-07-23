using System;

namespace Zats_HW4
{
	enum Side
	{
		Left,
		Right
	}
	class BTreeNode<T> where T : IComparable
	{
		public T Value { get; set; }
		public BTreeNode(T value)
		{
			this.Value = value;
		}
		public BTreeNode<T> LeftNode { get; set; }
		public BTreeNode<T> RightNode { get; set; }
		public BTreeNode<T> ParentNode { get; set; }

		public Side? NodeSide
		{
			get
			{				
				if (ParentNode == null)
				{
					return null;
				}
				else
				{
					if (ParentNode.LeftNode == this)
					{
						return Side.Left;
					}
					else
					{
						return Side.Right;
					}
				}
			}
		}
	}
}
