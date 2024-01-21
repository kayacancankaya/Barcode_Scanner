using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VbElTerminali.Classes;
using System.Threading;

namespace VbElTerminali
{
    public partial class Frm_Paket_Listesi : Form
    {
        Cls_Barcodes cls_barcodes = new Cls_Barcodes();
        List<Cls_Barcodes> scannedBarcodes = new List<Cls_Barcodes>();
        private System.Threading.Timer barcodeProcessingTimer;
        private bool isTimeRunning = false;
        private readonly object timerLock = new object();
        Cls_Sevk sevk = new Cls_Sevk();
        List<Cls_Sevk> paketListe = new List<Cls_Sevk>();
        string veriYili = string.Empty;
        string sevkGeriKisit = string.Empty;
        string paketGeriKisit = string.Empty;
        int kullaniciKodu = 0;

        public Frm_Paket_Listesi()
        {
            InitializeComponent();
        }

        public Frm_Paket_Listesi(string kisit, string yil, int userID, string sevkKisit, List<Cls_Sevk>paketGeriListe, List<Cls_Barcodes> okutulanBarkodlar)
        {
            try
            {
                InitializeComponent();

                kullaniciKodu=userID;

                veriYili = yil;

                sevkGeriKisit = sevkKisit;

                paketGeriKisit = kisit;

                txt_barcode.Focus();

                barcodeProcessingTimer = new System.Threading.Timer(TimerCallBack, null, Timeout.Infinite, Timeout.Infinite);

                if (paketGeriListe.Any())
                {
                    paketListe = paketGeriListe;
                    scannedBarcodes = okutulanBarkodlar;
                }
                else
                    paketListe = sevk.PopulatePaketList(kisit, yil);
                
                lst_paket_liste.Items.Clear();

                if (paketListe == null) return;

                if (paketListe.Count > 0)
                {

                    lst_paket_liste.View = View.Details;

                    foreach (Cls_Sevk item in paketListe)
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

                        lst_paket_liste.Items.Add(listViewItem);
                    }
                }

                if (paketGeriListe.Any()) Renklendir();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }
        string cari_kodu_tamamlanmanyan_yukleme = string.Empty;
        public Frm_Paket_Listesi(List<Cls_Sevk> geciciKayit, List<Cls_Barcodes> geciciBarcodes, int userId, string yil)
        {
            try
            {
                InitializeComponent();

                kullaniciKodu = userId;
                veriYili = yil;
                paketListe = geciciKayit;
                Cls_Sevk firstItem = geciciKayit.FirstOrDefault();
                if (firstItem != null)
                {
                    cari_kodu_tamamlanmanyan_yukleme = firstItem.CariKodu;
                }
                else
                {
                    MessageBox.Show("Geçici Kaydın Cari Bilgisine Ulaşılamadı");
                    return;
                }

                sevkGeriKisit = string.Format("CariKodu='{0}'", cari_kodu_tamamlanmanyan_yukleme);

                var yuklenmeyenSevkEmriList = geciciKayit.Select(item => item.SevkEmriNo).Distinct().ToList();

                foreach (var SevkEmriNo in yuklenmeyenSevkEmriList)
                {

                    paketGeriKisit = paketGeriKisit + string.Format("(SevkEmriNo='{0}') or ",
                                                           SevkEmriNo);

                }

                txt_barcode.Focus();

                scannedBarcodes = geciciBarcodes;

                barcodeProcessingTimer = new System.Threading.Timer(TimerCallBack, null, Timeout.Infinite, Timeout.Infinite);

                lst_paket_liste.Items.Clear();

                if (paketListe == null) return;

                if (paketListe.Count > 0)
                {

                    lst_paket_liste.View = View.Details;

                    foreach (Cls_Sevk item in paketListe)
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

                        lst_paket_liste.Items.Add(listViewItem);
                    }
                }

                if (paketListe.Any()) Renklendir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void btn_back_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Sevk Ekranına Geri Dönülecek.\n Onaylıyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                Frm_Sevk_Emirleri frm = new Frm_Sevk_Emirleri(sevkGeriKisit,kullaniciKodu,veriYili,paketListe, scannedBarcodes);

                this.Hide();
                frm.Show();
            }
            else return;
        }
      
        private void BarkodKaydet(object sender, KeyEventArgs e)
        {
            try
            {

                string barcode = txt_barcode.Text.Trim();
                Cls_Barcodes okutulanBarcode = new Cls_Barcodes();
                okutulanBarcode.BarcodeNo = barcode;
                var barcodesInList = scannedBarcodes.Select(item => item.BarcodeNo).ToList();

                if (!barcodesInList.Contains(okutulanBarcode.BarcodeNo) && string.IsNullOrEmpty(barcode) == false &&
                    barcode.Length > 11)
                {
                    if (!isTimeRunning)
                    {
                        barcodeProcessingTimer.Change(1000, System.Threading.Timeout.Infinite);
                        isTimeRunning = true;
                        string okutulanPaket = OkutulanPaketiBul(barcode);
                        sevk.PaketKodu = okutulanPaket;

                        bool paketMevcutMu = false;
                        foreach (Cls_Sevk item in paketListe)
                        {
                            if (sevk.PaketKodu == item.PaketKodu)
                            {
                                paketMevcutMu = true;
                                break;
                            }
                        }
                        if(!paketMevcutMu)
                            MessageBox.Show("Okutulan Paket Listede Mevcut Değil");
                        else   
                            OkutulanMiktarArttir(okutulanPaket,barcode);
                    }
                }
                else
                {
                    MessageBox.Show("Birden Fazla Aynı Barkod Okutuldu.");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            txt_barcode.Text = string.Empty;
        }

        private void BarkodGeriAl(object sender, KeyEventArgs e)
        {
            try
            {
                string barcode = txt_geri_al.Text.Trim();

                Cls_Barcodes silinecekBarkod = new Cls_Barcodes();

                silinecekBarkod.BarcodeNo = barcode;
                var barcodesInList = scannedBarcodes.Select(item => item.BarcodeNo).ToList();

                if (barcodesInList.Contains(barcode) && string.IsNullOrEmpty(barcode) == false &&
                    barcode.Length > 11)
                {
                    if (!isTimeRunning)
                    {
                        barcodeProcessingTimer.Change(1000, System.Threading.Timeout.Infinite);
                        isTimeRunning = true;

                        string okutulanPaket = OkutulanPaketiBul(barcode);
                        OkutulanMiktarDusur(okutulanPaket,barcode);

                     }
                }

                else
                {
                    MessageBox.Show(barcode + "Listede Mevcut Değil.");

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            txt_geri_al.Text = string.Empty;
        }

        private string OkutulanPaketiBul(string barcode)
        {
            int indexOfTimeStampSeperator = barcode.IndexOf("_");

            if (indexOfTimeStampSeperator > 0)
            {
                string paketKodu = barcode.Substring(0, indexOfTimeStampSeperator);
                return paketKodu;
            }
            else return null;
        }

        bool barkodEkle_ = false;
       
        private void OkutulanMiktarArttir(string okutulanPaketKodu, string barcode)
        {


            foreach (Cls_Sevk item in paketListe)
            {
                if (item.PaketKodu == okutulanPaketKodu)
                {
                    if (item.OkutulanMiktar == item.PaketMiktar)
                    {
                        MessageBox.Show("Okutulan Miktar Paket Miktarından Büyük Olamaz");
                        return;
                    }

                    item.OkutulanMiktar = item.OkutulanMiktar + 1;
                    
                    barkodEkle_=true;

                    BarkodListesineBarkodEkleCikar(barcode, okutulanPaketKodu, item.PaketAdi,
                                                   item.UrunKodu, item.SiparisKodu, item.SiparisSira, barkodEkle_);

                    if (item.OkutulanMiktar == item.PaketMiktar)
                    {
                        RenklendirVeMiktarDegistir("yesil", true, item);
                    }

                    else RenklendirVeMiktarDegistir("sari", true, item);

                    break;
                }
            }

        }

        private void OkutulanMiktarDusur(string okutulanPaketKodu, string barcode)
        {
            foreach (Cls_Sevk item in paketListe)
            {
                if (item.PaketKodu == okutulanPaketKodu)
                {
                    item.OkutulanMiktar = item.OkutulanMiktar - 1;

                    barkodEkle_ = false;
                    BarkodListesineBarkodEkleCikar(barcode, okutulanPaketKodu, item.PaketAdi,
                                                   item.UrunKodu, item.SiparisKodu, item.SiparisSira, barkodEkle_);

                    if (item.OkutulanMiktar == item.PaketMiktar)
                    {
                        RenklendirVeMiktarDegistir("yesil", false, item);
                    }

                    else RenklendirVeMiktarDegistir("sari", false, item);
                    break;

                }
            }
        }

        private void BarkodListesineBarkodEkleCikar(string barcode, string okutulanPaketKodu, string okutulanPaketAdi,
                                               string urunKodu, string siparisNo, int siparisSatir, bool ekle_)
        {
            Cls_Barcodes eklenecek_Barkod = new Cls_Barcodes();

            if (ekle_)
            {
                eklenecek_Barkod.BarcodeNo = barcode;
                eklenecek_Barkod.PaketKodu = okutulanPaketKodu;
                eklenecek_Barkod.PaketAdi = okutulanPaketAdi;
                eklenecek_Barkod.UrunKodu = urunKodu;
                eklenecek_Barkod.SiparisNo = siparisNo;
                eklenecek_Barkod.SiparisSatir = siparisSatir;

                scannedBarcodes.Add(eklenecek_Barkod);
            }

            if (!ekle_)
            {
                foreach(Cls_Barcodes item in scannedBarcodes)
                {
                    if (item.BarcodeNo == barcode)
                        scannedBarcodes.Remove(item);
                    break;
                }
            }

        }

        private void RenklendirVeMiktarDegistir(string renk, bool arttir_, Cls_Sevk item)
        {
            for (int i = 0; i < lst_paket_liste.Items.Count; i++)
            {
                ListViewItem listViewItem = lst_paket_liste.Items[i];
                if (listViewItem.SubItems[2].Text == item.PaketKodu &&
                    listViewItem.SubItems[4].Text == item.UrunKodu &&
                    listViewItem.SubItems[5].Text == item.SiparisKodu &&
                    Convert.ToInt32(listViewItem.SubItems[6].Text) == item.SiparisSira)

                {
                    if (renk == "yesil")
                        listViewItem.BackColor = Color.Green;
                    if (renk == "sari")
                        listViewItem.BackColor = Color.Yellow;
                    if (arttir_)
                        listViewItem.SubItems[0].Text = (Convert.ToInt32(listViewItem.SubItems[0].Text) + 1).ToString();
                    if (!arttir_)
                        listViewItem.SubItems[0].Text = (Convert.ToInt32(listViewItem.SubItems[0].Text) - 1).ToString();
                    break;
                }
            }
        }

        private void Renklendir()
        {
            {
                for (int i = 0; i < lst_paket_liste.Items.Count; i++)
                {
                    ListViewItem listViewItem = lst_paket_liste.Items[i];
                    if (Convert.ToInt32(listViewItem.SubItems[0].Text) ==
                        Convert.ToInt32(listViewItem.SubItems[1].Text))
                        listViewItem.BackColor = Color.Green;

                    if (Convert.ToInt32(listViewItem.SubItems[0].Text) <
                        Convert.ToInt32(listViewItem.SubItems[1].Text) &&
                        Convert.ToInt32(listViewItem.SubItems[0].Text) > 0)
                        listViewItem.BackColor = Color.Yellow;
                }
            }
        }

        private void TimerCallBack(object state)
        {
            isTimeRunning = false;
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

        bool result = false;
        string messageText = string.Empty;
        string messageTextSatir = string.Empty;

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                List<Cls_Sevk> paketKontrol = new List<Cls_Sevk>();

               

                for (int i = 0; i < lst_paket_liste.Items.Count; i++)
                {
                    ListViewItem listviewitem = lst_paket_liste.Items[i];

                    Cls_Sevk sevkItem = new Cls_Sevk
                    {
                        OkutulanMiktar = Convert.ToInt32(listviewitem.Text),
			            PaketMiktar = Convert.ToInt32(listviewitem.SubItems[1].Text),
                        PaketKodu = listviewitem.SubItems[2].Text,
                        UrunKodu = listviewitem.SubItems[4].Text,
                        SiparisKodu = listviewitem.SubItems[5].Text,
                        SiparisSira = Convert.ToInt32(listviewitem.SubItems[6].Text),
                        SevkEmriNo = listviewitem.SubItems[7].Text,
                        CariKodu = listviewitem.SubItems[8].Text,
                        
                    };

                    paketKontrol.Add(sevkItem);

                }

                int gonderilecekMiktar = 0;

                //uyarı mesajı için
                string warningMessage = string.Empty;
                List<string> eksikYuklenecekMamuller = new List<string>();
                string mamulKodu = string.Empty;

                //aynı mamulün paketlerinden en az okutulan kadar yükle
                for (int i = 0; i < paketKontrol.Count; i++)
                {

                    if (i == 0 && paketKontrol.Count == 1)
                    {
                        if (paketKontrol[i].OkutulanMiktar == 0)
                        {
                            MessageBox.Show("Okutulan Barkod Bulunamadı.");
                            return;
                        }
                        if (paketKontrol[i].OkutulanMiktar < paketKontrol[i].PaketMiktar)
                        {
                            mamulKodu = paketKontrol[i].UrunKodu.ToString();
                            if (!eksikYuklenecekMamuller.Contains(mamulKodu))
                            {
                            warningMessage = warningMessage + paketKontrol[i].UrunKodu +
                                    " Sipariş Miktarından Eksik Yüklenecek.\r\n ";

                            eksikYuklenecekMamuller.Add(mamulKodu);
                            }
                            
                        }
                    }


                    if (i == 0 && paketKontrol.Count > 1)
                    {
                        if (paketKontrol[i].UrunKodu != paketKontrol[i + 1].UrunKodu ||
                            paketKontrol[i].SiparisKodu != paketKontrol[i + 1].SiparisKodu ||
                            paketKontrol[i].SiparisSira != paketKontrol[i + 1].SiparisSira)
                        {
                            if (paketKontrol[i].OkutulanMiktar < paketKontrol[i].PaketMiktar &&
                                paketKontrol[i].OkutulanMiktar > 0)
                            {
                                mamulKodu = paketKontrol[i].UrunKodu.ToString();
                                if (!eksikYuklenecekMamuller.Contains(mamulKodu))
                                {
                                    warningMessage = warningMessage + paketKontrol[i].UrunKodu +
                                            " Sipariş Miktarından Eksik Yüklenecek.\r\n ";

                                    eksikYuklenecekMamuller.Add(mamulKodu);
                                }
                            }
                        }

                        if (paketKontrol[i].UrunKodu == paketKontrol[i + 1].UrunKodu &&
                            paketKontrol[i].SiparisKodu == paketKontrol[i + 1].SiparisKodu &&
                            paketKontrol[i].SiparisSira == paketKontrol[i + 1].SiparisSira)
                        {

                            gonderilecekMiktar = paketKontrol[i].OkutulanMiktar;
                            
                        }

                    }

                    if (i == paketKontrol.Count - 1 && i != 0 && (
                        paketKontrol[i].UrunKodu != paketKontrol[i - 1].UrunKodu ||
                        paketKontrol[i].SiparisKodu != paketKontrol[i - 1].SiparisKodu ||
                        paketKontrol[i].SiparisSira != paketKontrol[i - 1].SiparisSira))
                    {
                        if (paketKontrol[i].OkutulanMiktar < paketKontrol[i].PaketMiktar &&
                            paketKontrol[i].OkutulanMiktar > 0)
                        {
                                mamulKodu = paketKontrol[i].UrunKodu.ToString();
                                if (!eksikYuklenecekMamuller.Contains(mamulKodu))
                                {
                                    warningMessage = warningMessage + paketKontrol[i].UrunKodu +
                                            " Sipariş Miktarından Eksik Yüklenecek.\r\n ";

                                    eksikYuklenecekMamuller.Add(mamulKodu);
                                }
                            
                        }
                    }

                    if (i == paketKontrol.Count - 1 && i != 0 && (
                        paketKontrol[i].UrunKodu == paketKontrol[i - 1].UrunKodu &&
                        paketKontrol[i].SiparisKodu == paketKontrol[i - 1].SiparisKodu &&
                        paketKontrol[i].SiparisSira == paketKontrol[i - 1].SiparisSira))
                    {
                        if (paketKontrol[i].OkutulanMiktar < gonderilecekMiktar)
                        {
                            if (paketKontrol[i].OkutulanMiktar > 0)
                            {
                                mamulKodu = paketKontrol[i].UrunKodu.ToString();
                                if (!eksikYuklenecekMamuller.Contains(mamulKodu))
                                {
                                    warningMessage = warningMessage + paketKontrol[i].UrunKodu +
                                            " Sipariş Miktarından Eksik Yüklenecek.\r\n ";

                                    eksikYuklenecekMamuller.Add(mamulKodu);
                                }

                            }

                            var matchingItems = paketKontrol.Where(item =>
                                         item.SiparisKodu == paketKontrol[i].SiparisKodu &&
                                         item.SiparisSira == paketKontrol[i].SiparisSira &&
                                         item.UrunKodu == paketKontrol[i].UrunKodu);

                            foreach (var matchingItem in matchingItems)
                            {
                                matchingItem.OkutulanMiktar = paketKontrol[i].OkutulanMiktar;
                            }
                        }
                    }
    
                    if (i != 0 && i != paketKontrol.Count - 1 && (
                        paketKontrol[i].UrunKodu != paketKontrol[i - 1].UrunKodu ||
                        paketKontrol[i].SiparisKodu != paketKontrol[i - 1].SiparisKodu ||
                        paketKontrol[i].SiparisSira != paketKontrol[i - 1].SiparisSira))
                    {
                        gonderilecekMiktar = paketKontrol[i].OkutulanMiktar;
                    }

                    if (i != 0 && i != paketKontrol.Count - 1 &&
                        paketKontrol[i].UrunKodu == paketKontrol[i + 1].UrunKodu &&
                        paketKontrol[i].SiparisKodu == paketKontrol[i + 1].SiparisKodu &&
                        paketKontrol[i].SiparisSira == paketKontrol[i + 1].SiparisSira)
                    {
                        if (paketKontrol[i].OkutulanMiktar < gonderilecekMiktar)
                        {
                            gonderilecekMiktar = paketKontrol[i].OkutulanMiktar;
                        }
                    }

                    if (i != 0 && i != paketKontrol.Count - 1 && (
                        paketKontrol[i].UrunKodu != paketKontrol[i + 1].UrunKodu ||
                        paketKontrol[i].SiparisKodu != paketKontrol[i + 1].SiparisKodu ||
                        paketKontrol[i].SiparisSira != paketKontrol[i + 1].SiparisSira))
                    {
                        if (paketKontrol[i].OkutulanMiktar < gonderilecekMiktar)
                        {
                            gonderilecekMiktar = paketKontrol[i].OkutulanMiktar;
                        }

                            if (gonderilecekMiktar > 0)
                            {
                                mamulKodu = paketKontrol[i].UrunKodu.ToString();
                                if (!eksikYuklenecekMamuller.Contains(mamulKodu))
                                {
                                    warningMessage = warningMessage + paketKontrol[i].UrunKodu +
                                            " Sipariş Miktarından Eksik Yüklenecek.\r\n ";

                                    eksikYuklenecekMamuller.Add(mamulKodu);
                                }

                            }

                            var matchingItems = paketKontrol.Where(item =>
                                         item.SiparisKodu == paketKontrol[i].SiparisKodu &&
                                         item.SiparisSira == paketKontrol[i].SiparisSira &&
                                         item.UrunKodu == paketKontrol[i].UrunKodu);

                            foreach (var matchingItem in matchingItems)
                            {
                                matchingItem.PaketMiktar = gonderilecekMiktar;
                            }
                        }
                    }

                var okutulanMiktarFiltrele = paketKontrol.Where(item => item.OkutulanMiktar > 0).ToList();

                var cariSayisiKontrol = okutulanMiktarFiltrele.Select(item => item.CariKodu).Distinct();

                if (!okutulanMiktarFiltrele.Any())
                {
                    MessageBox.Show("Okutulan Barkod Bulunamadı.");
                    return;
                }

                if (cariSayisiKontrol.Count() > 1)
                {
                    MessageBox.Show("Aynı Anda Birden Fazla Cariye Yükleme Yapılamaz.");
                    return;
                }

                if (!string.IsNullOrEmpty(warningMessage))
                {
                    var answer = MessageBox.Show(warningMessage + "\r\n Devam Etmek İstiyor Musunuz?",
                                                "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (answer == DialogResult.Yes)
                    {
                        result = sevk.GeciciTabloBosalt(veriYili);
                        if (!result)
                        {
                            MessageBox.Show("Geçici Tablolar Boşaltılırken Hata İle Karşılaşıldı");
                            return;
                        }
                        result = sevk.OkutulanlariYukle(paketKontrol, kullaniciKodu, veriYili);
                        if (!result)
                        {
                            MessageBox.Show("Yükleme Bilgileri Kaydedilirken Hata İle Karşılaşıldı");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Yükleme Bilgileri Kaydedildi.");

                            paketListe.Clear();
                            Frm_Cari_Secim cari = new Frm_Cari_Secim(kullaniciKodu, veriYili, string.Empty, paketListe);
                            cari.Show();
                            this.Close();
                        }

                    }
                    else return;
                }
                else
                {
                    sevk.GeciciTabloBosalt(veriYili);
                    if (!result)
                    {
                        MessageBox.Show("Geçici Tablolar Boşaltılırken Hata İle Karşılaşıldı");
                        return;
                    }

                    result = sevk.OkutulanlariYukle(paketKontrol, kullaniciKodu, veriYili);
                    if (!result)
                    {
                        MessageBox.Show("Yükleme Bilgileri Kaydedilirken Hata İle Karşılaşıldı");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Yükleme Bilgileri Kaydedildi.");

                        paketListe.Clear();
                        Frm_Cari_Secim cari = new Frm_Cari_Secim(kullaniciKodu, veriYili, string.Empty, paketListe);
                        cari.Show();
                        this.Close();
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }//yükleme ekranına bilgileri aktarır

        private void btn_complete_Click(object sender, EventArgs e)
        {
            Frm_Yukle frm = new Frm_Yukle(paketGeriKisit, veriYili, kullaniciKodu, sevkGeriKisit, paketListe, scannedBarcodes);
            frm.Show();
            this.Close();
        }//yükleme ekranını gösterir

        private void btn_kaydet_Click(object sender, EventArgs e) 
        {
            try
            {
                result = sevk.GeciciYuklemeKaydet(paketListe,veriYili);
                if (!result)
                {
                    MessageBox.Show("Sevk Bilgileri Kaydedilirken Hata İle Karşılaşıldı");
                    return;
                }
                result = cls_barcodes.GeciciYuklemeKaydet(scannedBarcodes, veriYili);
                if (!result)
                {
                    MessageBox.Show("Sevk Bilgileri Kaydedilirken Hata İle Karşılaşıldı");
                    return;
                }
                MessageBox.Show("Yükleme Listesi Geçici Olarak Kaydedildi");

                paketGeriKisit = string.Empty;
                paketListe.Clear();

                Frm_Cari_Secim cari = new Frm_Cari_Secim(kullaniciKodu, veriYili,paketGeriKisit,paketListe);
                cari.Show();
                this.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }//programı kapatmak için geçici kayıt

    }
}