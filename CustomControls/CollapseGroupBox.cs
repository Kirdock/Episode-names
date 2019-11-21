using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomControls.Designers;

namespace CustomControls
{
    [Designer(typeof(CollapseGroupBoxDesigner))]
    public partial class CollapseGroupBox : UserControl
    {
        private readonly int MinHeight = 20;
        private int BoxHeight;
        public string BoxText
        {
            get
            {
                return groupBox1.Text;
            }
            set
            {
                groupBox1.Text = value;
            }
        }
        [
        Category("Appearance"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)
        ]
        public CustomGroupBox WorkingArea
        {
            get
            {
                return groupBox1;
            }
        }

        public CollapseGroupBox()
        {
            InitializeComponent();
        }

        private void BtnCollapse_Click(object sender, EventArgs e)
        {
            MaximumSize = new Size(Width, BoxHeight);
            Height = BoxHeight;
            BtnCollapse.Visible = false;
            BtnEllapse.Visible = true;
            Parent.Height += BoxHeight - MinHeight;
        }

        private void BtnEllapse_Click(object sender, EventArgs e)
        {
            BoxHeight = Height;
            Height = MinHeight;
            MaximumSize = new Size(Width, Height);
            MinimumSize = MaximumSize;
            
            Parent.Height -= BoxHeight - MinHeight;
            BtnEllapse.Visible = false;
            BtnCollapse.Visible = true;
        }
    }
}
