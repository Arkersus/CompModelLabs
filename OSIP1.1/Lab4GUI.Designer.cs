namespace OSIP1._1
{
    partial class Lab4GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.execTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(31, 26);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(571, 34);
            this.pBar.TabIndex = 0;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Location = new System.Drawing.Point(215, 63);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(179, 23);
            this.StatusLabel.TabIndex = 4;
            this.StatusLabel.Text = "Идет вычисление...";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // execTime
            // 
            this.execTime.AutoSize = true;
            this.execTime.Location = new System.Drawing.Point(28, 115);
            this.execTime.Name = "execTime";
            this.execTime.Size = new System.Drawing.Size(111, 13);
            this.execTime.TabIndex = 5;
            this.execTime.Text = "Время выполнения: ";
            // 
            // Lab4GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 137);
            this.Controls.Add(this.execTime);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.pBar);
            this.Name = "Lab4GUI";
            this.ShowIcon = false;
            this.Text = "Топологическая сортировка";
            this.Load += new System.EventHandler(this.Lab4GUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label execTime;
    }
}