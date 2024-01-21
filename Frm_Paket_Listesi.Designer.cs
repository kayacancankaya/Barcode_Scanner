namespace VbElTerminali
{
    partial class Frm_Paket_Listesi
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
            this.urun_kodu = new System.Windows.Forms.ColumnHeader();
            this.txt_geri_al = new System.Windows.Forms.TextBox();
            this.sevk_emri_no = new System.Windows.Forms.ColumnHeader();
            this.txt_barcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.paket_adi = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_kaydet = new System.Windows.Forms.Button();
            this.btn_complete = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.paket_kodu = new System.Windows.Forms.ColumnHeader();
            this.paket_miktar = new System.Windows.Forms.ColumnHeader();
            this.mainMenu2 = new System.Windows.Forms.MainMenu();
            this.lst_paket_liste = new System.Windows.Forms.ListView();
            this.okutulan_miktar = new System.Windows.Forms.ColumnHeader();
            this.sip_no = new System.Windows.Forms.ColumnHeader();
            this.sip_satir = new System.Windows.Forms.ColumnHeader();
            this.cari_adi = new System.Windows.Forms.ColumnHeader();
            this.cari_kod = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // urun_kodu
            // 
            this.urun_kodu.Text = "U Kod";
            this.urun_kodu.Width = 100;
            // 
            // txt_geri_al
            // 
            this.txt_geri_al.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt_geri_al.Location = new System.Drawing.Point(78, 244);
            this.txt_geri_al.Name = "txt_geri_al";
            this.txt_geri_al.Size = new System.Drawing.Size(159, 19);
            this.txt_geri_al.TabIndex = 21;
            this.txt_geri_al.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BarkodGeriAl);
            // 
            // sevk_emri_no
            // 
            this.sevk_emri_no.Text = "Sevk No";
            this.sevk_emri_no.Width = 100;
            // 
            // txt_barcode
            // 
            this.txt_barcode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt_barcode.Location = new System.Drawing.Point(72, 33);
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(156, 19);
            this.txt_barcode.TabIndex = 20;
            this.txt_barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BarkodKaydet);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.Text = "Barkod No:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // paket_adi
            // 
            this.paket_adi.Text = "P Ad";
            this.paket_adi.Width = 200;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel1.Controls.Add(this.btn_kaydet);
            this.panel1.Controls.Add(this.btn_complete);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_send);
            this.panel1.Controls.Add(this.btn_back);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 32);
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.BackColor = System.Drawing.SystemColors.Info;
            this.btn_kaydet.Location = new System.Drawing.Point(48, 2);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(52, 26);
            this.btn_kaydet.TabIndex = 27;
            this.btn_kaydet.Text = "Kaydet";
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // btn_complete
            // 
            this.btn_complete.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_complete.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btn_complete.Location = new System.Drawing.Point(166, 1);
            this.btn_complete.Name = "btn_complete";
            this.btn_complete.Size = new System.Drawing.Size(47, 27);
            this.btn_complete.TabIndex = 26;
            this.btn_complete.Text = "Yükle";
            this.btn_complete.Click += new System.EventHandler(this.btn_complete_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Firebrick;
            this.btn_close.Location = new System.Drawing.Point(219, 4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(21, 20);
            this.btn_close.TabIndex = 25;
            this.btn_close.Text = "X";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.LightGreen;
            this.btn_send.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btn_send.Location = new System.Drawing.Point(108, 1);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(50, 27);
            this.btn_send.TabIndex = 5;
            this.btn_send.Text = "Gönder";
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location = new System.Drawing.Point(1, 2);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(40, 26);
            this.btn_back.TabIndex = 2;
            this.btn_back.Text = "<---";
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // paket_kodu
            // 
            this.paket_kodu.Text = "P Kod";
            this.paket_kodu.Width = 100;
            // 
            // paket_miktar
            // 
            this.paket_miktar.Text = "Pak Mik";
            this.paket_miktar.Width = 20;
            // 
            // lst_paket_liste
            // 
            this.lst_paket_liste.Columns.Add(this.okutulan_miktar);
            this.lst_paket_liste.Columns.Add(this.paket_miktar);
            this.lst_paket_liste.Columns.Add(this.paket_kodu);
            this.lst_paket_liste.Columns.Add(this.paket_adi);
            this.lst_paket_liste.Columns.Add(this.urun_kodu);
            this.lst_paket_liste.Columns.Add(this.sip_no);
            this.lst_paket_liste.Columns.Add(this.sip_satir);
            this.lst_paket_liste.Columns.Add(this.sevk_emri_no);
            this.lst_paket_liste.Columns.Add(this.cari_adi);
            this.lst_paket_liste.Columns.Add(this.cari_kod);
            this.lst_paket_liste.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lst_paket_liste.Location = new System.Drawing.Point(3, 58);
            this.lst_paket_liste.Name = "lst_paket_liste";
            this.lst_paket_liste.Size = new System.Drawing.Size(234, 183);
            this.lst_paket_liste.TabIndex = 19;
            // 
            // okutulan_miktar
            // 
            this.okutulan_miktar.Text = "Ok Mik";
            this.okutulan_miktar.Width = 20;
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
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(-4, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.Text = "Geri Al:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Frm_Paket_Listesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.txt_geri_al);
            this.Controls.Add(this.txt_barcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lst_paket_liste);
            this.Controls.Add(this.label2);
            this.Menu = this.mainMenu1;
            this.Name = "Frm_Paket_Listesi";
            this.Text = "Paket Listesi";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader urun_kodu;
        private System.Windows.Forms.TextBox txt_geri_al;
        private System.Windows.Forms.ColumnHeader sevk_emri_no;
        private System.Windows.Forms.TextBox txt_barcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader paket_adi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.ColumnHeader paket_kodu;
        private System.Windows.Forms.ColumnHeader paket_miktar;
        private System.Windows.Forms.MainMenu mainMenu2;
        private System.Windows.Forms.ListView lst_paket_liste;
        private System.Windows.Forms.ColumnHeader okutulan_miktar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader cari_adi;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.ColumnHeader sip_no;
        private System.Windows.Forms.ColumnHeader sip_satir;
        private System.Windows.Forms.Button btn_complete;
        private System.Windows.Forms.ColumnHeader cari_kod;
        private System.Windows.Forms.Button btn_kaydet;
    }
}