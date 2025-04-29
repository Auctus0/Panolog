using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Panolog;

namespace Panolog.Resources
{
    public partial class ekle : Form
    {       
        
        // Windows API çağrıları
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
     
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        public ekle()
        {
            
            InitializeComponent();
        }
        public string ekle_metin ="";
        private void ekle_Load(object sender, EventArgs e)
        {
            this.Region = new Region(entitiys.CreateRoundedRegion(this.Width, this.Height, 10));
            string ekle_metin = richTextBox1.Text;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {

                if (richTextBox1.Text == "") 
                { 
                
                    MessageBox.Show("Metin Giriniz");
                    return;
                }
                else
                {
                    ekle_metin = richTextBox1.Text;
                     this.Close();
                }


        }

        private void ekle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
