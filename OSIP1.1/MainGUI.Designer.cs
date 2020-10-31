namespace OSIP1._1
{
    partial class MainGUI
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textFunctionX = new System.Windows.Forms.TextBox();
            this.textFunctionY = new System.Windows.Forms.TextBox();
            this.boxSelectMode = new System.Windows.Forms.ComboBox();
            this.textScale = new System.Windows.Forms.TextBox();
            this.textPoints = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label3.Location = new System.Drawing.Point(15, 104);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(113, 13);
            label3.TabIndex = 8;
            label3.Text = "Масштаб разбиения:";
            label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label4.Location = new System.Drawing.Point(15, 130);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(134, 13);
            label4.TabIndex = 9;
            label4.Text = "Точность образа клетки:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(246, 15);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(85, 13);
            label5.TabIndex = 10;
            label5.Text = "Режим работы:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(57, 15);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(117, 13);
            label6.TabIndex = 11;
            label6.Text = "Параметры системы:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "f(x) = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(15, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "f(y) = ";
            // 
            // textFunctionX
            // 
            this.textFunctionX.Location = new System.Drawing.Point(60, 32);
            this.textFunctionX.Name = "textFunctionX";
            this.textFunctionX.Size = new System.Drawing.Size(158, 20);
            this.textFunctionX.TabIndex = 2;
            this.textFunctionX.TextChanged += new System.EventHandler(this.textFunctionX_TextChanged);
            // 
            // textFunctionY
            // 
            this.textFunctionY.Location = new System.Drawing.Point(60, 67);
            this.textFunctionY.Name = "textFunctionY";
            this.textFunctionY.Size = new System.Drawing.Size(158, 20);
            this.textFunctionY.TabIndex = 3;
            this.textFunctionY.TextChanged += new System.EventHandler(this.textFunctionY_TextChanged);
            // 
            // boxSelectMode
            // 
            this.boxSelectMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxSelectMode.FormattingEnabled = true;
            this.boxSelectMode.Items.AddRange(new object[] {
            "Символический образ",
            "Компоненты сильной связности",
            "Локализация цепно-рекуррентных множеств"});
            this.boxSelectMode.Location = new System.Drawing.Point(249, 31);
            this.boxSelectMode.Name = "boxSelectMode";
            this.boxSelectMode.Size = new System.Drawing.Size(246, 21);
            this.boxSelectMode.TabIndex = 5;
            this.boxSelectMode.SelectedIndexChanged += new System.EventHandler(this.boxSelectMode_SelectedIndexChanged);
            // 
            // textScale
            // 
            this.textScale.Location = new System.Drawing.Point(165, 101);
            this.textScale.Name = "textScale";
            this.textScale.Size = new System.Drawing.Size(53, 20);
            this.textScale.TabIndex = 6;
            this.textScale.TextChanged += new System.EventHandler(this.textScale_TextChanged);
            // 
            // textPoints
            // 
            this.textPoints.Location = new System.Drawing.Point(165, 127);
            this.textPoints.Name = "textPoints";
            this.textPoints.Size = new System.Drawing.Size(53, 20);
            this.textPoints.TabIndex = 7;
            this.textPoints.TextChanged += new System.EventHandler(this.textPoints_TextChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(276, 117);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(196, 30);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "Начать вычисление";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 165);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(label6);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(this.textPoints);
            this.Controls.Add(this.textScale);
            this.Controls.Add(this.boxSelectMode);
            this.Controls.Add(this.textFunctionY);
            this.Controls.Add(this.textFunctionX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Лабораторная 1-3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textFunctionX;
        private System.Windows.Forms.TextBox textFunctionY;
        private System.Windows.Forms.ComboBox boxSelectMode;
        private System.Windows.Forms.TextBox textScale;
        private System.Windows.Forms.TextBox textPoints;
        private System.Windows.Forms.Button buttonStart;
    }
}

