namespace CustomControls
{
    partial class CollapsePanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnExpand = new CustomControls.NotFocusButton();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 228);
            this.panel1.TabIndex = 3;
            // 
            // BtnExpand
            // 
            this.BtnExpand.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnExpand.Image = global::CustomControls.Properties.Resources.CollapseIcon;
            this.BtnExpand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExpand.Location = new System.Drawing.Point(0, 0);
            this.BtnExpand.Name = "BtnExpand";
            this.BtnExpand.Size = new System.Drawing.Size(382, 23);
            this.BtnExpand.TabIndex = 4;
            this.BtnExpand.Text = "Expand";
            this.BtnExpand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExpand.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExpand.UseVisualStyleBackColor = true;
            this.BtnExpand.Click += new System.EventHandler(this.BtnExpand_Click);
            // 
            // CollapsePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnExpand);
            this.Controls.Add(this.panel1);
            this.Name = "CollapsePanel";
            this.Size = new System.Drawing.Size(382, 228);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private NotFocusButton BtnExpand;
    }
}
