namespace Jump_Calculator
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
            this.refreshToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stationBar = new System.Windows.Forms.ProgressBar();
            this.structureBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // refreshToken
            // 
            this.refreshToken.Location = new System.Drawing.Point(99, 12);
            this.refreshToken.Name = "refreshToken";
            this.refreshToken.Size = new System.Drawing.Size(506, 20);
            this.refreshToken.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Refresh Token:";
            // 
            // stationBar
            // 
            this.stationBar.Location = new System.Drawing.Point(12, 38);
            this.stationBar.Name = "stationBar";
            this.stationBar.Size = new System.Drawing.Size(593, 23);
            this.stationBar.TabIndex = 2;
            // 
            // structureBar
            // 
            this.structureBar.Location = new System.Drawing.Point(12, 67);
            this.structureBar.Name = "structureBar";
            this.structureBar.Size = new System.Drawing.Size(593, 23);
            this.structureBar.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 57);
            this.button1.TabIndex = 4;
            this.button1.Text = "Read Structures";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 162);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.structureBar);
            this.Controls.Add(this.stationBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshToken);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox refreshToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar stationBar;
        private System.Windows.Forms.ProgressBar structureBar;
        private System.Windows.Forms.Button button1;
    }
}

