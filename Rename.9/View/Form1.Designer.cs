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
            this.btnRename = new System.Windows.Forms.Button();
            this.txtSplit = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rückgängigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wiederholenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getFileNamesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ordnernamenHolenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sucheAufWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchReplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.Label();
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.cmbOption = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblReplace = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.HistoryWorker = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.CPFormat = new CustomControls.CollapsePanel();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.CmBPreset = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtFormat = new CustomControls.FormatTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nbNumber = new System.Windows.Forms.NumericUpDown();
            this.TxtPresetName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nbPosition)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.CPFormat.WorkingArea.SuspendLayout();
            this.CPFormat.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbNumber)).BeginInit();
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
            this.btnNumber.Location = new System.Drawing.Point(238, 80);
            this.btnNumber.Name = "btnNumber";
            this.btnNumber.Size = new System.Drawing.Size(105, 23);
            this.btnNumber.TabIndex = 21;
            this.btnNumber.Text = "Nummerieren";
            this.toolTip1.SetToolTip(this.btnNumber, "Durchnummerieren der Dateien");
            this.btnNumber.UseVisualStyleBackColor = true;
            this.btnNumber.Click += new System.EventHandler(this.bntNumber_Click);
            // 
            // nbPosition
            // 
            this.nbPosition.Location = new System.Drawing.Point(670, 85);
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
            // btnRename
            // 
            this.btnRename.AccessibleDescription = "";
            this.btnRename.Location = new System.Drawing.Point(124, 80);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(92, 23);
            this.btnRename.TabIndex = 20;
            this.btnRename.Tag = "";
            this.btnRename.Text = "Umbenennen";
            this.toolTip1.SetToolTip(this.btnRename, "Umbenennen der Dateien");
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.Rename_Click);
            // 
            // txtSplit
            // 
            this.txtSplit.Location = new System.Drawing.Point(467, 82);
            this.txtSplit.Name = "txtSplit";
            this.txtSplit.Size = new System.Drawing.Size(113, 20);
            this.txtSplit.TabIndex = 24;
            this.txtSplit.Leave += new System.EventHandler(this.txtSplit_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bearbeitenToolStripMenuItem,
            this.insertDataToolStripMenuItem,
            this.sucheAufWebsiteToolStripMenuItem,
            this.searchReplaceToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(722, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rückgängigToolStripMenuItem,
            this.wiederholenToolStripMenuItem,
            this.einstellungenToolStripMenuItem});
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // rückgängigToolStripMenuItem
            // 
            this.rückgängigToolStripMenuItem.Name = "rückgängigToolStripMenuItem";
            this.rückgängigToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.rückgängigToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.rückgängigToolStripMenuItem.Text = "Rückgängig";
            this.rückgängigToolStripMenuItem.Click += new System.EventHandler(this.GoBack_Click);
            // 
            // wiederholenToolStripMenuItem
            // 
            this.wiederholenToolStripMenuItem.Name = "wiederholenToolStripMenuItem";
            this.wiederholenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.wiederholenToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.wiederholenToolStripMenuItem.Text = "Wiederholen";
            this.wiederholenToolStripMenuItem.Click += new System.EventHandler(this.GoForward_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            this.einstellungenToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // insertDataToolStripMenuItem
            // 
            this.insertDataToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.insertDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDataToolStripMenuItem,
            this.editDataToolStripMenuItem,
            this.getFileNamesToolStripMenuItem1,
            this.ordnernamenHolenToolStripMenuItem});
            this.insertDataToolStripMenuItem.Name = "insertDataToolStripMenuItem";
            this.insertDataToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.insertDataToolStripMenuItem.Text = "Daten";
            // 
            // newDataToolStripMenuItem
            // 
            this.newDataToolStripMenuItem.Name = "newDataToolStripMenuItem";
            this.newDataToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.newDataToolStripMenuItem.Text = "Neue Daten";
            this.newDataToolStripMenuItem.Click += new System.EventHandler(this.insertDataToolStripMenuItem_Click);
            // 
            // editDataToolStripMenuItem
            // 
            this.editDataToolStripMenuItem.Name = "editDataToolStripMenuItem";
            this.editDataToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.editDataToolStripMenuItem.Text = "Daten bearbeiten";
            this.editDataToolStripMenuItem.Click += new System.EventHandler(this.editDataToolStripMenuItem_Click);
            // 
            // getFileNamesToolStripMenuItem1
            // 
            this.getFileNamesToolStripMenuItem1.Name = "getFileNamesToolStripMenuItem1";
            this.getFileNamesToolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.getFileNamesToolStripMenuItem1.Text = "Dateinamen holen";
            this.getFileNamesToolStripMenuItem1.Click += new System.EventHandler(this.getFileNamesToolStripMenuItem_Click);
            // 
            // ordnernamenHolenToolStripMenuItem
            // 
            this.ordnernamenHolenToolStripMenuItem.Name = "ordnernamenHolenToolStripMenuItem";
            this.ordnernamenHolenToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ordnernamenHolenToolStripMenuItem.Text = "Ordnernamen holen";
            this.ordnernamenHolenToolStripMenuItem.Click += new System.EventHandler(this.ordnernamenHolenToolStripMenuItem_Click);
            // 
            // sucheAufWebsiteToolStripMenuItem
            // 
            this.sucheAufWebsiteToolStripMenuItem.Name = "sucheAufWebsiteToolStripMenuItem";
            this.sucheAufWebsiteToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.sucheAufWebsiteToolStripMenuItem.Text = "Suche auf Website";
            this.sucheAufWebsiteToolStripMenuItem.Click += new System.EventHandler(this.anisearchToolStripMenuItem_Click);
            // 
            // searchReplaceToolStripMenuItem
            // 
            this.searchReplaceToolStripMenuItem.Name = "searchReplaceToolStripMenuItem";
            this.searchReplaceToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.searchReplaceToolStripMenuItem.Text = "Suchen && Ersetzen";
            this.searchReplaceToolStripMenuItem.Click += new System.EventHandler(this.searchReplaceToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(635, 46);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFolder.TabIndex = 19;
            this.btnBrowseFolder.Text = "Suchen";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(617, 87);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(47, 13);
            this.lblPosition.TabIndex = 26;
            this.lblPosition.Text = "Position:";
            // 
            // pgBar
            // 
            this.pgBar.AccessibleName = "";
            this.pgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgBar.Location = new System.Drawing.Point(0, 336);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(722, 20);
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
            this.label1.Text = "Pfad:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(21, 48);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(608, 20);
            this.txtPath.TabIndex = 18;
            // 
            // cmbOption
            // 
            this.cmbOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOption.FormattingEnabled = true;
            this.cmbOption.Items.AddRange(new object[] {
            "Text aufspalten",
            "Positionen löschen",
            "Bei Position einfügen"});
            this.cmbOption.Location = new System.Drawing.Point(353, 82);
            this.cmbOption.Name = "cmbOption";
            this.cmbOption.Size = new System.Drawing.Size(108, 21);
            this.cmbOption.TabIndex = 23;
            this.cmbOption.SelectedIndexChanged += new System.EventHandler(this.cmbOption_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(353, 82);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 20);
            this.txtSearch.TabIndex = 23;
            this.txtSearch.Visible = false;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(350, 69);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(52, 13);
            this.lblSearch.TabIndex = 32;
            this.lblSearch.Text = "Suchtext:";
            this.lblSearch.Visible = false;
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Location = new System.Drawing.Point(525, 69);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(81, 13);
            this.lblReplace.TabIndex = 33;
            this.lblReplace.Text = "Ersetzen durch:";
            this.lblReplace.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 359);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(722, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 34;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LblMessage
            // 
            this.LblMessage.Name = "LblMessage";
            this.LblMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // HistoryWorker
            // 
            this.HistoryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.HistoryWorker_DoWork);
            this.HistoryWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.HistoryWorker_ProgressChanged);
            this.HistoryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.HistoryWorker_RunWorkerCompleted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Vorschau";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CPFormat
            // 
            this.CPFormat.Expanded = true;
            this.CPFormat.Location = new System.Drawing.Point(0, 121);
            this.CPFormat.Name = "CPFormat";
            this.CPFormat.Size = new System.Drawing.Size(722, 209);
            this.CPFormat.TabIndex = 37;
            this.CPFormat.Text = "Formatierung";
            // 
            // CPFormat.WorkingArea
            // 
            this.CPFormat.WorkingArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CPFormat.WorkingArea.Controls.Add(this.button4);
            this.CPFormat.WorkingArea.Controls.Add(this.button3);
            this.CPFormat.WorkingArea.Controls.Add(this.label13);
            this.CPFormat.WorkingArea.Controls.Add(this.TxtPresetName);
            this.CPFormat.WorkingArea.Controls.Add(this.button2);
            this.CPFormat.WorkingArea.Controls.Add(this.label9);
            this.CPFormat.WorkingArea.Controls.Add(this.CmBPreset);
            this.CPFormat.WorkingArea.Controls.Add(this.label10);
            this.CPFormat.WorkingArea.Controls.Add(this.TxtFormat);
            this.CPFormat.WorkingArea.Controls.Add(this.groupBox1);
            this.CPFormat.WorkingArea.Controls.Add(this.label2);
            this.CPFormat.WorkingArea.Controls.Add(this.nbNumber);
            this.CPFormat.WorkingArea.Location = new System.Drawing.Point(0, 22);
            this.CPFormat.WorkingArea.Name = "WorkingArea";
            this.CPFormat.WorkingArea.Size = new System.Drawing.Size(722, 187);
            this.CPFormat.WorkingArea.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(153, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 73;
            this.button2.Text = "Speichern";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 72;
            this.label9.Text = "Formatierung:";
            // 
            // CmBPreset
            // 
            this.CmBPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmBPreset.FormattingEnabled = true;
            this.CmBPreset.Items.AddRange(new object[] {
            "Vorlage1"});
            this.CmBPreset.Location = new System.Drawing.Point(12, 26);
            this.CmBPreset.Name = "CmBPreset";
            this.CmBPreset.Size = new System.Drawing.Size(121, 21);
            this.CmBPreset.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 70;
            this.label10.Text = "Vorlagen:";
            // 
            // TxtFormat
            // 
            this.TxtFormat.Location = new System.Drawing.Point(12, 153);
            this.TxtFormat.Name = "TxtFormat";
            this.TxtFormat.Size = new System.Drawing.Size(430, 20);
            this.TxtFormat.TabIndex = 69;
            this.TxtFormat.Valid = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(465, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 174);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Legende";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Nummerierung:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(118, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "%dir";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "%n";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Ordnername:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Aufspalt-Position:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "%1 ..... %100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "%pos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Position:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Startnummer:";
            // 
            // nbNumber
            // 
            this.nbNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nbNumber.Location = new System.Drawing.Point(153, 113);
            this.nbNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbNumber.Name = "nbNumber";
            this.nbNumber.Size = new System.Drawing.Size(75, 20);
            this.nbNumber.TabIndex = 63;
            this.nbNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TxtPresetName
            // 
            this.TxtPresetName.Location = new System.Drawing.Point(12, 70);
            this.TxtPresetName.Name = "TxtPresetName";
            this.TxtPresetName.Size = new System.Drawing.Size(121, 20);
            this.TxtPresetName.TabIndex = 74;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 75;
            this.label13.Text = "Name:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(153, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 76;
            this.button3.Text = "Laden";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(249, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 77;
            this.button4.Text = "Löschen";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(722, 381);
            this.Controls.Add(this.CPFormat);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblReplace);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.cmbOption);
            this.Controls.Add(this.txtSplit);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.btnNumber);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.nbPosition);
            this.Controls.Add(this.pgBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.CPFormat.WorkingArea.ResumeLayout(false);
            this.CPFormat.WorkingArea.PerformLayout();
            this.CPFormat.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem insertDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getFileNamesToolStripMenuItem1;
        private System.Windows.Forms.TextBox txtSplit;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Button btnNumber;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.NumericUpDown nbPosition;
        private System.Windows.Forms.ProgressBar pgBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.ToolStripMenuItem searchReplaceToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbOption;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblReplace;
        private System.Windows.Forms.ToolStripMenuItem sucheAufWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordnernamenHolenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rückgängigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wiederholenToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LblMessage;
        private System.ComponentModel.BackgroundWorker HistoryWorker;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private CustomControls.CollapsePanel CPFormat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nbNumber;
        private CustomControls.FormatTextBox TxtFormat;
        private System.Windows.Forms.ComboBox CmBPreset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtPresetName;
    }
}

