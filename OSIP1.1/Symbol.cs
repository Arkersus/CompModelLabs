using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Concurrent;

namespace OSIP1._1
{
	public class Symbol
	{
		private Graph symbGraph;
		private List<int[]> strongComps;
		private int gridScale;
		private int precision;
		private decimal A, B;
		private decimal cellSize;
		public Symbol(Configuration config, BackgroundWorker worker = null)
		{
			gridScale = config.gridScale;
			precision = (int)Math.Sqrt(config.points);
			A = config.A;
			B = config.B;

			Graph g = new Graph(config.gridScale * config.gridScale);
			cellSize = 4.0m / config.gridScale;
			decimal step = cellSize / precision;

			for (decimal y = 2.0m; y > -2.0m; y -= cellSize)
				for (decimal x = -2.0m; x < 2.0m; x += cellSize)
				{
					int origin = GetCell(new Point(x,y), cellSize);
					for (decimal j = y; j > y - cellSize; j -= step)
						for (decimal i = x; i < x + cellSize; i += step)
						{
							Point p = new Point(i, j);
							p = calc(p);
							if (p.x >= -2.0m && p.x < 2.0m && p.y > -2.0m && p.y <= 2.0m)
							{
								int cell = GetCell(p, cellSize);
								if (!g.HasVertex(origin, cell))
									g.AddVertex(origin, cell);
							}
						}
					if (worker != null)
						worker.ReportProgress(0);
				}
			symbGraph = g;

			

		}

		//public void FindStrongComps()
		//{
		//	Graph symb = symbGraph;
		//	var comp_array = new List<int[]>();
		//	var symb_tr = new Graph(symb.Size);
		//	var order = new List<int>();
		//	var component = new List<int>();
		//	var used = new List<int>();

		//	//for (int i = 0; i < symb.grid; i++)
		//	foreach (NodeUnit i in symb)
		//	{
		//		foreach (int j in i.Vertices)
		//			//symb_tr[j].Add(i);
		//			symb_tr.AddVertex(j, i.Node);
		//	}

		//	for (int i = 0; i < symb.Grid; i++)
		//	{
		//		if (!used.Contains(i))
		//			GetOrder(i);
		//	}

		//	for (int i = 0; i < symb.Grid; i++)
		//		used[i] = false;

		//	for (int i = 0; i < symb.Grid; i++)
		//	{
		//		int j = order[symb.Grid - i - 1];
		//		if (!used.Contains(i))
		//		{
		//			GetComponent(j);
		//			var copy = new int[component.Count];
		//			component.CopyTo(copy);
		//			if (copy.Length > 1)
		//				comp_array.Add(copy);
		//			component.Clear();
		//		}
		//	}

		//	strongComps = comp_array;


		//	void GetOrder(int node)
		//	{
		//		used.Add(node);
		//		foreach (int i in symb[node])
		//			if (!used.Contains(i))
		//				GetOrder(i);
		//		order.Add(node);
		//	}

		//	void GetComponent(int node)
		//	{
		//		used.Add(node);
		//		component.Add(node);
		//		foreach (int i in symb_tr[node])
		//			if (!used.Contains(i))
		//				GetComponent(i);
		//	}
		//}

		public void LocalizeRecSet(int split)
        {
			var nodes = new List<int>();
			decimal oldCellSize = cellSize;
			decimal newcellSize = oldCellSize / split;
			decimal step = newcellSize / precision;

			foreach (int[] i in strongComps)
				foreach (int j in i)
					nodes.Add(j);

			var newGraph = new Graph(nodes.Count * split * split);

			foreach(int node in nodes)
            {
				Point p = GetNodeCoords(node, gridScale);
				p *= oldCellSize;
				p.Move(-2.0m, 2.0m - 2*p.y);
				for (decimal y = 0.0m; y < newcellSize * split; y += newcellSize)
					for (decimal x = 0.0m; x < newcellSize * split; x += newcellSize)
					{
						p.Move(x, -y);
						for (decimal j = p.y; j > p.y - newcellSize; j -= step)
							for (decimal i = p.x; i < p.x + newcellSize; i += step)
							{
								Point k = new Point(i, j);
								k = calc(k);
								if (p.x >= -2.0m && p.x < 2.0m && p.y > -2.0m && p.y <= 2.0m)
								{
									int cell = GetCell(k, newcellSize);
									if (!newGraph.HasVertex(node, cell))
										newGraph.AddVertex(node, cell);
								}
							}
					}
			}
			symbGraph = newGraph;
			cellSize = newcellSize;
			gridScale *= split;
			strongComps = symbGraph.FindStrongComps(gridScale);
		}

		private Point calc(Point p)
		{
			Point new_point = new Point();
			new_point.x = p.x * p.x - p.y * p.y + A;
			new_point.y = 2 * p.x * p.y + B;
			return new_point;
		}

		private int GetCell(Point p, decimal cellSize)
		{
			decimal a = ((p.x + 2.0m) / cellSize);
			decimal b = -(p.y - 2.0m) / cellSize;
			return (int)a + (int)b * gridScale;
		}
		private Point GetNodeCoords(int node, int scale)
        {
			int x = node % scale;
			int y = node / scale;
			return new Point((decimal)x, (decimal)y);
		}

		public Graph Graph
        {
			get { return symbGraph; }
        }

		public int GetCompsNum()
        {
			return symbGraph.FindStrongComps(gridScale).Count;
		}

		public List<int[]> GetStrongComps()
        {
			return symbGraph.FindStrongComps(gridScale);
        }



	}
}
