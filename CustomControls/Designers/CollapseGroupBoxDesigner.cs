﻿using System.Windows.Forms.Design;

namespace CustomControls.Designers
{
    public class CollapseGroupBoxDesigner : ParentControlDesigner
    {
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);

            if (Control is CollapseGroupBox control)
            {
                EnableDesignMode(control.WorkingArea, "WorkingArea");
            }
        }
    }
}
