namespace CapitalBuildManagerApp
{
	partial class MainForm
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
			this.Tabs = new System.Windows.Forms.TabControl();
			this.OverviewTab = new System.Windows.Forms.TabPage();
			this.JobsList = new System.Windows.Forms.ListView();
			this.JobsTab = new System.Windows.Forms.TabPage();
			this.FacilitiesTab = new System.Windows.Forms.TabPage();
			this.BlueprintsTab = new System.Windows.Forms.TabPage();
			this.CopyingTab = new System.Windows.Forms.TabPage();
			this.ManufacturingTab = new System.Windows.Forms.TabPage();
			this.MaterialsTab = new System.Windows.Forms.TabPage();
			this.ApiTab = new System.Windows.Forms.TabPage();
			this.ApiListLabel = new System.Windows.Forms.Label();
			this.APIGridView = new System.Windows.Forms.DataGridView();
			this.AddAPIButton = new System.Windows.Forms.Button();
			this.APIInfoLabel = new System.Windows.Forms.Label();
			this.APIvCodeTextBox = new System.Windows.Forms.TextBox();
			this.VCodeLabel = new System.Windows.Forms.Label();
			this.KeyIDLabel = new System.Windows.Forms.Label();
			this.APIKeyIDTextbox = new System.Windows.Forms.TextBox();
			this.AddAPILabel = new System.Windows.Forms.Label();
			this.MenuBar = new System.Windows.Forms.ToolStrip();
			this.CharactersColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.KeyIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DeleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Tabs.SuspendLayout();
			this.OverviewTab.SuspendLayout();
			this.ApiTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.APIGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// Tabs
			// 
			this.Tabs.Controls.Add(this.OverviewTab);
			this.Tabs.Controls.Add(this.JobsTab);
			this.Tabs.Controls.Add(this.FacilitiesTab);
			this.Tabs.Controls.Add(this.BlueprintsTab);
			this.Tabs.Controls.Add(this.CopyingTab);
			this.Tabs.Controls.Add(this.ManufacturingTab);
			this.Tabs.Controls.Add(this.MaterialsTab);
			this.Tabs.Controls.Add(this.ApiTab);
			this.Tabs.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Tabs.Location = new System.Drawing.Point(0, 28);
			this.Tabs.Name = "Tabs";
			this.Tabs.SelectedIndex = 0;
			this.Tabs.Size = new System.Drawing.Size(919, 631);
			this.Tabs.TabIndex = 0;
			// 
			// OverviewTab
			// 
			this.OverviewTab.Controls.Add(this.JobsList);
			this.OverviewTab.Location = new System.Drawing.Point(4, 22);
			this.OverviewTab.Name = "OverviewTab";
			this.OverviewTab.Size = new System.Drawing.Size(911, 605);
			this.OverviewTab.TabIndex = 6;
			this.OverviewTab.Text = "Overview";
			this.OverviewTab.UseVisualStyleBackColor = true;
			// 
			// JobsList
			// 
			this.JobsList.Location = new System.Drawing.Point(15, 13);
			this.JobsList.Name = "JobsList";
			this.JobsList.Size = new System.Drawing.Size(269, 154);
			this.JobsList.TabIndex = 0;
			this.JobsList.UseCompatibleStateImageBehavior = false;
			// 
			// JobsTab
			// 
			this.JobsTab.Location = new System.Drawing.Point(4, 22);
			this.JobsTab.Name = "JobsTab";
			this.JobsTab.Padding = new System.Windows.Forms.Padding(3);
			this.JobsTab.Size = new System.Drawing.Size(911, 605);
			this.JobsTab.TabIndex = 0;
			this.JobsTab.Text = "Jobs";
			this.JobsTab.UseVisualStyleBackColor = true;
			// 
			// FacilitiesTab
			// 
			this.FacilitiesTab.Location = new System.Drawing.Point(4, 22);
			this.FacilitiesTab.Name = "FacilitiesTab";
			this.FacilitiesTab.Padding = new System.Windows.Forms.Padding(3);
			this.FacilitiesTab.Size = new System.Drawing.Size(911, 605);
			this.FacilitiesTab.TabIndex = 1;
			this.FacilitiesTab.Text = "Facilities";
			this.FacilitiesTab.UseVisualStyleBackColor = true;
			// 
			// BlueprintsTab
			// 
			this.BlueprintsTab.Location = new System.Drawing.Point(4, 22);
			this.BlueprintsTab.Name = "BlueprintsTab";
			this.BlueprintsTab.Size = new System.Drawing.Size(911, 605);
			this.BlueprintsTab.TabIndex = 2;
			this.BlueprintsTab.Text = "Blueprints";
			this.BlueprintsTab.UseVisualStyleBackColor = true;
			// 
			// CopyingTab
			// 
			this.CopyingTab.Location = new System.Drawing.Point(4, 22);
			this.CopyingTab.Name = "CopyingTab";
			this.CopyingTab.Size = new System.Drawing.Size(911, 605);
			this.CopyingTab.TabIndex = 3;
			this.CopyingTab.Text = "Copying";
			this.CopyingTab.UseVisualStyleBackColor = true;
			// 
			// ManufacturingTab
			// 
			this.ManufacturingTab.Location = new System.Drawing.Point(4, 22);
			this.ManufacturingTab.Name = "ManufacturingTab";
			this.ManufacturingTab.Size = new System.Drawing.Size(911, 605);
			this.ManufacturingTab.TabIndex = 4;
			this.ManufacturingTab.Text = "Manufacturing";
			this.ManufacturingTab.UseVisualStyleBackColor = true;
			// 
			// MaterialsTab
			// 
			this.MaterialsTab.Location = new System.Drawing.Point(4, 22);
			this.MaterialsTab.Name = "MaterialsTab";
			this.MaterialsTab.Size = new System.Drawing.Size(911, 605);
			this.MaterialsTab.TabIndex = 5;
			this.MaterialsTab.Text = "Materials";
			this.MaterialsTab.UseVisualStyleBackColor = true;
			// 
			// ApiTab
			// 
			this.ApiTab.Controls.Add(this.ApiListLabel);
			this.ApiTab.Controls.Add(this.APIGridView);
			this.ApiTab.Controls.Add(this.AddAPIButton);
			this.ApiTab.Controls.Add(this.APIInfoLabel);
			this.ApiTab.Controls.Add(this.APIvCodeTextBox);
			this.ApiTab.Controls.Add(this.VCodeLabel);
			this.ApiTab.Controls.Add(this.KeyIDLabel);
			this.ApiTab.Controls.Add(this.APIKeyIDTextbox);
			this.ApiTab.Controls.Add(this.AddAPILabel);
			this.ApiTab.Location = new System.Drawing.Point(4, 22);
			this.ApiTab.Name = "ApiTab";
			this.ApiTab.Size = new System.Drawing.Size(911, 605);
			this.ApiTab.TabIndex = 7;
			this.ApiTab.Text = "APIs";
			this.ApiTab.UseVisualStyleBackColor = true;
			// 
			// ApiListLabel
			// 
			this.ApiListLabel.AutoSize = true;
			this.ApiListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ApiListLabel.Location = new System.Drawing.Point(73, 227);
			this.ApiListLabel.Name = "ApiListLabel";
			this.ApiListLabel.Size = new System.Drawing.Size(47, 20);
			this.ApiListLabel.TabIndex = 8;
			this.ApiListLabel.Text = "APIs";
			// 
			// APIGridView
			// 
			this.APIGridView.AllowUserToAddRows = false;
			this.APIGridView.AllowUserToDeleteRows = false;
			this.APIGridView.AllowUserToResizeRows = false;
			this.APIGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.APIGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CharactersColumn,
            this.KeyIDColumn,
            this.vCodeColumn,
            this.DeleteColumn});
			this.APIGridView.Location = new System.Drawing.Point(77, 259);
			this.APIGridView.Name = "APIGridView";
			this.APIGridView.RowHeadersVisible = false;
			this.APIGridView.Size = new System.Drawing.Size(707, 150);
			this.APIGridView.TabIndex = 7;
			this.APIGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.APIGridView_CellContentClick);
			// 
			// AddAPIButton
			// 
			this.AddAPIButton.Location = new System.Drawing.Point(122, 118);
			this.AddAPIButton.Name = "AddAPIButton";
			this.AddAPIButton.Size = new System.Drawing.Size(89, 26);
			this.AddAPIButton.TabIndex = 6;
			this.AddAPIButton.Text = "Add";
			this.AddAPIButton.UseVisualStyleBackColor = true;
			this.AddAPIButton.Click += new System.EventHandler(this.AddAPIButton_Click);
			// 
			// APIInfoLabel
			// 
			this.APIInfoLabel.AutoSize = true;
			this.APIInfoLabel.Location = new System.Drawing.Point(74, 53);
			this.APIInfoLabel.Name = "APIInfoLabel";
			this.APIInfoLabel.Size = new System.Drawing.Size(339, 13);
			this.APIInfoLabel.TabIndex = 5;
			this.APIInfoLabel.Text = "Must have IndustryJobs and AssetList selected, and no expiration date";
			// 
			// APIvCodeTextBox
			// 
			this.APIvCodeTextBox.Location = new System.Drawing.Point(293, 80);
			this.APIvCodeTextBox.Name = "APIvCodeTextBox";
			this.APIvCodeTextBox.Size = new System.Drawing.Size(315, 20);
			this.APIvCodeTextBox.TabIndex = 4;
			// 
			// VCodeLabel
			// 
			this.VCodeLabel.AutoSize = true;
			this.VCodeLabel.Location = new System.Drawing.Point(246, 83);
			this.VCodeLabel.Name = "VCodeLabel";
			this.VCodeLabel.Size = new System.Drawing.Size(41, 13);
			this.VCodeLabel.TabIndex = 3;
			this.VCodeLabel.Text = "vCode:";
			// 
			// KeyIDLabel
			// 
			this.KeyIDLabel.AutoSize = true;
			this.KeyIDLabel.Location = new System.Drawing.Point(74, 83);
			this.KeyIDLabel.Name = "KeyIDLabel";
			this.KeyIDLabel.Size = new System.Drawing.Size(42, 13);
			this.KeyIDLabel.TabIndex = 2;
			this.KeyIDLabel.Text = "Key ID:";
			// 
			// APIKeyIDTextbox
			// 
			this.APIKeyIDTextbox.Location = new System.Drawing.Point(122, 80);
			this.APIKeyIDTextbox.Name = "APIKeyIDTextbox";
			this.APIKeyIDTextbox.Size = new System.Drawing.Size(100, 20);
			this.APIKeyIDTextbox.TabIndex = 1;
			// 
			// AddAPILabel
			// 
			this.AddAPILabel.AutoSize = true;
			this.AddAPILabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddAPILabel.Location = new System.Drawing.Point(73, 21);
			this.AddAPILabel.Name = "AddAPILabel";
			this.AddAPILabel.Size = new System.Drawing.Size(100, 20);
			this.AddAPILabel.TabIndex = 0;
			this.AddAPILabel.Text = "Add an API";
			// 
			// MenuBar
			// 
			this.MenuBar.AllowMerge = false;
			this.MenuBar.GripMargin = new System.Windows.Forms.Padding(0);
			this.MenuBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.MenuBar.Location = new System.Drawing.Point(0, 0);
			this.MenuBar.Name = "MenuBar";
			this.MenuBar.Size = new System.Drawing.Size(919, 25);
			this.MenuBar.TabIndex = 1;
			this.MenuBar.Text = "ToolStrip";
			// 
			// CharactersColumn
			// 
			this.CharactersColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.CharactersColumn.HeaderText = "Characters";
			this.CharactersColumn.Name = "CharactersColumn";
			this.CharactersColumn.ReadOnly = true;
			this.CharactersColumn.Width = 83;
			// 
			// KeyIDColumn
			// 
			this.KeyIDColumn.HeaderText = "Key ID";
			this.KeyIDColumn.Name = "KeyIDColumn";
			this.KeyIDColumn.ReadOnly = true;
			// 
			// vCodeColumn
			// 
			this.vCodeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.vCodeColumn.HeaderText = "Verification Code";
			this.vCodeColumn.Name = "vCodeColumn";
			this.vCodeColumn.ReadOnly = true;
			// 
			// DeleteColumn
			// 
			this.DeleteColumn.HeaderText = "Delete API Key";
			this.DeleteColumn.Name = "DeleteColumn";
			this.DeleteColumn.ReadOnly = true;
			this.DeleteColumn.Text = "Delete";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(919, 659);
			this.Controls.Add(this.MenuBar);
			this.Controls.Add(this.Tabs);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.Tabs.ResumeLayout(false);
			this.OverviewTab.ResumeLayout(false);
			this.ApiTab.ResumeLayout(false);
			this.ApiTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.APIGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl Tabs;
		private System.Windows.Forms.TabPage OverviewTab;
		private System.Windows.Forms.TabPage JobsTab;
		private System.Windows.Forms.TabPage FacilitiesTab;
		private System.Windows.Forms.TabPage BlueprintsTab;
		private System.Windows.Forms.TabPage CopyingTab;
		private System.Windows.Forms.TabPage ManufacturingTab;
		private System.Windows.Forms.TabPage MaterialsTab;
		private System.Windows.Forms.ListView JobsList;
		private System.Windows.Forms.ToolStrip MenuBar;
		private System.Windows.Forms.TabPage ApiTab;
		private System.Windows.Forms.Button AddAPIButton;
		private System.Windows.Forms.Label APIInfoLabel;
		private System.Windows.Forms.TextBox APIvCodeTextBox;
		private System.Windows.Forms.Label VCodeLabel;
		private System.Windows.Forms.Label KeyIDLabel;
		private System.Windows.Forms.TextBox APIKeyIDTextbox;
		private System.Windows.Forms.Label AddAPILabel;
		private System.Windows.Forms.Label ApiListLabel;
		private System.Windows.Forms.DataGridView APIGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn CharactersColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn KeyIDColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn vCodeColumn;
		private System.Windows.Forms.DataGridViewButtonColumn DeleteColumn;
	}
}

