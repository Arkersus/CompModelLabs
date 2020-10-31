namespace OSIP1._1
{
    partial class Lab2GUI
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
            this.Result = new System.Windows.Forms.Label();
            this.execTime = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(22, 17);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(490, 42);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pBar.TabIndex = 0;
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Result.Location = new System.Drawing.Point(18, 105);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(300, 24);
            this.Result.TabIndex = 1;
            this.Result.Text = "Компонент сильной связности: ";
            this.Result.Click += new System.EventHandler(this.label1_Click);
            // 
            // execTime
            // 
            this.execTime.AutoSize = true;
            this.execTime.Location = new System.Drawing.Point(22, 144);
            this.execTime.Name = "execTime";
            this.execTime.Size = new System.Drawing.Size(111, 13);
            this.execTime.TabIndex = 2;
            this.execTime.Text = "Время выполнения: ";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Location = new System.Drawing.Point(183, 62);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(179, 23);
            this.StatusLabel.TabIndex = 3;
            this.StatusLabel.Text = "Идет вычисление...";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 169);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.execTime);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.pBar);
            this.Name = "Form3";
            this.ShowIcon = false;
            this.Text = "Нахождение компонент сильной связности";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Label execTime;
        private System.Windows.Forms.Label StatusLabel;
    }
}