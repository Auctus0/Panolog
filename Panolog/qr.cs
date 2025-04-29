using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using QRCoder;

namespace Panolog
{
    public partial class qr : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        public static qrtext Qr = new qrtext();
        string qrtext_;

        public qr(string metin)
         {
             InitializeComponent();
            qrtext_ = metin;
          }

        private void qr_Load(object sender, EventArgs e)
        {
            this.Text = qrtext_;
            pictureBox1.Image = QRKodOlustur(qrtext_);

        }

        public Image QRKodOlustur(string icerik)
        {
            QRCodeGenerator qrolustur = new QRCodeGenerator();
            QRCodeData qrcodedata = qrolustur.CreateQrCode(icerik, QRCodeGenerator.ECCLevel.Q);
            QRCode qrcode = new QRCode(qrcodedata);
            Bitmap qrresim = qrcode.GetGraphic(5);
            this.ClientSize = new Size (qrresim.Width+50, qrresim.Height+50);
            this.Padding = new Padding(20);
            return qrresim;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }

}
