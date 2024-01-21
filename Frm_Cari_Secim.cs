using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VbElTerminali.Classes;

namespace VbElTerminali
{
    public partial class Frm_Cari_Secim : Form
    {
        public Frm_Cari_Secim()
        {
            InitializeComponent();
        }

        Cls_Sevk sevk = new Cls_Sevk();
        List<Cls_Sevk> cariListesi = new List<Cls_Sevk>();
        List<Cls_Sevk> paketGeriListeCariForm = new List<Cls_Sevk>();
        List<Cls_Barcodes> okutulanBarkodlarCariForm = new List<Cls_Barcodes>();

        int kullaniciKodu = 0;
        string veriYili = string.Empty;
        string kisit = string.Empty;
        string paketKisitCariForm = string.Empty;

        public Frm_Cari_Secim(int userId, string yil, string paketKist, List<Cls_Sevk>paketGeriListe)
        {
            InitializeComponent();
        
            kullaniciKodu = userId;
            veriYili = yil;

            try
            {
                lst_cari_secim.Items.Clear();

                lst_cari_secim.CheckBoxes = true;

                cariListesi = sevk.PopulateCariList(yil);

                if (cariListesi == null)
                {
                    MessageBox.Show("Veri Tabanına Bağlanırken Hata İle Karşılaşıldı.");
                    return;
                }

                if (cariListesi.Count == 0)
                {
                    MessageBox.Show("Sorgu Boş Sonuç Döndürdü.");
                    return;
                }

                if (cariListesi.Count > 0)
                {
                    lst_cari_secim.View = View.Details;

                    foreach (Cls_Sevk item in cariListesi)
                    {
                        ListViewItem listViewItem = new ListViewItem(item.CariKodu);
                        listViewItem.SubItems.Add(item.CariAdi);

                        lst_cari_secim.Items.Add(listViewItem);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_listele_clicked(object sender, EventArgs e)
        {
            int counter = 0;
            try
            {

                for (int i = 0; i < lst_cari_secim.Items.Count; i++)
                {
                    ListViewItem listviewitem = lst_cari_secim.Items[i];

                    if (listviewitem.Checked == true)
                    {
                        kisit = kisit + string.Format("CariKodu='{0}'", listviewitem.Text.Trim());
                        counter++;
                    }

                }

                if (string.IsNullOrEmpty(kisit)) { MessageBox.Show("Seçim Yapılmadı"); return; };
                if (counter > 1) { MessageBox.Show("Birden Fazla Cari Seçilemez");return;};

                Frm_Sevk_Emirleri frm1 = new Frm_Sevk_Emirleri(kisit, kullaniciKodu, veriYili,paketGeriListeCariForm, okutulanBarkodlarCariForm);

                frm1.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btn_close_clicked(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Program Kapatılacak Emin Misiniz?",
                                        "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button3);
            if (answer == DialogResult.Yes)
                Application.Exit();
            else
                return;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_GotFocus(object sender, EventArgs e)
        {

        }

        private void lst_cari_secim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_kayit_getir_clicked(object sender, EventArgs e)
        {
            Frm_Gecici_Kayitlar frm = new Frm_Gecici_Kayitlar(kullaniciKodu,veriYili);
            frm.Show();
            this.Hide();
        }

        private void btn_yukle_clicked(object sender, EventArgs e)
        {
            Frm_Yukle frm = new Frm_Yukle (paketKisitCariForm, veriYili, kullaniciKodu, kisit, 
                                               paketGeriListeCariForm, okutulanBarkodlarCariForm);
            frm.Show();
            this.Hide();
        }
    }
}