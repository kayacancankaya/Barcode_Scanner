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
    public partial class Frm_Yukle : Form
    {
        public Frm_Yukle()
        {
            InitializeComponent();

        }
  
        List<Cls_Barcodes> scannedBarcodes = new List<Cls_Barcodes>();
        Cls_Sevk sevk = new Cls_Sevk();
        List<Cls_Sevk> paketListe = new List<Cls_Sevk>();
        string veriYili = string.Empty;
        string sevkGeriKisit = string.Empty;
        int kullaniciKodu = 0;
        string paketKisit = string.Empty;

        List<Cls_Sevk> tamamlananYuklemeler = new List<Cls_Sevk>();
        bool result = false;
        public Frm_Yukle(string paketKisitGeri, string yil, int userID, string sevkKisit, List<Cls_Sevk> paketGeriListe, List<Cls_Barcodes> okutulanBarkodlar)
        {
            InitializeComponent();

            kullaniciKodu = userID;

            veriYili = yil;

            sevkGeriKisit = sevkKisit;

            paketListe = paketGeriListe;
            paketKisit = paketKisitGeri;
            scannedBarcodes = okutulanBarkodlar;

            tamamlananYuklemeler = sevk.PopulateTamamlananYuklemelerList(veriYili);
            lst_yukleme_tamamla.Items.Clear();

            if (tamamlananYuklemeler == null) return;

            if (tamamlananYuklemeler.Count > 0)
            {

                lst_yukleme_tamamla.View = View.Details;
                
                foreach (Cls_Sevk item in tamamlananYuklemeler)
                {
                    ListViewItem listViewItem = new ListViewItem(item.SevkEmriNo);
                    
                    listViewItem.SubItems.Add(item.CariAdi);
                    listViewItem.SubItems.Add(item.YuklemeEmriNo);
                    listViewItem.SubItems.Add(item.OkutulanMiktar.ToString());
                    listViewItem.SubItems.Add(item.UrunKodu);
                    listViewItem.SubItems.Add(item.SiparisKodu);
                    listViewItem.SubItems.Add(item.SiparisSira.ToString());
                    listViewItem.SubItems.Add(item.CariKodu);


                    lst_yukleme_tamamla.Items.Add(listViewItem);
                  
                }
                
            }

        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                int counter = 0;
                List<Cls_Sevk> yuklenecekSevk = new List<Cls_Sevk>();
                string sevkIrsaliyeNo = string.Empty;
                string cariKodu = string.Empty;
                bool irsaliye_ = false;

                for (int i = 0; i < lst_yukleme_tamamla.Items.Count; i++)
                {
                    

                    ListViewItem listViewItem = lst_yukleme_tamamla.Items[i];
                    
                    if (listViewItem.Checked == true)
                    {
                        if (i == 0)
                        {
                            cariKodu = listViewItem.SubItems[7].Text;
                            sevkIrsaliyeNo = sevk.GetSevkIrsaliyeNo(veriYili, cariKodu);
                        }

                        if (i != 0)
                        {
                            ListViewItem listViewItemAnterior = lst_yukleme_tamamla.Items[i-1];
                            if (listViewItem.SubItems[7].Text != listViewItemAnterior.SubItems[7].Text)
                            {
                                cariKodu = listViewItem.SubItems[7].Text;
                                sevkIrsaliyeNo = sevk.GetSevkIrsaliyeNo(veriYili, cariKodu);
                            }
                        }

                    if (sevkIrsaliyeNo == "HATA")
                    {
                        MessageBox.Show("İrsaliye Numarası Alınırken Hata İle Karşılaşıldı.");
                        return;
                    }

                    if (sevkIrsaliyeNo == "IRSALIYE NO VAR")
                    {
                       MessageBox.Show("Bu Cariye Ait Yüklenmeyi Bekleyen Kayıt Mevcut Olduğundan \n\r İşlem Yapılmadı. Cari Kod:" + cariKodu);
                       return;
                    }

                    
                        Cls_Sevk sevkItem = new Cls_Sevk
                        {
                            SiparisKodu = listViewItem.SubItems[5].Text,
                            CariKodu = listViewItem.SubItems[7].Text,
                            SevkIrsaliyeNo = sevkIrsaliyeNo, 
                            SevkEmriNo = listViewItem.SubItems[0].Text,
                        };
 
                        yuklenecekSevk.Add(sevkItem);

                        counter++;
                    }
                }

                if (counter == 0)
                {
                    MessageBox.Show("Seçim Yapmadınız.");
                    return;
                }

                result = sevk.SevkIrsaliyesiKaydet(yuklenecekSevk, kullaniciKodu, veriYili, irsaliye_);
                
                    if (result)
                    {
                        MessageBox.Show("Yükleme Kaydedildi.");

                        paketListe.Clear();
                        paketKisit = string.Empty;

                        Frm_Cari_Secim cari = new Frm_Cari_Secim(kullaniciKodu, veriYili, paketKisit, paketListe);
                        cari.Show();
                        this.Close();
                    }
                    if (!result)
                    {
                        MessageBox.Show("Yükleme Kaydedilirken Hata İle Karşılaşıldı.");
                    }
                
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            try
            {
                var msgResult = MessageBox.Show("Seçilen Kayıtlar Silinecek.\r\nOnaylıyor Musunuz?", "Onay", MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

                if (msgResult == DialogResult.No)
                    return;

                List<Cls_Sevk> yuklemeSil = new List<Cls_Sevk>();
                List<Cls_Sevk> tumYuklemeler = new List<Cls_Sevk>();
                int counter = 0;
                for (int i = 0; i < lst_yukleme_tamamla.Items.Count; i++)
                {
                    ListViewItem listviewitem = lst_yukleme_tamamla.Items[i];

                    Cls_Sevk sevkItem = new Cls_Sevk
                    {
                        SevkEmriNo = listviewitem.SubItems[0].Text,
                        YuklemeEmriNo = listviewitem.SubItems[2].Text,
                        UrunKodu = listviewitem.SubItems[4].Text,
                        SiparisKodu = listviewitem.SubItems[5].Text,
                        SiparisSira = Convert.ToInt32(listviewitem.SubItems[6].Text),
                        OkutulanMiktar = Convert.ToInt32(listviewitem.SubItems[3].Text),

                    };

                    if (listviewitem.Checked)
                    {
                        Cls_Sevk silinecekItem = new Cls_Sevk
                        {
                            SevkEmriNo = listviewitem.SubItems[0].Text,
                            YuklemeEmriNo = listviewitem.SubItems[2].Text,
                            UrunKodu = listviewitem.SubItems[4].Text,
                            SiparisKodu = listviewitem.SubItems[5].Text,
                            SiparisSira = Convert.ToInt32(listviewitem.SubItems[6].Text),
                            OkutulanMiktar = Convert.ToInt32(listviewitem.SubItems[3].Text),

                        };
                    
                        yuklemeSil.Add(silinecekItem);
                        counter++;
                    }

                    tumYuklemeler.Add(sevkItem);
                }
                if (counter > 0)
                {
                    bool result = sevk.KayitlariGeriAl(tumYuklemeler, yuklemeSil, veriYili);
                    if (result)
                    {
                        MessageBox.Show("Seçilen Kayıtlar Silindi.");
                        paketListe.Clear();
                        paketKisit = string.Empty;

                        Frm_Cari_Secim cari = new Frm_Cari_Secim(kullaniciKodu, veriYili, paketKisit, paketListe);
                        cari.Show();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Kayıtlar Geri Alınırken Problem İle Karşılaşıldı.");

                }
                else
                    MessageBox.Show("Hiç Seçim Yapılmadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            paketKisit = string.Empty;
            paketListe.Clear();
            Frm_Cari_Secim cari = new Frm_Cari_Secim(kullaniciKodu,veriYili,paketKisit,paketListe);
            cari.Show();
            this.Close();
        }

        private void btn_close_Click_1(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Program Kapatılacak Emin Misiniz?",
                                        "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button3);
            if (answer == DialogResult.Yes)
                Application.Exit();
            else
                return;
        }
    }
}