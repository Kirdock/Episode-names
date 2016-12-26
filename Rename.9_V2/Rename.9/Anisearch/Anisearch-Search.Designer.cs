namespace Episode_Names.Anisearch
{
    partial class Anisearch_Search
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anisearch_Search));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.listResult = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openLinkInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbLang = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(379, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // pgBar
            // 
            this.pgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgBar.Location = new System.Drawing.Point(0, 20);
            this.pgBar.MarqueeAnimationSpeed = 1;
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(463, 23);
            this.pgBar.TabIndex = 1;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // listResult
            // 
            this.listResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listResult.ContextMenuStrip = this.contextMenuStrip1;
            this.listResult.FormattingEnabled = true;
            this.listResult.Location = new System.Drawing.Point(0, 44);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(463, 238);
            this.listResult.TabIndex = 2;
            this.listResult.DoubleClick += new System.EventHandler(this.listResult_DoubleClick);
            this.listResult.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listResult_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLinkInBrowserToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 26);
            // 
            // openLinkInBrowserToolStripMenuItem
            // 
            this.openLinkInBrowserToolStripMenuItem.Name = "openLinkInBrowserToolStripMenuItem";
            this.openLinkInBrowserToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openLinkInBrowserToolStripMenuItem.Text = "Open Link in Browser";
            this.openLinkInBrowserToolStripMenuItem.Click += new System.EventHandler(this.openLinkInBrowserToolStripMenuItem_Click);
            // 
            // cmbLang
            // 
            this.cmbLang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLang.FormattingEnabled = true;
            this.cmbLang.Location = new System.Drawing.Point(379, 0);
            this.cmbLang.Name = "cmbLang";
            this.cmbLang.Size = new System.Drawing.Size(84, 21);
            this.cmbLang.TabIndex = 3;
            // 
            // Anisearch_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 280);
            this.Controls.Add(this.cmbLang);
            this.Controls.Add(this.listResult);
            this.Controls.Add(this.pgBar);
            this.Controls.Add(this.txtSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "Anisearch_Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anisearch Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Anisearch_Search_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ProgressBar pgBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox listResult;
        private System.Windows.Forms.ComboBox cmbLang;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openLinkInBrowserToolStripMenuItem;
    }
}