﻿namespace MyPaint
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pen = new System.Windows.Forms.Button();
            this.rectangle = new System.Windows.Forms.Button();
            this.ellipse = new System.Windows.Forms.Button();
            this.line = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.rubber = new System.Windows.Forms.Button();
            this.triangle = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.palette = new System.Windows.Forms.Button();
            this.righttriangle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fill = new System.Windows.Forms.Button();
            this.star = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox1.Location = new System.Drawing.Point(138, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1126, 573);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pen
            // 
            this.pen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pen.Image = ((System.Drawing.Image)(resources.GetObject("pen.Image")));
            this.pen.Location = new System.Drawing.Point(6, 25);
            this.pen.Name = "pen";
            this.pen.Size = new System.Drawing.Size(54, 58);
            this.pen.TabIndex = 1;
            this.toolTip1.SetToolTip(this.pen, "Pen");
            this.pen.UseVisualStyleBackColor = false;
            this.pen.Click += new System.EventHandler(this.pen_Click);
            // 
            // rectangle
            // 
            this.rectangle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rectangle.Image = ((System.Drawing.Image)(resources.GetObject("rectangle.Image")));
            this.rectangle.Location = new System.Drawing.Point(60, 25);
            this.rectangle.Name = "rectangle";
            this.rectangle.Size = new System.Drawing.Size(54, 54);
            this.rectangle.TabIndex = 2;
            this.toolTip1.SetToolTip(this.rectangle, "Rectangle");
            this.rectangle.UseVisualStyleBackColor = false;
            this.rectangle.Click += new System.EventHandler(this.rectangle_Click);
            // 
            // ellipse
            // 
            this.ellipse.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ellipse.Image = ((System.Drawing.Image)(resources.GetObject("ellipse.Image")));
            this.ellipse.Location = new System.Drawing.Point(6, 81);
            this.ellipse.Name = "ellipse";
            this.ellipse.Size = new System.Drawing.Size(54, 50);
            this.ellipse.TabIndex = 3;
            this.toolTip1.SetToolTip(this.ellipse, "Ellipse");
            this.ellipse.UseVisualStyleBackColor = false;
            this.ellipse.Click += new System.EventHandler(this.ellipse_Click);
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.line.Image = ((System.Drawing.Image)(resources.GetObject("line.Image")));
            this.line.Location = new System.Drawing.Point(6, 25);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(54, 54);
            this.line.TabIndex = 4;
            this.toolTip1.SetToolTip(this.line, "Line");
            this.line.UseVisualStyleBackColor = false;
            this.line.Click += new System.EventHandler(this.line_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.colorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1282, 33);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileToolStripMenuItem.Image")));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(140, 30);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 30);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("colorToolStripMenuItem.Image")));
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(91, 29);
            this.colorToolStripMenuItem.Text = "Color";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // rubber
            // 
            this.rubber.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rubber.Image = ((System.Drawing.Image)(resources.GetObject("rubber.Image")));
            this.rubber.Location = new System.Drawing.Point(60, 25);
            this.rubber.Name = "rubber";
            this.rubber.Size = new System.Drawing.Size(54, 58);
            this.rubber.TabIndex = 8;
            this.toolTip1.SetToolTip(this.rubber, "Rubber");
            this.rubber.UseVisualStyleBackColor = false;
            this.rubber.Click += new System.EventHandler(this.rubber_Click);
            // 
            // triangle
            // 
            this.triangle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.triangle.Image = ((System.Drawing.Image)(resources.GetObject("triangle.Image")));
            this.triangle.Location = new System.Drawing.Point(6, 137);
            this.triangle.Name = "triangle";
            this.triangle.Size = new System.Drawing.Size(54, 58);
            this.triangle.TabIndex = 9;
            this.toolTip1.SetToolTip(this.triangle, "Triangle");
            this.triangle.UseVisualStyleBackColor = false;
            this.triangle.Click += new System.EventHandler(this.triangle_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(10, 171);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(108, 26);
            this.numericUpDown1.TabIndex = 10;
            this.toolTip1.SetToolTip(this.numericUpDown1, "Pen width");
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // palette
            // 
            this.palette.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.palette.Image = ((System.Drawing.Image)(resources.GetObject("palette.Image")));
            this.palette.Location = new System.Drawing.Point(6, 86);
            this.palette.Name = "palette";
            this.palette.Size = new System.Drawing.Size(54, 59);
            this.palette.TabIndex = 11;
            this.toolTip1.SetToolTip(this.palette, "Palette");
            this.palette.UseVisualStyleBackColor = false;
            this.palette.Click += new System.EventHandler(this.palette_Click);
            // 
            // righttriangle
            // 
            this.righttriangle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.righttriangle.Image = ((System.Drawing.Image)(resources.GetObject("righttriangle.Image")));
            this.righttriangle.Location = new System.Drawing.Point(60, 137);
            this.righttriangle.Name = "righttriangle";
            this.righttriangle.Size = new System.Drawing.Size(54, 58);
            this.righttriangle.TabIndex = 12;
            this.toolTip1.SetToolTip(this.righttriangle, "Right triangle");
            this.righttriangle.UseVisualStyleBackColor = false;
            this.righttriangle.Click += new System.EventHandler(this.righttriangle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fill);
            this.groupBox1.Controls.Add(this.pen);
            this.groupBox1.Controls.Add(this.rubber);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.palette);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(6, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(120, 219);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pen";
            // 
            // fill
            // 
            this.fill.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fill.Image = ((System.Drawing.Image)(resources.GetObject("fill.Image")));
            this.fill.Location = new System.Drawing.Point(60, 86);
            this.fill.Name = "fill";
            this.fill.Size = new System.Drawing.Size(54, 59);
            this.fill.TabIndex = 15;
            this.toolTip1.SetToolTip(this.fill, "Filling");
            this.fill.UseVisualStyleBackColor = false;
            this.fill.Click += new System.EventHandler(this.fill_Click);
            // 
            // star
            // 
            this.star.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.star.Image = ((System.Drawing.Image)(resources.GetObject("star.Image")));
            this.star.Location = new System.Drawing.Point(60, 81);
            this.star.Name = "star";
            this.star.Size = new System.Drawing.Size(54, 50);
            this.star.TabIndex = 14;
            this.toolTip1.SetToolTip(this.star, "Star");
            this.star.UseVisualStyleBackColor = false;
            this.star.Click += new System.EventHandler(this.star_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.line);
            this.groupBox2.Controls.Add(this.star);
            this.groupBox2.Controls.Add(this.righttriangle);
            this.groupBox2.Controls.Add(this.rectangle);
            this.groupBox2.Controls.Add(this.triangle);
            this.groupBox2.Controls.Add(this.ellipse);
            this.groupBox2.Location = new System.Drawing.Point(6, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 215);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Figures";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Width:";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1282, 641);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MyPaint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button pen;
        private System.Windows.Forms.Button rectangle;
        private System.Windows.Forms.Button ellipse;
        private System.Windows.Forms.Button line;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button rubber;
        private System.Windows.Forms.Button triangle;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button palette;
        private System.Windows.Forms.Button righttriangle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button star;
        private System.Windows.Forms.Button fill;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

