namespace OSIP1._1
{
    partial class Form2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vertCount = new System.Windows.Forms.Label();
            this.nodeCount = new System.Windows.Forms.Label();
            this.execTime = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(26, 28);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(465, 40);
            this.pBar.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vertCount);
            this.groupBox1.Controls.Add(this.nodeCount);
            this.groupBox1.Location = new System.Drawing.Point(27, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Результат";
            // 
            // vertCount
            // 
            this.vertCount.AutoSize = true;
            this.vertCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vertCount.Location = new System.Drawing.Point(30, 36);
            this.vertCount.Name = "vertCount";
            this.vertCount.Size = new System.Drawing.Size(121, 20);
            this.vertCount.TabIndex = 1;
            this.vertCount.Text = "Число граней: ";
            // 
            // nodeCount
            // 
            this.nodeCount.AutoSize = true;
            this.nodeCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nodeCount.Location = new System.Drawing.Point(24, 16);
            this.nodeCount.Name = "nodeCount";
            this.nodeCount.Size = new System.Drawing.Size(127, 20);
            this.nodeCount.TabIndex = 0;
            this.nodeCount.Text = "Число вершин: ";
            this.nodeCount.Click += new System.EventHandler(this.label1_Click);
            // 
            // execTime
            // 
            this.execTime.AutoSize = true;
            this.execTime.Location = new System.Drawing.Point(46, 183);
            this.execTime.Name = "execTime";
            this.execTime.Size = new System.Drawing.Size(108, 13);
            this.execTime.TabIndex = 2;
            this.execTime.Text = "Время выполнения:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 203);
            this.Controls.Add(this.execTime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pBar);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "Вичисление графа символического образа";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label nodeCount;
        private System.Windows.Forms.Label vertCount;
        private System.Windows.Forms.Label execTime;
    }
}