using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace OSIP1._1
{
    public class Graph : IEnumerable
	{
		//private List<int>[] graph_array;
		private ConcurrentDictionary<int, List<int>> graph_dict;
		private int size;

		public Graph(int _size)
		{
			size = _size;
			graph_dict = new ConcurrentDictionary<int, List<int>>();
			//graph_array = new List<int>[_grid];
			//for (int i = 0; i < grid; i++)
			//	graph_array[i] = new List<int>();
		}

		public List<int> this[int i]
		{
			//get => graph_array[i];
			//set => graph_array[i] = value;

			get
            {
				if (graph_dict.ContainsKey(i))
					return graph_dict[i];
				else
					return new List<int>();
            }
			set
            {
				graph_dict[i] = value;
            }
		}

   //     private class GraphEnumerator : IEnumerator
   //     {
			//KeyValuePair<int, List<int>>[] items;
   //         int position = -1;

   //         public GraphEnumerator(ConcurrentDictionary<int, List<int>> graph)
   //         {
			//	items = new KeyValuePair<int, List<int>>[graph.Count];
			//	int n = 0;
			//	foreach(var i in graph)
   //             {
			//		items[n] = i;
			//		n++;
   //             }

   //         }
   //         private IEnumerator getEnumerator()
   //         {
   //             return (IEnumerator)this;
   //         }
   //         public bool MoveNext()
   //         {
   //             position++;
   //             return (position < items.Length);
   //         }
   //         public void Reset()
   //         {
   //             position = -1;
   //         }
   //         public object Current
   //         {
   //             get
   //             {
   //                 try
   //                 {
   //                     return new NodeUnit(items[position].Key, items[position].Value);
   //                 }
   //                 catch (IndexOutOfRangeException)
   //                 {
   //                     throw new InvalidOperationException();
   //                 }
   //             }
   //         }
   //     }

        public IEnumerator GetEnumerator()
        {
			return graph_dict.GetEnumerator();
        }

		public List<int[]> FindStrongComps(int gridScale)
		{
			Graph symb = this;
			var symb_tr = new Graph(symb.Size);

			var order = new List<int>();
			var component = new List<int>();
			var used = new bool[gridScale * gridScale];
			var comp_array = new List<int[]>();

			for (int i = 0; i < used.Length; i++)
				used[i] = false;

			foreach (KeyValuePair<int, List<int>> i in symb)
				foreach (int j in i.Value)
					symb_tr.AddVertex(j, i.Key);

			foreach (KeyValuePair<int, List<int>> i in symb)
					if (!used[i.Key])
						GetOrder(i.Key);

			for (int i = 0; i < used.Length; i++)
				used[i] = false;

			for (int i = order.Count - 1; i >= 0; i--)
			{
				int j = order[i];
				if (!used[j])
				{
					GetComponent(j);
					var copy = new int[component.Count];
					component.CopyTo(copy);
					if (copy.Length > 1)
						comp_array.Add(copy);
					component.Clear();
				}
			}

			return comp_array;


			void GetOrder(int node)
			{
				used[node] = true;
				foreach (int i in symb[node])
					if (!used[i])
						GetOrder(i);
				order.Add(node);
			}

			void GetComponent(int node)
			{
				used[node] = true;
				component.Add(node);
				foreach (int i in symb_tr[node])
					if (!used[i])
						GetComponent(i);
			}
		}

		#region GraphMethods
		public bool HasVertex(int i, int j)
        {
			return this[i].Contains(j);
		}

		public void AddVertex(int i, int j)
        {
			//graph_array[i].Add(j);
			if (graph_dict.ContainsKey(i))
			{
				if (!graph_dict[i].Contains(j))
					graph_dict[i].Add(j);
			}
            else
            {
				var tmp = new List<int>();
				tmp.Add(j);
				graph_dict[i] = tmp;
            }
		}

		public long GetVnum()
		{
			long n = 0;
			foreach (var node in graph_dict)
			{
				n += (long)node.Value.Count();
			}
			return n;
		}

		public int Size
        {
			get { return size; }
        }
        #endregion
    };
}
