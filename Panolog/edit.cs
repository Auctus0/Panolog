using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Panolog;
namespace Panolog
{
    public partial class edit : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        Panel panel = new Panel();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public Form1 form1;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        public static string _gelenMetin;
        public static string metin2;
        public edit(Form1 form ,string _gelenMetin)
        {
            InitializeComponent();

            richTextBox1.Text = _gelenMetin;
            metin2 = _gelenMetin;
            form1 = form;
        }
       

        private void edit_Load(object sender, EventArgs e)
        {
            this.Region = new Region(entitiys.CreateRoundedRegion(this.Width, this.Height, 10));
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edit_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button_qr_Click(object sender, EventArgs e)
        {
            qr qr = new qr(metin2);
            qr.ShowDialog();
        }

        private void button_kaydet_Click(object sender, EventArgs e)
        {
            
            foreach (Control paneller in form1.flowLayoutPanel1.Controls)
            {
                if (paneller is Panel)
                {
                    foreach (Control buton in paneller.Controls)
                    {
                        if (buton is Button)
                        {

                            if (buton.Text== metin2)
                            {
                                form1.listBox1.Items.Add(richTextBox1.Text);
                                buton.Text = richTextBox1.Text;
                                buton.Update();
                                this.Close();
                            }

                        }
                    }

                }


            }


            
        }
    }
}
