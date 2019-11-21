using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Episode_Names.View.CustomControls;

namespace Episode_Names.View
{
    [Designer(typeof(CollapseGroupBoxDesigner))]
    public partial class CollapseGroupBox : UserControl
    {
        private readonly int MinHeight = 20;
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

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            groupBox1.Dock = DockStyle.Fill;
            BtnCollapse.Visible = false;
            BtnEllapse.Visible = true;
        }

        private void BtnEllapse_Click(object sender, EventArgs e)
        {
            groupBox1.Dock = DockStyle.None;
            groupBox1.Height = MinHeight;
            BtnEllapse.Visible = false;
            BtnCollapse.Visible = true;
        }
    }
}
