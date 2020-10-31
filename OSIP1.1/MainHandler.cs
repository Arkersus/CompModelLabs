using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIP1._1
{
  
    class MainHandler
    {
		static public Graph SymbolicImage(Configuration config, BackgroundWorker worker = null)
		{
			Graph g = new Graph(config.gridScale * config.gridScale);
			decimal scale = 4.0m / config.gridScale;
			decimal step = scale / (decimal)Math.Sqrt(config.points);

			int n = 0;
			for (decimal y = 2.0m; y > -2.0m; y -= scale)
				for (decimal x = -2.0m; x < 2.0m; x += scale)
				{
					for (decimal j = y; j > y - scale; j -= step)
						for (decimal i = x; i < x + scale; i += step)
						{
							Point p = new Point(i, j);
							p = calc(p);
							if (p.x >= -2.0m && p.x < 2.0m && p.y > -2.0m && p.y <= 2.0m)
							{
								int cell = GetCell(p);
								if (!g.HasVertex(n, cell))
									g.AddVertex(n, cell);
							}
						}
					n++;
					if(worker != null)
						worker.ReportProgress(0);
				}
			return g;

			Point calc(Point p)
			{
				Point new_point = new Point();
				new_point.x = p.x * p.x - p.y * p.y - 0.8m;
				new_point.y = 2 * p.x * p.y + 0.2m;
				return new_point;
			}

			int GetCell(Point p)
			{
				decimal a = ((p.x + 2.0m) / scale);
				decimal b = -(p.y - 2.0m) / scale;
				return (int)a + (int)b * config.gridScale;
			}
		}


		//static public List<int[]> StrongComp(Graph symb, Configuration cfg)
  //      {
		//	//var symb = new Graph(5);
		//	//symb.graph_array[0].Add(2);
		//	//symb.graph_array[0].Add(3);
		//	//symb.graph_array[1].Add(0);
		//	//symb.graph_array[2].Add(1);
		//	//symb.graph_array[3].Add(4);


		//	var comp_array = new List<int[]>();
		//	var symb_tr = new Graph(symb.size);
		//	var order = new List<int>();
		//	var component = new List<int>();
		//	var used = new bool[symb.size];

		//	for (int i = 0; i < symb.size; i++)
  //          {
		//		foreach(int j in symb[i])
		//			symb_tr[j].Add(i);
  //          }

		//	for (int i = 0; i < symb.size; i++)
		//		if (!used[i])
		//			GetOrder(i);

		//	for (int i = 0; i < symb.size; i++)
		//		used[i] = false;

		//	for (int i = 0; i < symb.size; i++)
  //          {
		//		int j = order[symb.size - i - 1];
		//		if(!used[j])
  //              {
		//			GetComponent(j);
		//			var copy = new int[component.Count];
		//			component.CopyTo(copy);
		//			if (copy.Length > 1)
		//				comp_array.Add(copy);
		//			component.Clear();
		//		}
  //          }

		//	return comp_array;


		//	void GetOrder(int node)
  //          {
		//		used[node] = true;
		//		foreach (int i in symb[node])
		//			if (!used[i])
		//				GetOrder(i);
		//		order.Add(node);
		//	}

		//	void GetComponent(int node)
  //          {
		//		used[node] = true;
		//		component.Add(node);
		//		foreach (int i in symb_tr[node])
		//			if (!used[i])
		//				GetComponent(i);
		//	}

		//}

		static public List<int[]> Localize(List<int[]> comps)
        {

			return comps;
        }



	}
    
}
