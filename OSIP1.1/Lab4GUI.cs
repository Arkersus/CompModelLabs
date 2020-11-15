using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIP1._1
{
    public partial class Lab4GUI : Form
    {
        Configuration config;
        BackgroundWorker worker = new BackgroundWorker();
        System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        public Lab4GUI(Configuration cfg)
        {
            InitializeComponent();
            config = cfg;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_Completed);

            watch.Start();
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var symb = new Symbol(config);
            e.Result = symb.GetTopologySort();
        }
        private void worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            watch.Stop();
            var sortedOrder = (List<int[]>)e.Result;
            StatusLabel.Text = "Готово";
            pBar.Style = ProgressBarStyle.Blocks;
            pBar.Value = pBar.Maximum;

            OutputToFile(sortedOrder);

            execTime.Text += (watch.ElapsedMilliseconds.ToString() + " ms");
        }

        private void OutputToFile(List<int[]> output)
        {
            using(System.IO.StreamWriter file = 
                new System.IO.StreamWriter("SortedGraph.txt"))
            {
                int n = 1;
                foreach(var node in output)
                {
                    if(node.Length > 1)
                    {
                        string token = "K" + n.ToString();
                        file.WriteLine(token);
                        n++;
                    }
                    else
                        file.WriteLine(node[0].ToString());
                }
            }
        }

        private void Lab4GUI_Load(object sender, EventArgs e)
        {

        }
    }
}
