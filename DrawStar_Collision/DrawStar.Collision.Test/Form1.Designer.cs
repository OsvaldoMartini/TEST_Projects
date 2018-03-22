namespace DrawStars
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.mouseY = new System.Windows.Forms.Label();
            this.mouseX = new System.Windows.Forms.Label();
            this.posY = new System.Windows.Forms.Label();
            this.posX = new System.Windows.Forms.Label();
            this.startRed = new System.Windows.Forms.Panel();
            this.startBlue = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mouseY);
            this.panel1.Controls.Add(this.mouseX);
            this.panel1.Controls.Add(this.posY);
            this.panel1.Controls.Add(this.posX);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 342);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 34);
            this.panel1.TabIndex = 1;
            // 
            // mouseY
            // 
            this.mouseY.AutoSize = true;
            this.mouseY.Location = new System.Drawing.Point(557, 8);
            this.mouseY.Name = "mouseY";
            this.mouseY.Size = new System.Drawing.Size(63, 17);
            this.mouseY.TabIndex = 3;
            this.mouseY.Text = "mouseY:";
            // 
            // mouseX
            // 
            this.mouseX.AutoSize = true;
            this.mouseX.Location = new System.Drawing.Point(463, 8);
            this.mouseX.Name = "mouseX";
            this.mouseX.Size = new System.Drawing.Size(63, 17);
            this.mouseX.TabIndex = 2;
            this.mouseX.Text = "mouseX:";
            // 
            // posY
            // 
            this.posY.AutoSize = true;
            this.posY.Location = new System.Drawing.Point(66, 4);
            this.posY.Name = "posY";
            this.posY.Size = new System.Drawing.Size(21, 17);
            this.posY.TabIndex = 1;
            this.posY.Text = "Y:";
            // 
            // posX
            // 
            this.posX.AutoSize = true;
            this.posX.Location = new System.Drawing.Point(13, 4);
            this.posX.Name = "posX";
            this.posX.Size = new System.Drawing.Size(21, 17);
            this.posX.TabIndex = 0;
            this.posX.Text = "X:";
            // 
            // startRed
            // 
            this.startRed.BackColor = System.Drawing.Color.Red;
            this.startRed.Location = new System.Drawing.Point(407, 87);
            this.startRed.Name = "startRed";
            this.startRed.Size = new System.Drawing.Size(69, 70);
            this.startRed.TabIndex = 2;
            // 
            // startBlue
            // 
            this.startBlue.BackColor = System.Drawing.Color.Blue;
            this.startBlue.Location = new System.Drawing.Point(168, 194);
            this.startBlue.Name = "startBlue";
            this.startBlue.Size = new System.Drawing.Size(75, 63);
            this.startBlue.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "lblCollision";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 376);
            this.Controls.Add(this.startBlue);
            this.Controls.Add(this.startRed);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label posY;
        private System.Windows.Forms.Label posX;
        private System.Windows.Forms.Label mouseY;
        private System.Windows.Forms.Label mouseX;
        private System.Windows.Forms.Panel startRed;
        private System.Windows.Forms.Panel startBlue;
        private System.Windows.Forms.Label label1;
    }
}

