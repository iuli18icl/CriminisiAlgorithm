﻿namespace CriminisiAlgorithm
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxLambda = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxStartHeight = new System.Windows.Forms.TextBox();
            this.textBoxStartWidth = new System.Windows.Forms.TextBox();
            this.textBoxStartY = new System.Windows.Forms.TextBox();
            this.textBoxStartX = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxThreshold = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtGrayscale = new System.Windows.Forms.RadioButton();
            this.rbtRGB = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBoxAndOr = new System.Windows.Forms.GroupBox();
            this.rbtAnd = new System.Windows.Forms.RadioButton();
            this.rbtOr = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxAndOr.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(0, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(584, 560);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(924, 577);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(184, 129);
            this.button3.TabIndex = 34;
            this.button3.Text = "Compute";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Compute_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 577);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 129);
            this.button1.TabIndex = 38;
            this.button1.Text = "Load Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LoadImage_Click);
            // 
            // textBoxLambda
            // 
            this.textBoxLambda.Location = new System.Drawing.Point(990, 838);
            this.textBoxLambda.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLambda.Name = "textBoxLambda";
            this.textBoxLambda.Size = new System.Drawing.Size(100, 31);
            this.textBoxLambda.TabIndex = 52;
            this.textBoxLambda.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1000, 810);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 25);
            this.label8.TabIndex = 51;
            this.label8.Text = "Lambda";
            // 
            // textBoxStartHeight
            // 
            this.textBoxStartHeight.Location = new System.Drawing.Point(672, 1004);
            this.textBoxStartHeight.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStartHeight.Name = "textBoxStartHeight";
            this.textBoxStartHeight.Size = new System.Drawing.Size(100, 31);
            this.textBoxStartHeight.TabIndex = 50;
            this.textBoxStartHeight.Text = "100";
            // 
            // textBoxStartWidth
            // 
            this.textBoxStartWidth.Location = new System.Drawing.Point(672, 838);
            this.textBoxStartWidth.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStartWidth.Name = "textBoxStartWidth";
            this.textBoxStartWidth.Size = new System.Drawing.Size(100, 31);
            this.textBoxStartWidth.TabIndex = 49;
            this.textBoxStartWidth.Text = "100";
            // 
            // textBoxStartY
            // 
            this.textBoxStartY.Location = new System.Drawing.Point(500, 1004);
            this.textBoxStartY.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStartY.Name = "textBoxStartY";
            this.textBoxStartY.Size = new System.Drawing.Size(100, 31);
            this.textBoxStartY.TabIndex = 48;
            this.textBoxStartY.Text = "0";
            // 
            // textBoxStartX
            // 
            this.textBoxStartX.Location = new System.Drawing.Point(500, 838);
            this.textBoxStartX.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStartX.Name = "textBoxStartX";
            this.textBoxStartX.Size = new System.Drawing.Size(100, 31);
            this.textBoxStartX.TabIndex = 47;
            this.textBoxStartX.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(216, 1004);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 31);
            this.textBox2.TabIndex = 46;
            this.textBox2.Text = "10";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(216, 838);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 31);
            this.textBox1.TabIndex = 45;
            this.textBox1.Text = "15";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 810);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 25);
            this.label7.TabIndex = 44;
            this.label7.Text = "block size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(688, 810);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 25);
            this.label6.TabIndex = 43;
            this.label6.Text = "Width";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(688, 977);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 25);
            this.label5.TabIndex = 42;
            this.label5.Text = "Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(514, 977);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 25);
            this.label4.TabIndex = 41;
            this.label4.Text = "Start Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(516, 810);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 40;
            this.label3.Text = "Start X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 977);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 39;
            this.label1.Text = "step size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(984, 977);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 53;
            this.label2.Text = "Threshold";
            // 
            // textBoxThreshold
            // 
            this.textBoxThreshold.Location = new System.Drawing.Point(990, 1004);
            this.textBoxThreshold.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxThreshold.Name = "textBoxThreshold";
            this.textBoxThreshold.Size = new System.Drawing.Size(100, 31);
            this.textBoxThreshold.TabIndex = 54;
            this.textBoxThreshold.Text = "0.6";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(712, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(584, 560);
            this.pictureBox2.TabIndex = 55;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Location = new System.Drawing.Point(1428, 2);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(584, 560);
            this.pictureBox3.TabIndex = 56;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1656, 577);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 129);
            this.button2.TabIndex = 59;
            this.button2.Text = "Load Mask";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(1132, 838);
            this.textBox9.Margin = new System.Windows.Forms.Padding(4);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(81, 31);
            this.textBox9.TabIndex = 60;
            this.textBox9.Text = "4";
            this.textBox9.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(1132, 1004);
            this.textBox10.Margin = new System.Windows.Forms.Padding(4);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(81, 31);
            this.textBox10.TabIndex = 61;
            this.textBox10.Text = "78";
            this.textBox10.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1150, 809);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 25);
            this.label11.TabIndex = 62;
            this.label11.Text = "a";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1150, 975);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 25);
            this.label12.TabIndex = 63;
            this.label12.Text = "b";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtGrayscale);
            this.groupBox1.Controls.Add(this.rbtRGB);
            this.groupBox1.Location = new System.Drawing.Point(1300, 838);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(358, 155);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color MODE";
            // 
            // rbtGrayscale
            // 
            this.rbtGrayscale.AutoSize = true;
            this.rbtGrayscale.Location = new System.Drawing.Point(128, 106);
            this.rbtGrayscale.Margin = new System.Windows.Forms.Padding(4);
            this.rbtGrayscale.Name = "rbtGrayscale";
            this.rbtGrayscale.Size = new System.Drawing.Size(140, 29);
            this.rbtGrayscale.TabIndex = 60;
            this.rbtGrayscale.TabStop = true;
            this.rbtGrayscale.Text = "Grayscale";
            this.rbtGrayscale.UseVisualStyleBackColor = true;
            this.rbtGrayscale.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbtRGB
            // 
            this.rbtRGB.AutoSize = true;
            this.rbtRGB.Location = new System.Drawing.Point(128, 54);
            this.rbtRGB.Margin = new System.Windows.Forms.Padding(4);
            this.rbtRGB.Name = "rbtRGB";
            this.rbtRGB.Size = new System.Drawing.Size(88, 29);
            this.rbtRGB.TabIndex = 59;
            this.rbtRGB.TabStop = true;
            this.rbtRGB.Text = "RGB";
            this.rbtRGB.UseVisualStyleBackColor = true;
            this.rbtRGB.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // groupBoxAndOr
            // 
            this.groupBoxAndOr.Controls.Add(this.rbtAnd);
            this.groupBoxAndOr.Controls.Add(this.rbtOr);
            this.groupBoxAndOr.Location = new System.Drawing.Point(1694, 838);
            this.groupBoxAndOr.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxAndOr.Name = "groupBoxAndOr";
            this.groupBoxAndOr.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxAndOr.Size = new System.Drawing.Size(214, 141);
            this.groupBoxAndOr.TabIndex = 65;
            this.groupBoxAndOr.TabStop = false;
            this.groupBoxAndOr.Text = "Color AND / OR";
            // 
            // rbtAnd
            // 
            this.rbtAnd.AutoSize = true;
            this.rbtAnd.Location = new System.Drawing.Point(94, 37);
            this.rbtAnd.Margin = new System.Windows.Forms.Padding(6);
            this.rbtAnd.Name = "rbtAnd";
            this.rbtAnd.Size = new System.Drawing.Size(87, 29);
            this.rbtAnd.TabIndex = 1;
            this.rbtAnd.TabStop = true;
            this.rbtAnd.Text = "AND";
            this.rbtAnd.UseVisualStyleBackColor = true;
            // 
            // rbtOr
            // 
            this.rbtOr.AutoSize = true;
            this.rbtOr.Location = new System.Drawing.Point(94, 79);
            this.rbtOr.Margin = new System.Windows.Forms.Padding(6);
            this.rbtOr.Name = "rbtOr";
            this.rbtOr.Size = new System.Drawing.Size(74, 29);
            this.rbtOr.TabIndex = 0;
            this.rbtOr.TabStop = true;
            this.rbtOr.Text = "OR";
            this.rbtOr.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(2212, 1062);
            this.Controls.Add(this.groupBoxAndOr);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBoxThreshold);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxLambda);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxStartHeight);
            this.Controls.Add(this.textBoxStartWidth);
            this.Controls.Add(this.textBoxStartY);
            this.Controls.Add(this.textBoxStartX);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxAndOr.ResumeLayout(false);
            this.groupBoxAndOr.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxLambda;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxStartHeight;
        private System.Windows.Forms.TextBox textBoxStartWidth;
        private System.Windows.Forms.TextBox textBoxStartY;
        private System.Windows.Forms.TextBox textBoxStartX;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxThreshold;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtGrayscale;
        private System.Windows.Forms.RadioButton rbtRGB;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBoxAndOr;
        private System.Windows.Forms.RadioButton rbtAnd;
        private System.Windows.Forms.RadioButton rbtOr;
    }
}

