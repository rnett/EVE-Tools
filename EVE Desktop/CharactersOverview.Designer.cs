namespace EVE_Desktop
{
    partial class CharactersOverview
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

            this.desktopLayout = new System.Windows.Forms.TableLayoutPanel();
            this.charOverviews = new System.Windows.Forms.FlowLayoutPanel();
            this.indyJobsPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.industryJobsDGV = new System.Windows.Forms.DataGridView();
            this.CharacterIJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeIJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationIJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RunsIJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinishDateIJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketPanel = new System.Windows.Forms.Panel();
            this.contracts2Panel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.recentContractsDGV = new System.Windows.Forms.DataGridView();
            this.CharacterRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinishedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractsPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.ieContractsDGV = new System.Windows.Forms.DataGridView();
            this.CharacterIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpiresIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.courierContractsDGV = new System.Windows.Forms.DataGridView();
            this.CharacterCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColatCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcceptedDateCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDateCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addCharacterButton = new System.Windows.Forms.Button();
            this.addCharacterTB = new System.Windows.Forms.TextBox();
            this.CharacterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CharacterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefreshToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.desktopLayout.SuspendLayout();
            this.indyJobsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.industryJobsDGV)).BeginInit();
            this.contracts2Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentContractsDGV)).BeginInit();
            this.contractsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ieContractsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courierContractsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // desktopLayout
            // 
            this.desktopLayout.ColumnCount = 3;
            this.desktopLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.desktopLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.desktopLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.desktopLayout.Controls.Add(this.charOverviews, 0, 0);
            this.desktopLayout.Controls.Add(this.indyJobsPanel, 0, 1);
            this.desktopLayout.Controls.Add(this.marketPanel, 0, 1);
            this.desktopLayout.Controls.Add(this.contracts2Panel, 1, 1);
            this.desktopLayout.Controls.Add(this.contractsPanel, 2, 0);
            this.desktopLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desktopLayout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.desktopLayout.Location = new System.Drawing.Point(3, 3);
            this.desktopLayout.Name = "desktopLayout";
            this.desktopLayout.RowCount = 2;
            this.desktopLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.desktopLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.desktopLayout.Size = new System.Drawing.Size(1386, 707);
            this.desktopLayout.TabIndex = 0;
            // 
            // charOverviews
            // 
            this.charOverviews.BackColor = System.Drawing.SystemColors.ControlLight;
            this.desktopLayout.SetColumnSpan(this.charOverviews, 2);
            this.charOverviews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.charOverviews.Location = new System.Drawing.Point(3, 3);
            this.charOverviews.Name = "charOverviews";
            this.charOverviews.Padding = new System.Windows.Forms.Padding(2);
            this.charOverviews.Size = new System.Drawing.Size(918, 347);
            this.charOverviews.TabIndex = 18;
            // 
            // indyJobsPanel
            // 
            this.indyJobsPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.indyJobsPanel.Controls.Add(this.label7);
            this.indyJobsPanel.Controls.Add(this.industryJobsDGV);
            this.indyJobsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indyJobsPanel.Location = new System.Drawing.Point(465, 356);
            this.indyJobsPanel.Name = "indyJobsPanel";
            this.indyJobsPanel.Size = new System.Drawing.Size(456, 348);
            this.indyJobsPanel.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Industry Jobs";
            // 
            // industryJobsDGV
            // 
            this.industryJobsDGV.AllowUserToAddRows = false;
            this.industryJobsDGV.AllowUserToDeleteRows = false;
            this.industryJobsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.industryJobsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.industryJobsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CharacterIJ,
            this.TypeIJ,
            this.LocationIJ,
            this.RunsIJ,
            this.Product,
            this.FinishDateIJ});
            this.industryJobsDGV.Location = new System.Drawing.Point(3, 25);
            this.industryJobsDGV.Name = "industryJobsDGV";
            this.industryJobsDGV.RowHeadersVisible = false;
            this.industryJobsDGV.Size = new System.Drawing.Size(453, 323);
            this.industryJobsDGV.TabIndex = 5;
            // 
            // CharacterIJ
            // 
            this.CharacterIJ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CharacterIJ.HeaderText = "Character";
            this.CharacterIJ.Name = "CharacterIJ";
            this.CharacterIJ.ReadOnly = true;
            this.CharacterIJ.Width = 78;
            // 
            // TypeIJ
            // 
            this.TypeIJ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TypeIJ.HeaderText = "Type";
            this.TypeIJ.Name = "TypeIJ";
            this.TypeIJ.ReadOnly = true;
            this.TypeIJ.Width = 56;
            // 
            // LocationIJ
            // 
            this.LocationIJ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LocationIJ.HeaderText = "Location";
            this.LocationIJ.Name = "LocationIJ";
            this.LocationIJ.ReadOnly = true;
            // 
            // RunsIJ
            // 
            this.RunsIJ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RunsIJ.HeaderText = "Runs";
            this.RunsIJ.Name = "RunsIJ";
            this.RunsIJ.ReadOnly = true;
            this.RunsIJ.Width = 57;
            // 
            // Product
            // 
            this.Product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Width = 69;
            // 
            // FinishDateIJ
            // 
            this.FinishDateIJ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FinishDateIJ.HeaderText = "Finish Date";
            this.FinishDateIJ.Name = "FinishDateIJ";
            this.FinishDateIJ.ReadOnly = true;
            this.FinishDateIJ.Width = 85;
            // 
            // marketPanel
            // 
            this.marketPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.marketPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marketPanel.Location = new System.Drawing.Point(3, 356);
            this.marketPanel.Name = "marketPanel";
            this.marketPanel.Size = new System.Drawing.Size(456, 348);
            this.marketPanel.TabIndex = 12;
            // 
            // contracts2Panel
            // 
            this.contracts2Panel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.contracts2Panel.Controls.Add(this.label6);
            this.contracts2Panel.Controls.Add(this.recentContractsDGV);
            this.contracts2Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contracts2Panel.Location = new System.Drawing.Point(927, 356);
            this.contracts2Panel.Name = "contracts2Panel";
            this.contracts2Panel.Size = new System.Drawing.Size(456, 348);
            this.contracts2Panel.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Recently Completed Contracts";
            // 
            // recentContractsDGV
            // 
            this.recentContractsDGV.AllowUserToAddRows = false;
            this.recentContractsDGV.AllowUserToDeleteRows = false;
            this.recentContractsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recentContractsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recentContractsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CharacterRC,
            this.Type,
            this.LocationRC,
            this.FinishedDate,
            this.Cost});
            this.recentContractsDGV.Location = new System.Drawing.Point(2, 25);
            this.recentContractsDGV.Name = "recentContractsDGV";
            this.recentContractsDGV.RowHeadersVisible = false;
            this.recentContractsDGV.Size = new System.Drawing.Size(453, 323);
            this.recentContractsDGV.TabIndex = 3;
            // 
            // CharacterRC
            // 
            this.CharacterRC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CharacterRC.HeaderText = "Character";
            this.CharacterRC.Name = "CharacterRC";
            this.CharacterRC.ReadOnly = true;
            this.CharacterRC.Width = 78;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 56;
            // 
            // LocationRC
            // 
            this.LocationRC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LocationRC.HeaderText = "Location";
            this.LocationRC.Name = "LocationRC";
            this.LocationRC.ReadOnly = true;
            // 
            // FinishedDate
            // 
            this.FinishedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FinishedDate.HeaderText = "Finished";
            this.FinishedDate.Name = "FinishedDate";
            this.FinishedDate.ReadOnly = true;
            this.FinishedDate.Width = 71;
            // 
            // Cost
            // 
            this.Cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cost.HeaderText = "Price or Collateral";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Width = 105;
            // 
            // contractsPanel
            // 
            this.contractsPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.contractsPanel.Controls.Add(this.splitContainer1);
            this.contractsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contractsPanel.Location = new System.Drawing.Point(927, 3);
            this.contractsPanel.Name = "contractsPanel";
            this.contractsPanel.Size = new System.Drawing.Size(456, 347);
            this.contractsPanel.TabIndex = 11;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.ieContractsDGV);
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.courierContractsDGV);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(456, 347);
            this.splitContainer1.SplitterDistance = 174;
            this.splitContainer1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Item Exchanges to me";
            // 
            // ieContractsDGV
            // 
            this.ieContractsDGV.AllowUserToAddRows = false;
            this.ieContractsDGV.AllowUserToDeleteRows = false;
            this.ieContractsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ieContractsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ieContractsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CharacterIE,
            this.LocationIE,
            this.PriceIE,
            this.CreatedIE,
            this.ExpiresIE});
            this.ieContractsDGV.Location = new System.Drawing.Point(0, 24);
            this.ieContractsDGV.Name = "ieContractsDGV";
            this.ieContractsDGV.RowHeadersVisible = false;
            this.ieContractsDGV.Size = new System.Drawing.Size(456, 150);
            this.ieContractsDGV.TabIndex = 5;
            // 
            // CharacterIE
            // 
            this.CharacterIE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CharacterIE.HeaderText = "Character";
            this.CharacterIE.Name = "CharacterIE";
            this.CharacterIE.ReadOnly = true;
            this.CharacterIE.Width = 78;
            // 
            // LocationIE
            // 
            this.LocationIE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LocationIE.HeaderText = "Location";
            this.LocationIE.Name = "LocationIE";
            this.LocationIE.ReadOnly = true;
            // 
            // PriceIE
            // 
            this.PriceIE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PriceIE.HeaderText = "Price";
            this.PriceIE.Name = "PriceIE";
            this.PriceIE.ReadOnly = true;
            this.PriceIE.Width = 56;
            // 
            // CreatedIE
            // 
            this.CreatedIE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CreatedIE.HeaderText = "Created";
            this.CreatedIE.Name = "CreatedIE";
            this.CreatedIE.ReadOnly = true;
            this.CreatedIE.Width = 69;
            // 
            // ExpiresIE
            // 
            this.ExpiresIE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ExpiresIE.HeaderText = "Expires";
            this.ExpiresIE.Name = "ExpiresIE";
            this.ExpiresIE.ReadOnly = true;
            this.ExpiresIE.Width = 66;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Unfinished Couriers";
            // 
            // courierContractsDGV
            // 
            this.courierContractsDGV.AllowUserToAddRows = false;
            this.courierContractsDGV.AllowUserToDeleteRows = false;
            this.courierContractsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.courierContractsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courierContractsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CharacterCC,
            this.Start,
            this.End,
            this.ColatCC,
            this.AcceptedDateCC,
            this.EndDateCC});
            this.courierContractsDGV.Location = new System.Drawing.Point(0, 19);
            this.courierContractsDGV.Name = "courierContractsDGV";
            this.courierContractsDGV.RowHeadersVisible = false;
            this.courierContractsDGV.Size = new System.Drawing.Size(456, 150);
            this.courierContractsDGV.TabIndex = 5;
            // 
            // CharacterCC
            // 
            this.CharacterCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CharacterCC.HeaderText = "Character";
            this.CharacterCC.Name = "CharacterCC";
            this.CharacterCC.ReadOnly = true;
            this.CharacterCC.Width = 78;
            // 
            // Start
            // 
            this.Start.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Start.HeaderText = "Start";
            this.Start.Name = "Start";
            this.Start.ReadOnly = true;
            // 
            // End
            // 
            this.End.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.End.HeaderText = "Dest";
            this.End.Name = "End";
            this.End.ReadOnly = true;
            // 
            // ColatCC
            // 
            this.ColatCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColatCC.HeaderText = "Collateral";
            this.ColatCC.Name = "ColatCC";
            this.ColatCC.ReadOnly = true;
            this.ColatCC.Width = 75;
            // 
            // AcceptedDateCC
            // 
            this.AcceptedDateCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.AcceptedDateCC.HeaderText = "Accepted";
            this.AcceptedDateCC.Name = "AcceptedDateCC";
            this.AcceptedDateCC.ReadOnly = true;
            this.AcceptedDateCC.Width = 78;
            // 
            // EndDateCC
            // 
            this.EndDateCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.EndDateCC.HeaderText = "Expires";
            this.EndDateCC.Name = "EndDateCC";
            this.EndDateCC.ReadOnly = true;
            this.EndDateCC.Width = 66;

            // 
            // CharactersOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CharactersOverview";
            this.Size = new System.Drawing.Size(1386, 707);
            this.Controls.Add(this.desktopLayout);

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel desktopLayout;
        private System.Windows.Forms.Panel marketPanel;
        private System.Windows.Forms.Panel contracts2Panel;
        private System.Windows.Forms.Panel contractsPanel;
        private System.Windows.Forms.Panel indyJobsPanel;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView recentContractsDGV;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView ieContractsDGV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView courierContractsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CharacterRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinishedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn CharacterCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn End;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColatCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcceptedDateCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDateCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CharacterIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpiresIE;
        private System.Windows.Forms.FlowLayoutPanel charOverviews;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView industryJobsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CharacterIJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeIJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationIJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn RunsIJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinishDateIJ;

    }
}
