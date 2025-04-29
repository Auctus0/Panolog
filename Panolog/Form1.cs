using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Panolog.Resources;

namespace Panolog
{
    public partial class Form1 : Form
    {
        public Button btn = new Button();
        qrtext qrtext = new qrtext();
        ekle ekle = new ekle();
        public string metin;
        public string tklnbtn_text;
        public Image resim;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        Panel panel = new Panel();
        List<string> resimler = new List<string>();

        public Form1()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.HorizontalScroll.Maximum = 0;
        }

        private void RegistryeEkle()
        {
            var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key?.SetValue("Panolog", Application.ExecutablePath);
        }

        public void buttons(string metin, Image img)
        {
            var btn = new Button();
            var silmeBtn = new Button();
            var editbtn = new Button();
            var panel = new Panel();

            btn.BackColor = Color.FromArgb(18, 18, 18);
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.ForeColor = Color.FromArgb(224, 224, 224);
            btn.FlatStyle = FlatStyle.Flat;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Size = new Size(300, 45);
            btn.Tag = 1;
            btn.Text = metin;
            btn.Click += btn_Click;

            if (img != null)
            {
                btn.Image = img;
                btn.Size = new Size(300, 150);
                btn.Click -= btn_Click;
                btn.Click += btn_img_Click;
            }

            silmeBtn.Size = new Size(25, 25);
            silmeBtn.FlatStyle = FlatStyle.Flat;
            silmeBtn.BackColor = Color.Transparent;
            silmeBtn.ForeColor = Color.FromArgb(18, 18, 18);
            silmeBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            silmeBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            silmeBtn.Image = Properties.Resources.trash;
            silmeBtn.Location = new Point(303, -3);
            silmeBtn.Tag = 0;
            silmeBtn.Click += silmeBtn_Click;

            editbtn.Size = new Size(25, 25);
            editbtn.FlatStyle = FlatStyle.Flat;
            editbtn.ForeColor = Color.FromArgb(18, 18, 18);
            editbtn.BackColor = Color.Transparent;
            editbtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            editbtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            editbtn.Image = Properties.Resources.edit__2_;
            editbtn.Location = new Point(303, 21);
            editbtn.Tag = btn;
            editbtn.Click += editbtn_Click;

            panel.Controls.Add(btn);
            panel.Controls.Add(silmeBtn);
            panel.Controls.Add(editbtn);
            panel.Size = new Size(340, btn.Height);

            flowLayoutPanel1.Controls.Add(panel);
        }

        private string resimhash(Image image)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                var bytes = ms.ToArray();
                using (var sha256 = System.Security.Cryptography.SHA256.Create())
                {
                    return Convert.ToBase64String(sha256.ComputeHash(bytes));
                }
            }
        }

        private void klavye_tıklama(object sender, KeyEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control && e.KeyCode == Keys.E)
            {
                if (this.Visible)
                {
                    this.Hide();
                    this.ShowInTaskbar = false;
                }
                else
                {
                    this.Show();
                    this.ShowInTaskbar = true;
                    this.Activate();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            this.Region = new Region(entitiys.CreateRoundedRegion(this.Width, this.Height, 10));

            button_clear.FlatAppearance.BorderColor = Color.White;
            button_exit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_exit.FlatAppearance.MouseDownBackColor = Color.Transparent;

            RegistryeEkle();
            KeyboardHook.Start();
            KeyboardHook.KeyPressed += klavye_tıklama;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            metin = Clipboard.GetText();

            if (Clipboard.ContainsImage())
            {
                var img = Clipboard.GetImage();
                string hash = resimhash(img);

                if (!resimler.Contains(hash))
                {
                    resimler.Add(hash);
                    buttons(null, img);
                }
                return;
            }

            if (!listBox1.Items.Contains(metin) && !string.IsNullOrWhiteSpace(metin))
            {
                listBox1.Items.Add(metin);
                buttons(metin, null);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = true;
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (sender is Button tiklananBtn)
            {
                try
                {
                    Clipboard.SetText(tiklananBtn.Text);
                    notifyIcon1.BalloonTipTitle = "Metin Kopyalandı";
                    notifyIcon1.BalloonTipText = tiklananBtn.Text;
                    notifyIcon1.ShowBalloonTip(1000);
                }
                catch
                {
                    MessageBox.Show("HATA.!");
                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = true;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
        }

        private void silmeBtn_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Parent != null)
            {
                flowLayoutPanel1.Controls.Remove(btn.Parent);
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Button hedefBtn)
            {
                tklnbtn_text = hedefBtn.Text;
                var editForm = new edit(this, tklnbtn_text);
                editForm.ShowDialog();
            }
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            ekle.ShowDialog();

            if (!string.IsNullOrWhiteSpace(ekle.ekle_metin))
            {
                listBox1.Items.Add(ekle.ekle_metin);
                buttons(ekle.ekle_metin, null);
                ekle.ekle_metin = string.Empty;
            }
        }

        private void button_qr_Click(object sender, EventArgs e)
        {
            qrtext.ShowDialog();
        }

        private void btn_img_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                 var saveDialog = new SaveFileDialog
                {
                    Filter = "PNG Dosyası|*.png|JPEG Dosyası|*.jpg|Bitmap Dosyası|*.bmp",
                    Title = "Resmi Kaydet"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    btn.Image.Save(saveDialog.FileName);
                    MessageBox.Show("Resim kaydedildi!");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string arama = textBox1.Text.ToLower();

            foreach (Control panel in flowLayoutPanel1.Controls)
            {
                if (panel is Panel)
                {
                    foreach (Control ctrl in panel.Controls)
                    {
                        if (ctrl is Button btn && btn.Tag?.ToString() == "1")
                        {
                            if (btn.Text.ToLower().Contains(arama))
                            {
                                flowLayoutPanel1.Controls.SetChildIndex(panel, 0);
                            }
                        }
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeyboardHook.Stop();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}