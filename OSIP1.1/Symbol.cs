using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Concurrent;
using System.Linq;

namespace OSIP1._1
{
	public class Symbol
	{
		private Graph symbGraph;
		private List<int[]> strongComps;
		private int gridScale;
		private int precision;
		private double A, B;
		private double cellSize;
		public Symbol(Configuration config, BackgroundWorker worker = null)
		{
			gridScale = config.gridScale;
			precision = (int)Math.Sqrt(config.points);
			A = (double)config.A;
			B = (double)config.B;

			Graph g = new Graph();
			int size = gridScale * gridScale;
			cellSize = 4.0 / config.gridScale;
			double step = cellSize / precision;

			for (double y = 2.0; y > -2.0; y -= cellSize)
				for (double x = -2.0; x < 2.0; x += cellSize)
				{
					int origin = GetCell(new Point<double>(x,y), cellSize, gridScale);
					for (double j = y; j > y - cellSize; j -= step)
						for (double i = x; i < x + cellSize; i += step)
						{
							var p = new Point<double>(i, j);
							p = calc(p);
							if (p != null)
							{
								int cell = GetCell(p, cellSize, gridScale);

								if (cell >= size)
									continue;
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
			int oldScale = gridScale;
			int newScale = gridScale * split;
			double oldCellSize = cellSize;
			double newCellSize = oldCellSize / split;
			double step = newCellSize / precision;
			int splitCells = split * split;
			int newSize = newScale * newScale;

			var newGraph = new Graph();

			if (strongComps == null)
				strongComps = symbGraph.FindStrongComps(gridScale);

			foreach (int[] i in strongComps)
			{
				var component = i.ToList<int>();
				foreach (int j in i)
				{
					var origin = GetNodeCoords(oldCellSize, j, gridScale);

					for (int n = 0; n < splitCells; n++)
					{
						var local = new Point<double>
							(
								origin.x + (double)(n % split) * newCellSize,
								origin.y - (double)(n / split) * newCellSize
							);
						var localNode = GetCell(local, newCellSize, newScale);

						for (int y = 0; y < precision; y++)
							for (int x = 0; x < precision; x++)
							{
								var p = calc(new Point<double>
								(
									local.x + (double)x * step,
									local.y - (double)y * step
								));
								if (p != null)
								{
									var cell = GetCell(p, newCellSize, newScale);

									if (cell >= newSize) continue;

									if (!newGraph.HasVertex(localNode, cell))
										newGraph.AddVertex(localNode, cell);
								}
							}
					}

				}
			}

			symbGraph = newGraph;
			cellSize = newCellSize;
			gridScale = newScale;
			//strongComps = symbGraph.FindStrongComps(newScale);
		}

		private Point<double> calc(Point<double> p)
		{
			Point<double> new_point = new Point<double>();
			new_point.x = p.x * p.x - p.y * p.y + A;
			new_point.y = 2 * p.x * p.y + B;

			if (new_point.x >= -2.0 && new_point.x < 2.0 &&
				new_point.y > -2.0 && new_point.y <= 2.0)
				return new_point;
			else
				return null;
		}

		private int GetCell(Point<double> p, double cellSize, int gridScale)
		{
			double a = ((p.x + 2.0) / cellSize);
			double b = -(p.y - 2.0) / cellSize;
			return (int)a + (int)b * gridScale;
		}
		private Point<double> GetNodeCoords(double cellSize, int node, int scale)
        {
			double x = ((double)(node % scale) * cellSize) - 2.0;
			double y = 2.0 - ((double)(node / scale) * cellSize);
			return new Point<double>(x, y);
		}

		public Graph Graph
        {
			get { return symbGraph; }
        }

		public int GetScale
        {
			get { return gridScale; }
        }

		public int GetCompsNum()
        {
			strongComps = symbGraph.FindStrongComps(gridScale);
			return strongComps.Count;
		}

		public List<int[]> GetStrongComps()
        {
			strongComps = symbGraph.FindStrongComps(gridScale);
			return strongComps;
        }

		public List<int[]> GetTopologySort()
        {
			return symbGraph.FindStrongComps(gridScale, true);
		}



	}
}
