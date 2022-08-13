namespace WindowsFormsApp3
{
    partial class Form1
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
            this.sheet = new System.Windows.Forms.PictureBox();
            this.VertexB = new System.Windows.Forms.Button();
            this.SelectB = new System.Windows.Forms.Button();
            this.EdgeB = new System.Windows.Forms.Button();
            this.Shw = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.SuspendLayout();
            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.SystemColors.Control;
            this.sheet.Location = new System.Drawing.Point(0, 0);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(1023, 408);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // VertexB
            // 
            this.VertexB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.VertexB.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.VertexB.Location = new System.Drawing.Point(34, 479);
            this.VertexB.Name = "VertexB";
            this.VertexB.Size = new System.Drawing.Size(179, 32);
            this.VertexB.TabIndex = 1;
            this.VertexB.Text = "Добавить вершину";
            this.VertexB.UseVisualStyleBackColor = false;
            this.VertexB.Click += new System.EventHandler(this.VertexB_Click);
            // 
            // SelectB
            // 
            this.SelectB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SelectB.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.SelectB.Location = new System.Drawing.Point(34, 426);
            this.SelectB.Name = "SelectB";
            this.SelectB.Size = new System.Drawing.Size(179, 34);
            this.SelectB.TabIndex = 2;
            this.SelectB.Text = "Курсор";
            this.SelectB.UseVisualStyleBackColor = false;
            this.SelectB.Click += new System.EventHandler(this.SelectB_Click);
            // 
            // EdgeB
            // 
            this.EdgeB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EdgeB.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.EdgeB.Location = new System.Drawing.Point(34, 526);
            this.EdgeB.Name = "EdgeB";
            this.EdgeB.Size = new System.Drawing.Size(179, 29);
            this.EdgeB.TabIndex = 3;
            this.EdgeB.Text = "Добавить дорогу";
            this.EdgeB.UseVisualStyleBackColor = false;
            this.EdgeB.Click += new System.EventHandler(this.EdgeB_Click);
            // 
            // Shw
            // 
            this.Shw.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Shw.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Shw.Location = new System.Drawing.Point(315, 513);
            this.Shw.Name = "Shw";
            this.Shw.Size = new System.Drawing.Size(100, 42);
            this.Shw.TabIndex = 7;
            this.Shw.Text = "Найти путь";
            this.Shw.UseVisualStyleBackColor = false;
            this.Shw.Click += new System.EventHandler(this.Shw_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(315, 438);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(257, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Откуда";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp3.Properties.Resources.gandex_ru_26_6929_stylish_gray_bg;
            this.ClientSize = new System.Drawing.Size(1022, 594);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Shw);
            this.Controls.Add(this.EdgeB);
            this.Controls.Add(this.SelectB);
            this.Controls.Add(this.VertexB);
            this.Controls.Add(this.sheet);
            this.Name = "Form1";
            this.Text = "Графы";
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button VertexB;
        private System.Windows.Forms.Button SelectB;
        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Button EdgeB;
        private System.Windows.Forms.Button Shw;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
    }
}

