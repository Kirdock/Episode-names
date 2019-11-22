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
    [Designer(typeof(CollapsePanelDesigner))]
    public partial class CollapsePanel : UserControl
    {
        private bool expanded = true;
        public bool Expanded
        {
            get
            {
                return expanded;
            }
            set
            {
                expanded = value;
                AdjustControls();
            }
        }
        private int HeightBefore;

        [   EditorBrowsable(EditorBrowsableState.Always),
            Browsable(true),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
            Bindable(true)
        ]
        public override string Text
        {
            get
            {
                return BtnExpand.Text;
            }
            set
            {
                BtnExpand.Text = value;
            }
        }

        [
        Category("Appearance"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)
        ]
        public Panel WorkingArea
        {
            get
            {
                return panel1;
            }
        }

        public CollapsePanel()
        {
            InitializeComponent();
        }

        private void BtnExpand_Click(object sender, EventArgs e)
        {
            Expanded = !Expanded;
        }

        private void AdjustControls()
        {
            if (Expanded)
            {
                BtnExpand.Image = Properties.Resources.Collapse;
                Parent.Height += HeightBefore;
                Height += HeightBefore;
                panel1.Visible = true;
            }
            else
            {
                BtnExpand.Image = Properties.Resources.Expand;
                HeightBefore = panel1.Height - 2;
                Parent.Height -= HeightBefore;
                Height -= HeightBefore;
                panel1.Visible = false;
            }
        }
    }
}
