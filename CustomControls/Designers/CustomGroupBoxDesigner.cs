using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace Episode_Names.View.CustomControls
{
    public class CustomGroupBoxDesigner : ScrollableControlDesigner
    {
        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            properties.Remove("Dock");

            base.PreFilterProperties(properties);
        }
    }
}
