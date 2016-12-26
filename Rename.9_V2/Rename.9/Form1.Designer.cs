namespace Episode_Names
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnNumber = new System.Windows.Forms.Button();
            this.nbPosition = new System.Windows.Forms.NumericUpDown();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.txtSplit = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SettingSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anisearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getFileNamesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.searchReplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.cmbOption = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblReplace = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nbPosition)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ReshowDelay = 100;
            // 
            // btnNumber
            // 
            this.btnNumber.Location = new System.Drawing.Point(111, 85);
            this.btnNumber.Name = "btnNumber";
            this.btnNumber.Size = new System.Drawing.Size(75, 23);
            this.btnNumber.TabIndex = 21;
            this.btnNumber.Text = "&Number";
            this.toolTip1.SetToolTip(this.btnNumber, "Durchnummerieren der Dateien");
            this.btnNumber.UseVisualStyleBackColor = true;
            this.btnNumber.Click += new System.EventHandler(this.bntNumber_Click);
            // 
            // nbPosition
            // 
            this.nbPosition.Location = new System.Drawing.Point(588, 85);
            this.nbPosition.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbPosition.Name = "nbPosition";
            this.nbPosition.Size = new System.Drawing.Size(40, 20);
            this.nbPosition.TabIndex = 25;
            this.toolTip1.SetToolTip(this.nbPosition, "Gibt an welcher Teil der aufgeteilten Zeile genommen werden soll");
            this.nbPosition.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(202, 85);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 22;
            this.btnRestore.Text = "R&estore";
            this.toolTip1.SetToolTip(this.btnRestore, "Wiederherstellen der vorherigen Titel");
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnRename
            // 
            this.btnRename.AccessibleDescription = "";
            this.btnRename.Location = new System.Drawing.Point(21, 85);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 20;
            this.btnRename.Tag = "";
            this.btnRename.Text = "&Rename";
            this.toolTip1.SetToolTip(this.btnRename, "Umbenennen der Dateien");
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.Rename_Click);
            // 
            // txtSplit
            // 
            this.txtSplit.Location = new System.Drawing.Point(416, 85);
            this.txtSplit.Name = "txtSplit";
            this.txtSplit.Size = new System.Drawing.Size(113, 20);
            this.txtSplit.TabIndex = 24;
            this.txtSplit.Leave += new System.EventHandler(this.txtSplit_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingSettingsToolStripMenuItem,
            this.insertDataToolStripMenuItem,
            this.searchReplaceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SettingSettingsToolStripMenuItem
            // 
            this.SettingSettingsToolStripMenuItem.Name = "SettingSettingsToolStripMenuItem";
            this.SettingSettingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.SettingSettingsToolStripMenuItem.Text = "Settings";
            this.SettingSettingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // insertDataToolStripMenuItem
            // 
            this.insertDataToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.insertDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDataToolStripMenuItem,
            this.editDataToolStripMenuItem,
            this.anisearchToolStripMenuItem,
            this.getFileNamesToolStripMenuItem1});
            this.insertDataToolStripMenuItem.Name = "insertDataToolStripMenuItem";
            this.insertDataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.insertDataToolStripMenuItem.Text = "Data";
            // 
            // newDataToolStripMenuItem
            // 
            this.newDataToolStripMenuItem.Name = "newDataToolStripMenuItem";
            this.newDataToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newDataToolStripMenuItem.Text = "New Data";
            this.newDataToolStripMenuItem.Click += new System.EventHandler(this.insertDataToolStripMenuItem_Click);
            // 
            // editDataToolStripMenuItem
            // 
            this.editDataToolStripMenuItem.Name = "editDataToolStripMenuItem";
            this.editDataToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.editDataToolStripMenuItem.Text = "Edit Data";
            this.editDataToolStripMenuItem.Click += new System.EventHandler(this.editDataToolStripMenuItem_Click);
            // 
            // anisearchToolStripMenuItem
            // 
            this.anisearchToolStripMenuItem.Name = "anisearchToolStripMenuItem";
            this.anisearchToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.anisearchToolStripMenuItem.Text = "Anisearch";
            this.anisearchToolStripMenuItem.Click += new System.EventHandler(this.anisearchToolStripMenuItem_Click);
            // 
            // getFileNamesToolStripMenuItem1
            // 
            this.getFileNamesToolStripMenuItem1.Name = "getFileNamesToolStripMenuItem1";
            this.getFileNamesToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.getFileNamesToolStripMenuItem1.Text = "Get File-Names";
            this.getFileNamesToolStripMenuItem1.Click += new System.EventHandler(this.getFileNamesToolStripMenuItem_Click);
            // 
            // searchReplaceToolStripMenuItem
            // 
            this.searchReplaceToolStripMenuItem.Name = "searchReplaceToolStripMenuItem";
            this.searchReplaceToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.searchReplaceToolStripMenuItem.Text = "Search && Replace";
            this.searchReplaceToolStripMenuItem.Click += new System.EventHandler(this.searchReplaceToolStripMenuItem_Click);
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(553, 46);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFolder.TabIndex = 19;
            this.btnBrowseFolder.Text = "&Browse";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(535, 88);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(47, 13);
            this.lblPosition.TabIndex = 26;
            this.lblPosition.Text = "Position:";
            // 
            // txtMessage
            // 
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(21, 149);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(607, 20);
            this.txtMessage.TabIndex = 23;
            // 
            // pgBar
            // 
            this.pgBar.AccessibleName = "";
            this.pgBar.Location = new System.Drawing.Point(20, 123);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(608, 20);
            this.pgBar.TabIndex = 21;
            this.pgBar.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Path:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(21, 48);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(508, 20);
            this.txtPath.TabIndex = 18;
            // 
            // cmbOption
            // 
            this.cmbOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOption.FormattingEnabled = true;
            this.cmbOption.Items.AddRange(new object[] {
            "Split-String",
            "Delete Positions",
            "Insert Position"});
            this.cmbOption.Location = new System.Drawing.Point(293, 85);
            this.cmbOption.Name = "cmbOption";
            this.cmbOption.Size = new System.Drawing.Size(108, 21);
            this.cmbOption.TabIndex = 23;
            this.cmbOption.SelectedIndexChanged += new System.EventHandler(this.cmbOption_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(293, 85);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 20);
            this.txtSearch.TabIndex = 23;
            this.txtSearch.Visible = false;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(290, 69);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(74, 13);
            this.lblSearch.TabIndex = 32;
            this.lblSearch.Text = "Search-String:";
            this.lblSearch.Visible = false;
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Location = new System.Drawing.Point(465, 69);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(80, 13);
            this.lblReplace.TabIndex = 33;
            this.lblReplace.Text = "Replace-String:";
            this.lblReplace.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(652, 183);
            this.Controls.Add(this.lblReplace);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.cmbOption);
            this.Controls.Add(this.txtSplit);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.btnNumber);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.nbPosition);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.pgBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Episode-Names";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nbPosition)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem insertDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anisearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getFileNamesToolStripMenuItem1;
        private System.Windows.Forms.TextBox txtSplit;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Button btnNumber;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.NumericUpDown nbPosition;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.ProgressBar pgBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.ToolStripMenuItem searchReplaceToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbOption;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblReplace;
    }
}

