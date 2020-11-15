using OpenTK;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

namespace OSIP1._1
{
    class GraphicsLab
    {
        private Configuration config;
        private Symbol symbImage;
        private GameWindow window;
        private List<int[]> strongComps;
        private List<Color> colors;
        int scale;
        System.Diagnostics.Stopwatch watch;
        Lab3LocalizationGUI progress;
        BackgroundWorker worker;

        public GraphicsLab(Configuration cfg)
        {
            config = cfg;
            worker = new BackgroundWorker();
            progress = new Lab3LocalizationGUI();
            watch = new System.Diagnostics.Stopwatch();

            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_Completed);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            symbImage.LocalizeRecSet(4);
            scale *= 4;
            strongComps = symbImage.GetStrongComps();
            colors = GetColors(strongComps);
        }

        private void worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            watch.Stop();
            progress.Hide();

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0f, scale, scale, 0.0f, 0.0f, 1.0f);
        }

        private GameWindow GetWindow(int width, int height)
        {
            var win = new GameWindow(width, height);

            win.Load += Window_Load;
            win.RenderFrame += Window_RenderFrame;
            win.KeyPress += Window_KeyPress;
            win.Closed += Win_Closed;

            return win;
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            Console.WriteLine(symbImage.Graph.Count);
            Console.WriteLine(watch.ElapsedMilliseconds);
            symbImage = null;
            strongComps = null;
            colors = null;

        }

        private void Window_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' && !worker.IsBusy)
            {
                progress.Show();
                watch.Start();
                //symbImage.LocalizeRecSet(4);
                //strongComps = symbImage.GetStrongComps();
                //colors = GetColors(strongComps);
                //scale *= 4;
                worker.RunWorkerAsync();

                //progress.Hide();
            
                //GL.MatrixMode(MatrixMode.Projection);
                //GL.LoadIdentity();
                //GL.Ortho(0.0f, scale, scale, 0.0f, 0.0f, 1.0f);
            }
        }

        private void Window_Load(object sender, EventArgs e)
        {
            GL.ClearColor(new Color4(1.0f, 1.0f, 1.0f, 1.0f));
            //GL.ClearColor(new Color4(0.0f, 0.0f, 0.0f, 1.0f));

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0f, scale, scale, 0.0f, 0.0f, 1.0f);
        }

        private void Window_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            Render();

            GL.Flush();

            window.SwapBuffers();
        }

        private void Render()
        {
            DrawCoords();

            for(int i = 0; i < strongComps.Count; i++)
            {
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(colors[i]);

                foreach (int j in strongComps[i])
                    DrawCell(j);
                GL.End();
            }
        }

        private void DrawCoords()
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Black);
            //GL.Color3(Color.DarkGreen);
            GL.Vertex2(0, scale / 2);
            GL.Vertex2(scale, scale / 2);
            GL.Vertex2(scale / 2, 0);
            GL.Vertex2(scale / 2, scale);
            GL.End();
        }
        private void DrawCell(int n)
        {
            int x = n % scale;
            int y = n / scale;

            GL.Vertex2(x, y);
            GL.Vertex2(x, y+1);
            GL.Vertex2(x+1, y+1);
            GL.Vertex2(x+1, y);
        }
        public void Run()
        {
            watch.Start();
            symbImage = new Symbol(config);
            strongComps = symbImage.GetStrongComps();
            colors = GetColors(strongComps);
            scale = symbImage.GetScale;
            watch.Stop();
            window = GetWindow(1000, 1000);
            window.Run();


        }

        private List<Color> GetColors(List<int[]> Comps)
        {
            var rng = new Random();
            var colors = new List<Color>();
            for (int i = 0; i < Comps.Count; i++)
                colors.Add(Color.FromArgb(rng.Next(255), rng.Next(255), rng.Next(255)));
            return colors;
        }
    }
}
