using GlobalSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class FormatTextBox : TextBox
    {
        public bool OnlyNumber;
        private readonly ErrorProvider Provider;
        private bool valid;
        public bool Valid
        {
            get
            {
                return valid;
            }
            set
            {
                valid = value;
                string message = string.Empty;
                if (!valid)
                {
                    message = "Ungültiges Format";
                    DrawValidation();
                }
                Provider.SetError(this, message);
            }
        }

        public FormatTextBox()
        {
            InitializeComponent();
            Provider = new ErrorProvider();
        }

        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        private const int WM_NCPAINT = 0x85;

        /// <summary>
        /// Draws a red border for the Control if validation is not valid
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCPAINT && !Valid)
            {
                DrawValidation();
            }
        }

        private void DrawValidation()
        {
            IntPtr dc = GetWindowDC(Handle);
            using (Graphics g = Graphics.FromHdc(dc))
            {
                g.DrawRectangle(Pens.Red, 0, 0, Width - 1, Height - 1);
            }
        }


        /// <summary>
        /// Checks if the entered format string is valid
        /// </summary>
        /// <returns>true or false, depending if the format is valid</returns>
        private bool FormatStringValid()
        {
            IEnumerable<string> text = Text.Split(new string[] { FormatSettings.Separator.ToString() }, StringSplitOptions.RemoveEmptyEntries);
            text = Text.StartsWith(FormatSettings.Separator.ToString()) ? text : text.Skip(1);

            IEnumerable<string> formates = FormatSettings.Formates;

            bool withoutNumber = text.Any(item => formates.Where(format => format != FormatSettings.Number).Any(format => item.Length >= format.Length && item.Substring(0, format.Length) == format));
            bool onlyNumber = text.Any(item => item.Length >= FormatSettings.Number.Length && item.Substring(0, FormatSettings.Number.Length) == FormatSettings.Number);


            OnlyNumber = onlyNumber && !withoutNumber;
            return withoutNumber || onlyNumber;
        }

        private void FormatTextBox_TextChanged(object sender, EventArgs e)
        {
            FormatChanged();
        }

        private void FormatTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            FormatChanged();
        }

        private void FormatChanged()
        {
            Valid = FormatStringValid();
        }
    }
}
