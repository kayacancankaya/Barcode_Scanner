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
    public partial class Frm_Sevk_Emirleri : Form
    {
        Cls_Sevk sevk = new Cls_Sevk();
        List<Cls_Sevk> sevkListesi = new List<Cls_Sevk>();
        List<Cls_Sevk> paketGeriListe = new List<Cls_Sevk>();
        List<Cls_Barcodes> okutulanBarkodlarGeriListe = new List<Cls_Barcodes>();
        List<Cls_Sevk> okutulanMiktarFiltrele = new List<Cls_Sevk>();
        List<string> secilenSevkEmirleri = new List<string>();
        int kullaniciKodu = 0;
        string veriYili = string.Empty;
        string sevkKisit = string.Empty;
        public Frm_Sevk_Emirleri()
        {
            InitializeComponent();
        }

        public Frm_Sevk_Emirleri(string kisit, int userId, string yil, List<Cls_Sevk>PaketListe, List<Cls_Barcodes>okutulanBarkodlar)
        {
            InitializeComponent();

            kullaniciKodu = userId;
            veriYili = yil;
            sevkKisit = kisit;
            paketGeriListe = PaketListe;
            okutulanBarkodlarGeriListe = okutulanBarkodlar;
            try
            {
                if (PaketListe.Any())
                {
                    secilenSevkEmirleri = PaketListe.Select(item => item.SevkEmriNo).Distinct().ToList();
                }
                lst_sevk_listesi.Items.Clear();

                lst_sevk_listesi.CheckBoxes = true;

                sevkListesi = sevk.PopulateSevkList(yil, kisit);

                if (sevkListesi == null)
                {
                    MessageBox.Show("Veri Tabanına Bağlanırken Hata İle Karşılaşıldı.");
                    return;
                }

                if (sevkListesi.Count == 0)
                {
                    MessageBox.Show("Sorgu Boş Sonuç Döndürdü.");
                    return;
                }

                if (sevkListesi.Count > 0)
                {
                    lst_sevk_listesi.View = View.Details;

                    foreach (Cls_Sevk item in sevkListesi)
                    {
                        ListViewItem listViewItem = new ListViewItem(item.SevkEmriNo);

                        if (secilenSevkEmirleri.Contains(item.SevkEmriNo))
                            listViewItem.Checked=true;

                        listViewItem.SubItems.Add(item.CariAdi);

                        lst_sevk_listesi.Items.Add(listViewItem);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        string paketKisit = string.Empty;
        private void btn_listele_clicked(object sender, EventArgs e)
        {
            try
            {
                int counter = 0;
                if (paketGeriListe.Any())
                {
                    string ilavePaketlerIcinKisit = string.Empty;
                    List<Cls_Sevk> ilavePaketlerIcinListe = new List<Cls_Sevk>();

                    for (int i = 0; i < lst_sevk_listesi.Items.Count; i++)
                    {
                        ListViewItem listviewitem = lst_sevk_listesi.Items[i];

                        if (listviewitem.Checked == true && secilenSevkEmirleri.Contains(listviewitem.Text) == false)
                        {
                            paketKisit = paketKisit + string.Format("(SevkEmriNo='{0}') or ",
                                                           listviewitem.Text);

                            ilavePaketlerIcinKisit = ilavePaketlerIcinKisit + string.Format("(SevkEmriNo='{0}') or ",
                                                           listviewitem.Text);

                        }
                    }
                    if(!string.IsNullOrEmpty(ilavePaketlerIcinKisit))
                    {
                        ilavePaketlerIcinListe = sevk.PopulatePaketList(ilavePaketlerIcinKisit, veriYili);
                        
                        if (ilavePaketlerIcinListe.Any())
                        {
                            foreach (var item in ilavePaketlerIcinListe)
                            {
                                paketGeriListe.Add(item);
                            }
                        }
                    }
                    counter = 1;
                }
                else
                {
                    for (int i = 0; i < lst_sevk_listesi.Items.Count; i++)
                    {
                        ListViewItem listviewitem = lst_sevk_listesi.Items[i];

                        if (listviewitem.Checked == true)
                        {
                            paketKisit = paketKisit + string.Format("(SevkEmriNo='{0}') or ",
                                                           listviewitem.Text);

                            counter++;
                        }
                    }
                }
                
                if (counter == 0)
                {
                    MessageBox.Show("Sevk Emri Seçiniz");
                    return;
                }

                Frm_Paket_Listesi frm2 = new Frm_Paket_Listesi(paketKisit, veriYili, kullaniciKodu, sevkKisit, paketGeriListe, okutulanBarkodlarGeriListe);

                frm2.Show();
                this.Hide();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
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

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yapmış olduğunuz değişiklikler iptal edilecek.\n Onaylıyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                Frm_Cari_Secim frm = new Frm_Cari_Secim(kullaniciKodu,veriYili,paketKisit,paketGeriListe);

                this.Hide();
                frm.Show();
            }
            else return;
        }
    }
}