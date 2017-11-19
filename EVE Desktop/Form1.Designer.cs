namespace EVE_Desktop
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.desktopPage = new System.Windows.Forms.TabPage();
            this.charactersOverview = new EVE_Desktop.CharactersOverview();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addCharacterButton = new System.Windows.Forms.Button();
            this.addCharacterTB = new System.Windows.Forms.TextBox();
            this.charactersDGV = new System.Windows.Forms.DataGridView();
            this.CharacterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CharacterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefreshToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1.SuspendLayout();
            this.desktopPage.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.charactersDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.desktopPage);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1400, 739);
            this.tabControl1.TabIndex = 0;
            // 
            // desktopPage
            // 
            this.desktopPage.Controls.Add(this.charactersOverview);
            this.desktopPage.Location = new System.Drawing.Point(4, 22);
            this.desktopPage.Name = "desktopPage";
            this.desktopPage.Padding = new System.Windows.Forms.Padding(3);
            this.desktopPage.Size = new System.Drawing.Size(1392, 713);
            this.desktopPage.TabIndex = 0;
            this.desktopPage.Text = "Desktop";
            this.desktopPage.UseVisualStyleBackColor = true;
            // 
            // charactersOverview
            // 
            this.charactersOverview.Characters = null;
            this.charactersOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.charactersOverview.Location = new System.Drawing.Point(3, 3);
            this.charactersOverview.Name = "charactersOverview";
            this.charactersOverview.Size = new System.Drawing.Size(1386, 707);
            this.charactersOverview.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1392, 713);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.linkLabel1);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.addCharacterButton);
            this.tabPage3.Controls.Add(this.addCharacterTB);
            this.tabPage3.Controls.Add(this.charactersDGV);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1392, 713);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Characters";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(0, 25);
            this.linkLabel1.Location = new System.Drawing.Point(123, 13);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(514, 17);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "evedesktop.freecluster.eu, log in with the character you want to add, and copy th" +
    "e refresh token below";
            this.linkLabel1.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Go to ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Refresh Token:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Add Character:";
            // 
            // addCharacterButton
            // 
            this.addCharacterButton.Location = new System.Drawing.Point(948, 31);
            this.addCharacterButton.Name = "addCharacterButton";
            this.addCharacterButton.Size = new System.Drawing.Size(75, 23);
            this.addCharacterButton.TabIndex = 2;
            this.addCharacterButton.Text = "Add";
            this.addCharacterButton.UseVisualStyleBackColor = true;
            this.addCharacterButton.Click += new System.EventHandler(this.addCharacterButton_Click);
            // 
            // addCharacterTB
            // 
            this.addCharacterTB.Location = new System.Drawing.Point(95, 33);
            this.addCharacterTB.Name = "addCharacterTB";
            this.addCharacterTB.Size = new System.Drawing.Size(847, 20);
            this.addCharacterTB.TabIndex = 1;
            // 
            // charactersDGV
            // 
            this.charactersDGV.AllowUserToAddRows = false;
            this.charactersDGV.AllowUserToDeleteRows = false;
            this.charactersDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.charactersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.charactersDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CharacterName,
            this.CharacterID,
            this.RefreshToken,
            this.Remove});
            this.charactersDGV.Location = new System.Drawing.Point(3, 73);
            this.charactersDGV.Name = "charactersDGV";
            this.charactersDGV.ReadOnly = true;
            this.charactersDGV.RowHeadersVisible = false;
            this.charactersDGV.Size = new System.Drawing.Size(1386, 637);
            this.charactersDGV.TabIndex = 0;
            // 
            // CharacterName
            // 
            this.CharacterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CharacterName.HeaderText = "Name";
            this.CharacterName.Name = "CharacterName";
            this.CharacterName.ReadOnly = true;
            this.CharacterName.Width = 60;
            // 
            // CharacterID
            // 
            this.CharacterID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CharacterID.HeaderText = "ID";
            this.CharacterID.Name = "CharacterID";
            this.CharacterID.ReadOnly = true;
            this.CharacterID.Width = 43;
            // 
            // RefreshToken
            // 
            this.RefreshToken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RefreshToken.HeaderText = "RefreshToken";
            this.RefreshToken.Name = "RefreshToken";
            this.RefreshToken.ReadOnly = true;
            // 
            // Remove
            // 
            this.Remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Remove.HeaderText = "Remove";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Text = "Remove";
            this.Remove.Width = 53;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 739);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "EVE Desktop";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.desktopPage.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.charactersDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage desktopPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView charactersDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CharacterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CharacterID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefreshToken;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addCharacterButton;
        private System.Windows.Forms.TextBox addCharacterTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private CharactersOverview charactersOverview;
    }
}

