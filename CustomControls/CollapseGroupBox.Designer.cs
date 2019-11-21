namespace Episode_Names.View
{
    partial class CollapseGroupBox
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollapseGroupBox));
            this.BtnCollapse = new System.Windows.Forms.Button();
            this.groupBox1 = new Episode_Names.View.CustomControls.CustomGroupBox();
            this.BtnEllapse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnCollapse
            // 
            this.BtnCollapse.BackColor = System.Drawing.Color.Transparent;
            this.BtnCollapse.FlatAppearance.BorderSize = 0;
            this.BtnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCollapse.ForeColor = System.Drawing.Color.Transparent;
            this.BtnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("BtnCollapse.Image")));
            this.BtnCollapse.Location = new System.Drawing.Point(12, -1);
            this.BtnCollapse.Name = "BtnCollapse";
            this.BtnCollapse.Size = new System.Drawing.Size(16, 16);
            this.BtnCollapse.TabIndex = 0;
            this.BtnCollapse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnCollapse.UseVisualStyleBackColor = false;
            this.BtnCollapse.Visible = false;
            this.BtnCollapse.Click += new System.EventHandler(this.BtnCollapse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 105);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "customGroupBox1";
            // 
            // BtnEllapse
            // 
            this.BtnEllapse.BackColor = System.Drawing.Color.Transparent;
            this.BtnEllapse.FlatAppearance.BorderSize = 0;
            this.BtnEllapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEllapse.ForeColor = System.Drawing.Color.Transparent;
            this.BtnEllapse.Image = ((System.Drawing.Image)(resources.GetObject("BtnEllapse.Image")));
            this.BtnEllapse.Location = new System.Drawing.Point(12, -1);
            this.BtnEllapse.Name = "BtnEllapse";
            this.BtnEllapse.Size = new System.Drawing.Size(16, 16);
            this.BtnEllapse.TabIndex = 2;
            this.BtnEllapse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnEllapse.UseVisualStyleBackColor = false;
            this.BtnEllapse.Click += new System.EventHandler(this.BtnEllapse_Click);
            // 
            // CollapseGroupBox
            // 
            this.Controls.Add(this.BtnCollapse);
            this.Controls.Add(this.BtnEllapse);
            this.Controls.Add(this.groupBox1);
            this.Name = "CollapseGroupBox";
            this.Size = new System.Drawing.Size(273, 105);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCollapse;
        private CustomControls.CustomGroupBox groupBox1;
        private System.Windows.Forms.Button BtnEllapse;
    }
}
