namespace VbElTerminali
{
    partial class Frm_Gecici_Kayitlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Gecici_Kayitlar));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btn_close = new System.Windows.Forms.Button();
            this.bt_sec = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.mainMenu2 = new System.Windows.Forms.MainMenu();
            this.lst_gecici_kayitlar = new System.Windows.Forms.ListView();
            this.okutulan_miktar = new System.Windows.Forms.ColumnHeader();
            this.paket_miktar = new System.Windows.Forms.ColumnHeader();
            this.paket_kodu = new System.Windows.Forms.ColumnHeader();
            this.paket_adi = new System.Windows.Forms.ColumnHeader();
            this.urun_kodu = new System.Windows.Forms.ColumnHeader();
            this.sip_no = new System.Windows.Forms.ColumnHeader();
            this.sip_satir = new System.Windows.Forms.ColumnHeader();
            this.sevk_emri_no = new System.Windows.Forms.ColumnHeader();
            this.cari_adi = new System.Windows.Forms.ColumnHeader();
            this.cari_kod = new System.Windows.Forms.ColumnHeader();
            this.btn_sil = new System.Windows.Forms.Button();
            this.okutma_tarihi = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Firebrick;
            this.btn_close.Location = new System.Drawing.Point(219, 3);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(21, 20);
            this.btn_close.TabIndex = 8;
            this.btn_close.Text = "X";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // bt_sec
            // 
            this.bt_sec.Location = new System.Drawing.Point(99, 9);
            this.bt_sec.Name = "bt_sec";
            this.bt_sec.Size = new System.Drawing.Size(56, 30);
            this.bt_sec.TabIndex = 3;
            this.bt_sec.Text = "Seç";
            this.bt_sec.Click += new System.EventHandler(this.btn_sec_clicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel1.Controls.Add(this.btn_sil);
            this.panel1.Controls.Add(this.btn_back);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.bt_sec);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 39);
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location = new System.Drawing.Point(49, 13);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(40, 26);
            this.btn_back.TabIndex = 10;
            this.btn_back.Text = "<---";
            this.btn_back.Click += new System.EventHandler(this.btn_back_clicked);
            // 
            // lst_gecici_kayitlar
            // 
            this.lst_gecici_kayitlar.CheckBoxes = true;
            this.lst_gecici_kayitlar.Columns.Add(this.okutulan_miktar);
            this.lst_gecici_kayitlar.Columns.Add(this.paket_miktar);
            this.lst_gecici_kayitlar.Columns.Add(this.paket_kodu);
            this.lst_gecici_kayitlar.Columns.Add(this.paket_adi);
            this.lst_gecici_kayitlar.Columns.Add(this.urun_kodu);
            this.lst_gecici_kayitlar.Columns.Add(this.sip_no);
            this.lst_gecici_kayitlar.Columns.Add(this.sip_satir);
            this.lst_gecici_kayitlar.Columns.Add(this.sevk_emri_no);
            this.lst_gecici_kayitlar.Columns.Add(this.cari_adi);
            this.lst_gecici_kayitlar.Columns.Add(this.cari_kod);
            this.lst_gecici_kayitlar.Columns.Add(this.okutma_tarihi);
            this.lst_gecici_kayitlar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lst_gecici_kayitlar.Location = new System.Drawing.Point(3, 43);
            this.lst_gecici_kayitlar.Name = "lst_gecici_kayitlar";
            this.lst_gecici_kayitlar.Size = new System.Drawing.Size(234, 222);
            this.lst_gecici_kayitlar.TabIndex = 20;
            // 
            // okutulan_miktar
            // 
            this.okutulan_miktar.Text = "Ok Mik";
            this.okutulan_miktar.Width = 20;
            // 
            // paket_miktar
            // 
            this.paket_miktar.Text = "Pak Mik";
            this.paket_miktar.Width = 20;
            // 
            // paket_kodu
            // 
            this.paket_kodu.Text = "P Kod";
            this.paket_kodu.Width = 100;
            // 
            // paket_adi
            // 
            this.paket_adi.Text = "P Ad";
            this.paket_adi.Width = 200;
            // 
            // urun_kodu
            // 
            this.urun_kodu.Text = "U Kod";
            this.urun_kodu.Width = 100;
            // 
            // sip_no
            // 
            this.sip_no.Text = "SiparisNo";
            this.sip_no.Width = 60;
            // 
            // sip_satir
            // 
            this.sip_satir.Text = "Sip Satır";
            this.sip_satir.Width = 60;
            // 
            // sevk_emri_no
            // 
            this.sevk_emri_no.Text = "Sevk No";
            this.sevk_emri_no.Width = 100;
            // 
            // cari_adi
            // 
            this.cari_adi.Text = "Cari Adı";
            this.cari_adi.Width = 60;
            // 
            // cari_kod
            // 
            this.cari_kod.Text = "Cari Kod";
            this.cari_kod.Width = 60;
            // 
            // btn_sil
            // 
            this.btn_sil.BackColor = System.Drawing.Color.Red;
            this.btn_sil.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btn_sil.Location = new System.Drawing.Point(160, 12);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(55, 27);
            this.btn_sil.TabIndex = 27;
            this.btn_sil.Text = "Sil";
            this.btn_sil.Click += new System.EventHandler(this.btn_delete_clicked);
            // 
            // okutma_tarihi
            // 
            this.okutma_tarihi.Text = "Tarih";
            this.okutma_tarihi.Width = 150;
            // 
            // Frm_Gecici_Kayitlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lst_gecici_kayitlar);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "Frm_Gecici_Kayitlar";
            this.Text = "Geçici Kayıtlar";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button bt_sec;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MainMenu mainMenu2;
        private System.Windows.Forms.ListView lst_gecici_kayitlar;
        private System.Windows.Forms.ColumnHeader okutulan_miktar;
        private System.Windows.Forms.ColumnHeader paket_miktar;
        private System.Windows.Forms.ColumnHeader paket_kodu;
        private System.Windows.Forms.ColumnHeader paket_adi;
        private System.Windows.Forms.ColumnHeader urun_kodu;
        private System.Windows.Forms.ColumnHeader sip_no;
        private System.Windows.Forms.ColumnHeader sip_satir;
        private System.Windows.Forms.ColumnHeader sevk_emri_no;
        private System.Windows.Forms.ColumnHeader cari_adi;
        private System.Windows.Forms.ColumnHeader cari_kod;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_sil;
        private System.Windows.Forms.ColumnHeader okutma_tarihi;
    }
}