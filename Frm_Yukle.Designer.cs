namespace VbElTerminali
{
    partial class Frm_Yukle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btn_sil = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lst_yukleme_tamamla = new System.Windows.Forms.ListView();
            this.sevk_emri = new System.Windows.Forms.ColumnHeader();
            this.teslim_cari = new System.Windows.Forms.ColumnHeader();
            this.yukleme_emri = new System.Windows.Forms.ColumnHeader();
            this.yuk_miktar = new System.Windows.Forms.ColumnHeader();
            this.urun_kodu = new System.Windows.Forms.ColumnHeader();
            this.siparis_no = new System.Windows.Forms.ColumnHeader();
            this.siparis_satir = new System.Windows.Forms.ColumnHeader();
            this.cari_kodu = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_sil
            // 
            this.btn_sil.BackColor = System.Drawing.Color.Red;
            this.btn_sil.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btn_sil.Location = new System.Drawing.Point(152, 1);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(55, 27);
            this.btn_sil.TabIndex = 26;
            this.btn_sil.Text = "Sil";
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Firebrick;
            this.btn_close.Location = new System.Drawing.Point(219, 4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(21, 20);
            this.btn_close.TabIndex = 25;
            this.btn_close.Text = "X";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click_1);
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.LightGreen;
            this.btn_send.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btn_send.Location = new System.Drawing.Point(87, 1);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(50, 27);
            this.btn_send.TabIndex = 5;
            this.btn_send.Text = "Gönder";
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location = new System.Drawing.Point(22, 2);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(50, 26);
            this.btn_back.TabIndex = 2;
            this.btn_back.Text = "<---";
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel1.Controls.Add(this.btn_sil);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_send);
            this.panel1.Controls.Add(this.btn_back);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 32);
            // 
            // lst_yukleme_tamamla
            // 
            this.lst_yukleme_tamamla.CheckBoxes = true;
            this.lst_yukleme_tamamla.Columns.Add(this.sevk_emri);
            this.lst_yukleme_tamamla.Columns.Add(this.teslim_cari);
            this.lst_yukleme_tamamla.Columns.Add(this.yukleme_emri);
            this.lst_yukleme_tamamla.Columns.Add(this.yuk_miktar);
            this.lst_yukleme_tamamla.Columns.Add(this.urun_kodu);
            this.lst_yukleme_tamamla.Columns.Add(this.siparis_no);
            this.lst_yukleme_tamamla.Columns.Add(this.siparis_satir);
            this.lst_yukleme_tamamla.Columns.Add(this.cari_kodu);
            this.lst_yukleme_tamamla.FullRowSelect = true;
            this.lst_yukleme_tamamla.Location = new System.Drawing.Point(3, 38);
            this.lst_yukleme_tamamla.Name = "lst_yukleme_tamamla";
            this.lst_yukleme_tamamla.Size = new System.Drawing.Size(230, 223);
            this.lst_yukleme_tamamla.TabIndex = 7;
            this.lst_yukleme_tamamla.View = System.Windows.Forms.View.List;
            // 
            // sevk_emri
            // 
            this.sevk_emri.Text = "Sevk Emri No";
            this.sevk_emri.Width = 150;
            // 
            // teslim_cari
            // 
            this.teslim_cari.Text = "Cari";
            this.teslim_cari.Width = 170;
            // 
            // yukleme_emri
            // 
            this.yukleme_emri.Text = "Yukleme Emri";
            this.yukleme_emri.Width = 200;
            // 
            // yuk_miktar
            // 
            this.yuk_miktar.Text = "Yük Mik";
            this.yuk_miktar.Width = 60;
            // 
            // urun_kodu
            // 
            this.urun_kodu.Text = "Ürün Kodu";
            this.urun_kodu.Width = 150;
            // 
            // siparis_no
            // 
            this.siparis_no.Text = "Sip No";
            this.siparis_no.Width = 100;
            // 
            // siparis_satir
            // 
            this.siparis_satir.Text = "Sip Satir";
            this.siparis_satir.Width = 60;
            // 
            // cari_kodu
            // 
            this.cari_kodu.Text = "Cari Kod";
            this.cari_kodu.Width = 60;
            // 
            // Frm_Yukle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lst_yukleme_tamamla);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "Frm_Yukle";
            this.Text = "Yukleme Tamamla";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_sil;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lst_yukleme_tamamla;
        private System.Windows.Forms.ColumnHeader sevk_emri;
        private System.Windows.Forms.ColumnHeader teslim_cari;
        private System.Windows.Forms.ColumnHeader yukleme_emri;
        private System.Windows.Forms.ColumnHeader urun_kodu;
        private System.Windows.Forms.ColumnHeader siparis_no;
        private System.Windows.Forms.ColumnHeader siparis_satir;
        private System.Windows.Forms.ColumnHeader yuk_miktar;
        private System.Windows.Forms.ColumnHeader cari_kodu;
    }
}