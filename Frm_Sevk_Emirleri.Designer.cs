namespace VbElTerminali
{
    partial class Frm_Sevk_Emirleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Sevk_Emirleri));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_listele = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lst_sevk_listesi = new System.Windows.Forms.ListView();
            this.sevk_emri = new System.Windows.Forms.ColumnHeader();
            this.teslim_cari = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel1.Controls.Add(this.btn_back);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_listele);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 39);
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location = new System.Drawing.Point(49, 10);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(50, 26);
            this.btn_back.TabIndex = 10;
            this.btn_back.Text = "<---";
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click_1);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Firebrick;
            this.btn_close.Location = new System.Drawing.Point(219, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(21, 20);
            this.btn_close.TabIndex = 8;
            this.btn_close.Text = "X";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_listele
            // 
            this.btn_listele.Location = new System.Drawing.Point(122, 9);
            this.btn_listele.Name = "btn_listele";
            this.btn_listele.Size = new System.Drawing.Size(72, 27);
            this.btn_listele.TabIndex = 1;
            this.btn_listele.Text = "Listele";
            this.btn_listele.Click += new System.EventHandler(this.btn_listele_clicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lst_sevk_listesi
            // 
            this.lst_sevk_listesi.CheckBoxes = true;
            this.lst_sevk_listesi.Columns.Add(this.sevk_emri);
            this.lst_sevk_listesi.Columns.Add(this.teslim_cari);
            this.lst_sevk_listesi.FullRowSelect = true;
            this.lst_sevk_listesi.Location = new System.Drawing.Point(3, 45);
            this.lst_sevk_listesi.Name = "lst_sevk_listesi";
            this.lst_sevk_listesi.Size = new System.Drawing.Size(230, 223);
            this.lst_sevk_listesi.TabIndex = 6;
            this.lst_sevk_listesi.View = System.Windows.Forms.View.List;
            // 
            // sevk_emri
            // 
            this.sevk_emri.Text = "Sevk Emri No";
            this.sevk_emri.Width = 150;
            // 
            // teslim_cari
            // 
            this.teslim_cari.Text = "Cari";
            this.teslim_cari.Width = 200;
            // 
            // Frm_Sevk_Emirleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lst_sevk_listesi);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "Frm_Sevk_Emirleri";
            this.Text = "Sevk Emirleri";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_listele;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView lst_sevk_listesi;
        private System.Windows.Forms.ColumnHeader sevk_emri;
        private System.Windows.Forms.ColumnHeader teslim_cari;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_back;
    }
}

