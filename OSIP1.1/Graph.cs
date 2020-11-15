using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;

namespace OSIP1._1
{
	public class Graph : IEnumerable
	{
		//private List<int>[] graph_array;
		private ConcurrentDictionary<int, List<int>> graphEdges;
		private int graphNodes;

		public Graph()
		{
			graphEdges = new ConcurrentDictionary<int, List<int>>();
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
				if (graphEdges.ContainsKey(i))
					return graphEdges[i];
				else
					return new List<int>();
			}
			set
			{
				graphEdges[i] = value;
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
			return graphEdges.GetEnumerator();
		}

		public List<int[]> FindStrongComps(int gridScale, bool isSort = false)
		{
			Graph symb = this;
			var symb_tr = new Graph();

            //var component = new List<int>();
            //var order = new List<int>();

            var order = TopologicalSort(gridScale);
            var used = new bool[gridScale * gridScale];
			var comp_array = new List<int[]>();

            foreach (KeyValuePair<int, List<int>> i in symb)
                foreach (int j in i.Value)
                    symb_tr.AddVertex(j, i.Key);

			//foreach (KeyValuePair<int, List<int>> i in symb)
			//	if (!used[i.Key])
			//		GetOrder(i.Key);

			//used = new bool[gridScale * gridScale];

			for (int i = order.Count - 1; i >= 0; i--)
            {
				int j = order[i];
				if (!used[j] && symb_tr.Contains(j))
				{
                    var component = GetComponent(j);
                    //GetComponent(j);

                    if (component.Length > 1 || isSort)
                        comp_array.Add(component);
					//if (component.Count > 1 || isSort)
					//    comp_array.Add(component.ToArray());
					//component.Clear();
				}
			}

			return comp_array;

            //void GetComponent(int node)
            //{
            //    used[node] = true;
            //    component.Add(node);
            //    foreach (int i in symb_tr[node])
            //        if (!used[i])
            //            GetComponent(i);
            //}

            //void GetOrder(int node)
            //{
            //    used[node] = true;
            //    foreach (int i in symb[node])
            //        if (!used[i])
            //            GetOrder(i);
            //    order.Add(node);
            //}

            int[] GetComponent(int node)
            {
                var component = new List<int>();

                Stack<int> stack = new Stack<int>();
                stack.Push(node);

                while (stack.Count != 0)
                {
                    int v = stack.Pop();
                    used[v] = true;
                    component.Add(v);

                    foreach (int i in symb_tr[v])
                    {
                        if (!used[i])
                        {
                            stack.Push(i);
                            used[i] = true;
                        }
                    }
                }
                return component.ToArray();
            }





        }




        private List<int> TopologicalSort(int gridScale)
		{
			Graph symb = this;
			var used = new int[gridScale * gridScale];
			var stack = new Stack<int>();
			var order = new List<int>();

			foreach (KeyValuePair<int, List<int>> i in graphEdges)
			{
				if (used[i.Key] == 0)
					stack.Push(i.Key);

				while (stack.Count != 0)
				{
					var v = stack.Peek();

					if (used[v] != 0)
					{
						stack.Pop();
						if(used[v] == 1)
                        {
							order.Add(v);
							used[v] = 2;
                        }
						
					}
					else if (used[v] == 0)
					{
						used[v] = 1;
						foreach (int u in symb[v])
							if (used[u] == 0)
								stack.Push(u);
					}					
				}
			}
			return order;
		}

        #region GraphMethods
        public bool HasVertex(int i, int j)
        {
			return this[i].Contains(j);
		}

		public void AddVertex(int i, int j)
        {
			if (graphEdges.ContainsKey(i))
			{
				if (!graphEdges[i].Contains(j))
				{
					graphEdges[i].Add(j);
				}
			}
            else
            {
				var tmp = new List<int>();
				tmp.Add(j);
				graphEdges[i] = tmp;
			}
		}

		public long GetVnum()
		{
			long n = 0;
			foreach (var node in graphEdges)
			{
				n += (long)node.Value.Count();
			}
			return n;
		}

		public int Count
        {
			get { return graphEdges.Count; }
        }

		public bool Contains(int i)
		{
			return graphEdges.ContainsKey(i);
		}
		#endregion
	};
}
