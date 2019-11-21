namespace Episode_Names.View
{
    partial class TestForm
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
            this.button8 = new System.Windows.Forms.Button();
            this.collapseGroupBox1 = new Episode_Names.View.CollapseGroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.collapseGroupBox1.WorkingArea.SuspendLayout();
            this.collapseGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(192, 69);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 0;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // collapseGroupBox1
            // 
            this.collapseGroupBox1.BoxText = "customGroupBox1";
            this.collapseGroupBox1.Location = new System.Drawing.Point(131, 89);
            this.collapseGroupBox1.Name = "collapseGroupBox1";
            this.collapseGroupBox1.Size = new System.Drawing.Size(273, 105);
            this.collapseGroupBox1.TabIndex = 0;
            // 
            // collapseGroupBox1.WorkingArea
            // 
            this.collapseGroupBox1.WorkingArea.Controls.Add(this.button1);
            this.collapseGroupBox1.WorkingArea.Location = new System.Drawing.Point(0, 0);
            this.collapseGroupBox1.WorkingArea.Name = "WorkingArea";
            this.collapseGroupBox1.WorkingArea.Size = new System.Drawing.Size(273, 105);
            this.collapseGroupBox1.WorkingArea.TabIndex = 1;
            this.collapseGroupBox1.WorkingArea.TabStop = false;
            this.collapseGroupBox1.WorkingArea.Text = "customGroupBox1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TestForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 306);
            this.Controls.Add(this.collapseGroupBox1);
            this.Name = "TestForm";
            this.Text = "Testform";
            this.collapseGroupBox1.WorkingArea.ResumeLayout(false);
            this.collapseGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button8;
        private CollapseGroupBox collapseGroupBox1;
        private System.Windows.Forms.Button button1;
    }
}