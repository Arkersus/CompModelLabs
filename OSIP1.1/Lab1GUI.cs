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
    public partial class Lab1GUI : Form
    {
        Configuration config;
        BackgroundWorker worker;
        System.Diagnostics.Stopwatch watch;

        public Lab1GUI(Configuration cfg)
        {
            InitializeComponent();
            config = cfg;
            InitializeBackrgoundWorker();
        }

        private void InitializeBackrgoundWorker()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_Completed);
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBar.PerformStep();
        }

        private void worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            Symbol symbResult = (Symbol)e.Result;
            Graph graphResult = symbResult.Graph;
            nodeCount.Text += graphResult.Count.ToString();
            vertCount.Text += graphResult.GetVnum().ToString();
            watch.Stop();
            execTime.Text += (watch.ElapsedMilliseconds.ToString() + " ms");

        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            e.Result = new Symbol(config, bw);
        }

        public void Run()
        {
			pBar.Minimum = 1;
			pBar.Maximum = config.gridScale * config.gridScale;
			pBar.Value = 1;
			pBar.Step = 1;

			watch = new System.Diagnostics.Stopwatch();
			watch.Start();
            worker.RunWorkerAsync();
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
