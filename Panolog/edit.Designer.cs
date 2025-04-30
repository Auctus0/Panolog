namespace Panolog
{
    partial class edit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_kaydet = new System.Windows.Forms.Button();
            this.button_qr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBox1.Location = new System.Drawing.Point(9, 10);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(293, 245);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button_exit
            // 
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.button_exit.Image = global::Panolog.Properties.Resources.cross;
            this.button_exit.Location = new System.Drawing.Point(306, 2);
            this.button_exit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(21, 15);
            this.button_exit.TabIndex = 1;
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_kaydet
            // 
            this.button_kaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.button_kaydet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_kaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_kaydet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_kaydet.Location = new System.Drawing.Point(9, 259);
            this.button_kaydet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_kaydet.Name = "button_kaydet";
            this.button_kaydet.Size = new System.Drawing.Size(70, 29);
            this.button_kaydet.TabIndex = 2;
            this.button_kaydet.Text = "Kaydet";
            this.button_kaydet.UseVisualStyleBackColor = false;
            this.button_kaydet.Click += new System.EventHandler(this.button_kaydet_Click);
            // 
            // button_qr
            // 
            this.button_qr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.button_qr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_qr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_qr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_qr.Location = new System.Drawing.Point(232, 259);
            this.button_qr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_qr.Name = "button_qr";
            this.button_qr.Size = new System.Drawing.Size(70, 29);
            this.button_qr.TabIndex = 3;
            this.button_qr.Text = "Qr Oluştur";
            this.button_qr.UseVisualStyleBackColor = false;
            this.button_qr.Click += new System.EventHandler(this.button_qr_Click);
            // 
            // edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(326, 289);
            this.Controls.Add(this.button_qr);
            this.Controls.Add(this.button_kaydet);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.edit_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.edit_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_kaydet;
        private System.Windows.Forms.Button button_qr;
    }
}