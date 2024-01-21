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
    public partial class Frm_Gecici_Kayitlar : Form
    {
        public Frm_Gecici_Kayitlar()
        {
            InitializeComponent();
        }

        Cls_Sevk sevk = new Cls_Sevk();
        Cls_Barcodes barcodes = new Cls_Barcodes();
        List<Cls_Sevk> geciciKayitlar = new List<Cls_Sevk>();
        int kullaniciKodu = 0;
        string veriYili = string.Empty;

        public Frm_Gecici_Kayitlar(int userId, string yil)
        {
            InitializeComponent();

            kullaniciKodu = userId;
            veriYili = yil;

            geciciKayitlar = sevk.PopulateGeciciKayitlar(veriYili);

            lst_gecici_kayitlar.Items.Clear();

            if (geciciKayitlar == null) return;

            if (geciciKayitlar.Count > 0)
            {
                lst_gecici_kayitlar.View = View.Details;

                foreach (Cls_Sevk item in geciciKayitlar)
                {
                    ListViewItem listViewItem = new ListViewItem(item.OkutulanMiktar.ToString());

                    listViewItem.SubItems.Add(item.PaketMiktar.ToString());
                    listViewItem.SubItems.Add(item.PaketKodu);
                    listViewItem.SubItems.Add(item.PaketAdi);
                    listViewItem.SubItems.Add(item.UrunKodu);
                    listViewItem.SubItems.Add(item.SiparisKodu);
                    listViewItem.SubItems.Add(item.SiparisSira.ToString());
                    listViewItem.SubItems.Add(item.SevkEmriNo);
                    listViewItem.SubItems.Add(item.CariKodu);
                    listViewItem.SubItems.Add(item.CariAdi);
                    listViewItem.SubItems.Add(item.OkutmaTarihi);

                    lst_gecici_kayitlar.Items.Add(listViewItem);
                }
            }
        }
       
        private void btn_sec_clicked(object sender, EventArgs e)
        {
            try
            {
                List<Cls_Sevk> secilenKayit = new List<Cls_Sevk>();
                List<Cls_Barcodes> secilenBarkodlar = new List<Cls_Barcodes>();


                for (int i = 0; i < lst_gecici_kayitlar.Items.Count; i++)
                {
                    ListViewItem listviewitem = lst_gecici_kayitlar.Items[i];

                    if (listviewitem.Checked)
                    {
                        Cls_Sevk sevkItem = new Cls_Sevk
                        {

                            OkutulanMiktar = Convert.ToInt32(listviewitem.SubItems[0].Text),
                            PaketMiktar = Convert.ToInt32(listviewitem.SubItems[1].Text),
                            PaketKodu = listviewitem.SubItems[2].Text,
                            PaketAdi = listviewitem.SubItems[3].Text,
                            UrunKodu = listviewitem.SubItems[4].Text,
                            SiparisKodu = listviewitem.SubItems[5].Text,
                            SiparisSira = Convert.ToInt32(listviewitem.SubItems[6].Text),
                            SevkEmriNo = listviewitem.SubItems[7].Text,
                            CariKodu = listviewitem.SubItems[8].Text,
                            CariAdi = listviewitem.SubItems[9].Text,

                        };
                        secilenKayit.Add(sevkItem);

                        string kisit = string.Format("where urunKodu='{0}' and sipNo='{1}' and sipSatir={2}",
                                                     sevkItem.UrunKodu, sevkItem.SiparisKodu, sevkItem.SiparisSira);

                        secilenBarkodlar = barcodes.GetBarcodeNumbers(kisit, veriYili);

                    }
                }

                var distinctCari = secilenKayit.Select(cari => cari.CariKodu).Distinct();

                if (!secilenBarkodlar.Any())
                {
                    MessageBox.Show("Okutulan Barkod Bulunamadı.");
                    return;
                }

                if (distinctCari.Count() > 1)
                {
                    MessageBox.Show("1'den Fazla Cari Seçilemez.");
                    return;
                }


                if (!secilenKayit.Any())
                {
                    MessageBox.Show("Kayıt Seçilmedi.");
                    return;
                }
                if (distinctCari.Count() == 1)
                {
                    Frm_Paket_Listesi frm = new Frm_Paket_Listesi(secilenKayit, secilenBarkodlar, kullaniciKodu, veriYili);
                    frm.Show();
                    this.Hide();
                }
            }
            catch(Exception ex) {MessageBox.Show(ex.Message.ToString());}
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Program Kapatılacak Emin Misiniz?",
                                        "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button3);
            if (answer == DialogResult.Yes)
                Application.Exit();
            else
                return;
        }

        private void btn_back_clicked(object sender, EventArgs e)
        {
            string paketKist=string.Empty;
            List<Cls_Sevk> paketGeriListe = new List<Cls_Sevk>();
            Frm_Cari_Secim cari = new Frm_Cari_Secim(kullaniciKodu,veriYili,paketKist,paketGeriListe);
            cari.Show();
            this.Hide();
        }


        private void btn_delete_clicked(object sender, EventArgs e)
        {
            var msgResult = MessageBox.Show("Seçilen Kayıtlar Silinecek.\r\nOnaylıyor Musunuz?", "Onay", MessageBoxButtons.YesNo, 
                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

            if(msgResult == DialogResult.No)
                return;

            List<Cls_Sevk> geciciKayitlar = new List<Cls_Sevk>();
            int counter = 0;
            for (int i = 0; i < lst_gecici_kayitlar.Items.Count; i++)
            {
                ListViewItem listviewitem = lst_gecici_kayitlar.Items[i];
                
                    if (listviewitem.Checked)
                    {
                        Cls_Sevk sevkItem = new Cls_Sevk
                        {
                            PaketKodu = listviewitem.SubItems[2].Text,
                            UrunKodu = listviewitem.SubItems[4].Text,
                            SiparisKodu = listviewitem.SubItems[5].Text,
                            SiparisSira = Convert.ToInt32(listviewitem.SubItems[6].Text),

                        };
                        geciciKayitlar.Add(sevkItem);
                        counter++;
                    }

            }
            if (counter > 0)
            {
                bool result = sevk.GeciciYuklemeSil(geciciKayitlar, veriYili);
                if (result)
                {
                    MessageBox.Show("Seçilen Kayıtlar Silindi.");
                    Frm_Gecici_Kayitlar frm = new Frm_Gecici_Kayitlar(kullaniciKodu, veriYili);
                    frm.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Kayıtlar Geri Alınırken Problem İle Karşılaşıldı.");
                    
            }
            else
                MessageBox.Show("Hiç Seçim Yapılmadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button2);
        }
     
    }
}