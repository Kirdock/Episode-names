using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CustomControls.Designers
{
    public class CollapsePanelDesigner : ParentControlDesigner
    {
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);

            if (Control is CollapsePanel control)
            {
                EnableDesignMode(control.WorkingArea, "WorkingArea");
            }
        }
    }
}
