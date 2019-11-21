﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Episode_Names.View.CustomControls
{
    [Designer(typeof(CustomGroupBoxDesigner))]
    public partial class CustomGroupBox : GroupBox
    {
        private string _Text = string.Empty;
        public CustomGroupBox()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            //set the base text to empty 
            //base class will draw empty string
            //in such way we see only text what we draw
            base.Text = string.Empty;
        }
        //create a new property a
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue("GroupBoxText")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new string Text
        {
            get
            {
                return _Text;
            }
            set
            {

                _Text = value;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            //first let the base class to draw the control 
            base.OnPaint(e);
            //create a brush with fore color
            SolidBrush colorBrush = new SolidBrush(ForeColor);
            //create a brush with back color
            var backColor = new SolidBrush(BackColor);
            //measure the text size
            var size = TextRenderer.MeasureText(Text, Font);
            // evaluate the postiong of text from left;
            int left = 30; //(Width - size.Width) / 2;
            //draw a fill rectangle in order to remove the border
            e.Graphics.FillRectangle(backColor, new Rectangle(left, 0, size.Width, size.Height));
            //draw the text Now
            e.Graphics.DrawString(Text, Font, colorBrush, new PointF(left, 0));
        }
    }
}
