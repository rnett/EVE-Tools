namespace EVE_Desktop
{
    partial class CharacterDataOverview
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picture = new System.Windows.Forms.PictureBox();
            this.isk = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sp = new System.Windows.Forms.Label();
            this.currentSkill = new System.Windows.Forms.ProgressBar();
            this.skillLabel = new System.Windows.Forms.Label();
            this.attributesLabel = new System.Windows.Forms.Label();
            this.jumpFatigue = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(3, 3);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(24, 24);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            // 
            // isk
            // 
            this.isk.AutoSize = true;
            this.isk.Location = new System.Drawing.Point(66, 3);
            this.isk.Name = "isk";
            this.isk.Size = new System.Drawing.Size(91, 13);
            this.isk.TabIndex = 1;
            this.isk.Text = "1,000,000,000.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ISK:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SP:";
            // 
            // sp
            // 
            this.sp.AutoSize = true;
            this.sp.Location = new System.Drawing.Point(66, 16);
            this.sp.Name = "sp";
            this.sp.Size = new System.Drawing.Size(67, 13);
            this.sp.TabIndex = 3;
            this.sp.Text = "100,000,000";
            // 
            // currentSkill
            // 
            this.currentSkill.Location = new System.Drawing.Point(3, 46);
            this.currentSkill.Name = "currentSkill";
            this.currentSkill.Size = new System.Drawing.Size(198, 17);
            this.currentSkill.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.currentSkill.TabIndex = 5;
            this.currentSkill.Value = 50;
            // 
            // skillLabel
            // 
            this.skillLabel.AutoSize = true;
            this.skillLabel.BackColor = System.Drawing.Color.Transparent;
            this.skillLabel.Location = new System.Drawing.Point(3, 30);
            this.skillLabel.Name = "skillLabel";
            this.skillLabel.Size = new System.Drawing.Size(35, 13);
            this.skillLabel.TabIndex = 6;
            this.skillLabel.Text = "label3";
            // 
            // attributesLabel
            // 
            this.attributesLabel.AutoSize = true;
            this.attributesLabel.BackColor = System.Drawing.Color.OrangeRed;
            this.attributesLabel.Location = new System.Drawing.Point(3, 66);
            this.attributesLabel.Name = "attributesLabel";
            this.attributesLabel.Size = new System.Drawing.Size(35, 13);
            this.attributesLabel.TabIndex = 7;
            this.attributesLabel.Text = "label3";
            // 
            // jumpFatigue
            // 
            this.jumpFatigue.AutoSize = true;
            this.jumpFatigue.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.jumpFatigue.Location = new System.Drawing.Point(139, 16);
            this.jumpFatigue.Name = "jumpFatigue";
            this.jumpFatigue.Size = new System.Drawing.Size(34, 13);
            this.jumpFatigue.TabIndex = 8;
            this.jumpFatigue.Text = "3d 5h";
            this.toolTip1.SetToolTip(this.jumpFatigue, "Jump Fatigue");
            // 
            // CharacterOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jumpFatigue);
            this.Controls.Add(this.attributesLabel);
            this.Controls.Add(this.skillLabel);
            this.Controls.Add(this.currentSkill);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.isk);
            this.Controls.Add(this.picture);
            this.Name = "CharacterOverview";
            this.Size = new System.Drawing.Size(206, 83);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label isk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label sp;
        private System.Windows.Forms.ProgressBar currentSkill;
        private System.Windows.Forms.Label skillLabel;
        private System.Windows.Forms.Label attributesLabel;
        private System.Windows.Forms.Label jumpFatigue;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
