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
    public partial class Lab2GUI : Form
    {
        Configuration config;
        BackgroundWorker worker = new BackgroundWorker();
        System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        //List<int[]> strongComponents;

        public Lab2GUI(Configuration cfg)
        {
            InitializeComponent();
            config = cfg;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_Completed);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var symb = new Symbol(config);
            e.Result = symb.GetCompsNum();
        }

        private void worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            watch.Stop();
            var count = (int)e.Result;
            StatusLabel.Text = "Готово";
            pBar.Style = ProgressBarStyle.Blocks;
            pBar.Value = pBar.Maximum;
            Result.Text += count.ToString();
            execTime.Text += (watch.ElapsedMilliseconds.ToString() + " ms");
        }
        public void Run()
        {
            watch.Start();
            worker.RunWorkerAsync();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
