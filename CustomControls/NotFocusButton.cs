using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class NotFocusButton : Button
    {
        public NotFocusButton()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
