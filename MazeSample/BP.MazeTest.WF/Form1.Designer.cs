namespace BP.MazeTest.WF
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
            this.button1 = new System.Windows.Forms.Button();
            this.nudRows = new System.Windows.Forms.NumericUpDown();
            this.nudCols = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "New Maze";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nudRows
            // 
            this.nudRows.Location = new System.Drawing.Point(127, 29);
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(120, 22);
            this.nudRows.TabIndex = 3;
            this.nudRows.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudCols
            // 
            this.nudCols.ForeColor = System.Drawing.SystemColors.WindowText;
            this.nudCols.Location = new System.Drawing.Point(280, 29);
            this.nudCols.Name = "nudCols";
            this.nudCols.Size = new System.Drawing.Size(120, 22);
            this.nudCols.TabIndex = 4;
            this.nudCols.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(446, 29);
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(120, 22);
            this.nudWidth.TabIndex = 5;
            this.nudWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(573, 29);
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(120, 22);
            this.nudHeight.TabIndex = 6;
            this.nudHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Row Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Column Count";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cell Width(pixels)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(573, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Cell Height(pixels)";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 409);
            this.panel1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 470);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudHeight);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.nudCols);
            this.Controls.Add(this.nudRows);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nudRows;
        private System.Windows.Forms.NumericUpDown nudCols;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
    }
}

