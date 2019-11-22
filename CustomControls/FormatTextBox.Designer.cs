namespace CustomControls
{
    partial class FormatTextBox
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
            if (disposing)
            {
                Provider?.Dispose();
                components?.Dispose();
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
            this.SuspendLayout();
            // 
            // FormatTextBox
            // 
            this.TextChanged += new System.EventHandler(this.FormatTextBox_TextChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormatTextBox_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
