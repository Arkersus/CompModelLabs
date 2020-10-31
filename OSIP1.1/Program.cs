using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIP1._1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
	public class NodeUnit
	{
		private int node;
		private List<int> vertices;

		public NodeUnit(int n, List<int> v)
		{
			node = n;
			vertices = v;
		}

		public static implicit operator NodeUnit(KeyValuePair<int, List<int>> kvp) => new NodeUnit(kvp);

		public NodeUnit(KeyValuePair<int, List<int>> kvp)
        {
			node = kvp.Key;
			vertices = kvp.Value;
        }

		public int Node
		{
			get { return node; }
		}

		public List<int> Vertices
		{
			get { return vertices; }
		}
	};
	class Point
	{
		public decimal x;
		public decimal y;

		public Point()
		{

		}
		public Point(decimal _x, decimal _y)
		{
			x = _x;
			y = _y;
		}

		public Point(Point p)
		{
			x = p.x;
			y = p.y; 
		}

		public void Move(decimal dx, decimal dy)
        {
			x += dx;
			y += dy;
        }

		static public Point operator *(Point p, decimal m)
        {
			p.x *= m;
			p.y *= m;
			return p;
        }
	};
}
