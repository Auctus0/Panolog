using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Panolog
{
    public partial class qrtext : Form
    {


        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;


        public qrtext()
        {
            InitializeComponent();

        }
        public string qrmetin;

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void qrtext_Load(object sender, EventArgs e)
        {
            this.Region = new Region(entitiys.CreateRoundedRegion(this.Width, this.Height, 10));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qrmetin = richTextBox1.Text;

            qr qr = new qr(qrmetin);
            
            qr.ShowDialog();

        }

        private void qrtext_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
