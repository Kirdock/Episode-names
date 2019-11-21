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
        public event EventHandler<bool> CollapseChanged;
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
            BtnCollapse.Click += (sender, e) => CollapseChanged?.Invoke(sender, true);
            BtnEllapse.Click += (sender, e) => CollapseChanged?.Invoke(sender, false);
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
