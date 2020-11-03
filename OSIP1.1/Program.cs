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
            Application.Run(new MainGUI());
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
	class Point<T>
	{
		public T x;
		public T y;
		//public double X, Y;

		public Point()
		{

		}
		public Point(T _x, T _y)
		{
			x = _x;
			y = _y;
		}



		public Point(Point<T> p)
		{
			x = (T)p.x;
			y = (T)p.y; 
		}

		//public void Move(T dx, T dy)
  //      {
		//	x = x + dx;
		//	y = y + dy;
  //      }

		//static public Point<T> operator *(Point<T> p, decimal m)
  //      {
		//	p.x *= m;
		//	p.y *= m;
		//	return p;
  //      }
	};
}
