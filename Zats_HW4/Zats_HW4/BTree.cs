using System;
using System.Collections.Generic;

namespace Zats_HW4
{
	class BTree<T> where T : IComparable
	{
		public BTreeNode<T> RootNode { get; set; }

		public BTreeNode<T> Add(BTreeNode<T> node, BTreeNode<T> currentNode = null)
		{
			if (RootNode == null)
			{
				node.ParentNode = null;
				return RootNode = node;
			}

			currentNode = currentNode ?? RootNode;
			node.ParentNode = currentNode;

			int result = node.Value.CompareTo(currentNode.Value);

			if (result == 0)
			{
				return currentNode;
			}
			else if (result < 0)
			{
				if (currentNode.LeftNode == null) return currentNode.LeftNode = node;
				else  return Add(node, currentNode.LeftNode);
			}
			else
			{
				if (currentNode.RightNode == null) return currentNode.RightNode = node;
				else return Add(node, currentNode.RightNode);
			}
		}

		public BTreeNode<T> Add(T value)
		{
			return Add(new BTreeNode<T>(value));			
		}

		public void Add(List<T> value)
		{
			foreach (var item in value)
			{
				Add(item);
			}
		}

		public void PrintTree()
		{
			PrintTree(RootNode);
		}

		private void PrintTree(BTreeNode<T> startNode, string indent = "", Side? side = null)
		{
			if (startNode != null)
			{
				var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
				Console.WriteLine($"{indent} {nodeSide}||{startNode.Value}");
				indent += new string(' ', 3);
				//рекурсивный вызов для левой и правой веток
				PrintTree(startNode.LeftNode, indent, Side.Left);
				PrintTree(startNode.RightNode, indent, Side.Right);
			}
		}
		// поиск
		public BTreeNode<T> FindNode(T value, BTreeNode<T> startWithNode = null)
		{
			startWithNode = startWithNode ?? RootNode;
			int result = value.CompareTo(startWithNode.Value);
			
			if (result == 0)
			{
				return startWithNode;
			}
			else if (result < 0)
			{
				if (startWithNode.LeftNode == null)
				{
					return null;
				}
				else
				{
					return FindNode(value, startWithNode.LeftNode);
				}

			}
			else
			{
				if (startWithNode.RightNode == null)
				{
					return null;
				}
				else
				{
					return FindNode(value, startWithNode.RightNode);
				}
			}
		}

		public void Search(T value)
		{
			BTreeNode<T> Node = FindNode(value);
			if (Node == null) { throw new Exception(); }
			else { PrintTree(Node);}
		}

	}
}
