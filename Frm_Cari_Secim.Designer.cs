namespace VbElTerminali
{
    partial class Frm_Cari_Secim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cari_Secim));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_listele = new System.Windows.Forms.Button();
            this.lst_cari_secim = new System.Windows.Forms.ListView();
            this.teslim_cari_kod = new System.Windows.Forms.ColumnHeader();
            this.teslim_cari_adi = new System.Windows.Forms.ColumnHeader();
            this.btn_kayit_getir = new System.Windows.Forms.Button();
            this.btn_tamamla = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel1.Controls.Add(this.btn_tamamla);
            this.panel1.Controls.Add(this.btn_kayit_getir);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_listele);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 39);
            this.panel1.GotFocus += new System.EventHandler(this.panel1_GotFocus);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Firebrick;
            this.btn_close.Location = new System.Drawing.Point(219, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(21, 20);
            this.btn_close.TabIndex = 8;
            this.btn_close.Text = "X";
            this.btn_close.Click += new System.EventHandler(this.btn_close_clicked);
            // 
            // btn_listele
            // 
            this.btn_listele.Location = new System.Drawing.Point(44, 9);
            this.btn_listele.Name = "btn_listele";
            this.btn_listele.Size = new System.Drawing.Size(52, 30);
            this.btn_listele.TabIndex = 3;
            this.btn_listele.Text = "Listele";
            this.btn_listele.Click += new System.EventHandler(this.btn_listele_clicked);
            // 
            // lst_cari_secim
            // 
            this.lst_cari_secim.CheckBoxes = true;
            this.lst_cari_secim.Columns.Add(this.teslim_cari_kod);
            this.lst_cari_secim.Columns.Add(this.teslim_cari_adi);
            this.lst_cari_secim.FullRowSelect = true;
            this.lst_cari_secim.Location = new System.Drawing.Point(7, 45);
            this.lst_cari_secim.Name = "lst_cari_secim";
            this.lst_cari_secim.Size = new System.Drawing.Size(230, 223);
            this.lst_cari_secim.TabIndex = 7;
            this.lst_cari_secim.View = System.Windows.Forms.View.List;
            this.lst_cari_secim.SelectedIndexChanged += new System.EventHandler(this.lst_cari_secim_SelectedIndexChanged);
            // 
            // teslim_cari_kod
            // 
            this.teslim_cari_kod.Text = "Cari Kod";
            this.teslim_cari_kod.Width = 100;
            // 
            // teslim_cari_adi
            // 
            this.teslim_cari_adi.Text = "Cari Kod";
            this.teslim_cari_adi.Width = 300;
            // 
            // btn_kayit_getir
            // 
            this.btn_kayit_getir.BackColor = System.Drawing.SystemColors.Info;
            this.btn_kayit_getir.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btn_kayit_getir.Location = new System.Drawing.Point(99, 9);
            this.btn_kayit_getir.Name = "btn_kayit_getir";
            this.btn_kayit_getir.Size = new System.Drawing.Size(65, 30);
            this.btn_kayit_getir.TabIndex = 10;
            this.btn_kayit_getir.Text = "Kayıt Getir";
            this.btn_kayit_getir.Click += new System.EventHandler(this.btn_kayit_getir_clicked);
            // 
            // btn_tamamla
            // 
            this.btn_tamamla.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_tamamla.Location = new System.Drawing.Point(167, 9);
            this.btn_tamamla.Name = "btn_tamamla";
            this.btn_tamamla.Size = new System.Drawing.Size(46, 30);
            this.btn_tamamla.TabIndex = 11;
            this.btn_tamamla.Text = "Yükle";
            this.btn_tamamla.Click += new System.EventHandler(this.btn_yukle_clicked);
            // 
            // Frm_Cari_Secim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lst_cari_secim);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "Frm_Cari_Secim";
            this.Text = "Cari Seçim";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lst_cari_secim;
        private System.Windows.Forms.ColumnHeader teslim_cari_adi;
        private System.Windows.Forms.ColumnHeader teslim_cari_kod;
        private System.Windows.Forms.Button btn_listele;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_tamamla;
        private System.Windows.Forms.Button btn_kayit_getir;
    }
}