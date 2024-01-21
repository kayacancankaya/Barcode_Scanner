using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Linq;

namespace VbElTerminali.Classes
{
    public class Cls_Sevk
    {

        public bool IsChecked { get; set; }

        public string SevkIrsaliyeNo { get; set; }

        public string SevkEmriNo { get; set; }

        public string YuklemeEmriNo { get; set; }

        public string YuklemeIsemriNo { get; set; }

        public string UrunKodu { get; set; }

        public string UrunAdi { get; set; }

        public string CariKodu { get; set; }

        public string CariAdi { get; set; }

        public string PaketKodu { get; set; }

        public string PaketAdi { get; set; }

        public string SiparisKodu { get; set; }

        public int SiparisSira { get; set; }

        public int PaketMiktar { get; set; }

        public int OkutulanMiktar { get; set; }

        public int SiparisMiktar { get; set; }

        public string OkutmaTarihi { get; set; }

        public List<Cls_Sevk> list_collection_sevk = new List<Cls_Sevk>(); 

        readonly DataLayer dataLayer = new DataLayer();
        SqlDataReader reader;

        private string query = string.Empty;

        public List<Cls_Sevk> PopulateCariList(string yil)
        {
            try
            {
                query = "Select Distinct CariKodu,CariIsim from vbvSevkListe";

                list_collection_sevk.Clear();

                reader = dataLayer.Select_Command_Data_Reader(query, yil);

                if (reader == null)
                {
                    MessageBox.Show("Sorgu Boş Sonuç Döndürdü");
                    return null;
                }


                while (reader.Read())
                {
                    Cls_Sevk data_collection_sevk = new Cls_Sevk
                    {
                        CariKodu = reader[0].ToString(),
                        CariAdi = reader[1].ToString(),
                    };
                    list_collection_sevk.Add(data_collection_sevk);
                }

                reader.Close();

                return list_collection_sevk;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }

        public List<Cls_Sevk> PopulateSevkList(string yil, string kisit)
        {
            try
            {
                list_collection_sevk.Clear();
                query = "Select Distinct BelgeNo,CariIsim from vbvSevkListe where " + kisit;

                reader = dataLayer.Select_Command_Data_Reader(query,yil);

                if (reader == null)
                {
                    MessageBox.Show("Sorgu Boş Sonuç Döndürdü");
                    return null;
                }


                while (reader.Read()) 
                {
                    Cls_Sevk data_collection_sevk = new Cls_Sevk
                    {
                        SevkEmriNo = reader[0].ToString(),
                        CariAdi = reader[1].ToString(),
                    };
                    list_collection_sevk.Add(data_collection_sevk);
                }

                reader.Close();

                return list_collection_sevk;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString()); 
                return null;
            }
        }

        public List<Cls_Sevk> PopulatePaketList(string kisit, string yil)
        {
            try
            {
                list_collection_sevk.Clear();

                query = "Select * from vbvSevkPaketListele where 1=1 and (" + kisit;

                query = query.Substring(0,query.Length - 4);

                query += ")";

                reader = dataLayer.Select_Command_Data_Reader(query, yil);

                if (reader == null)
                {
                    MessageBox.Show("Sorgu Boş Sonuç Döndürdü");
                    return null;
                }

                while (reader.Read())
                {
                    Cls_Sevk data_collection_sevk = new Cls_Sevk
                    {
                        OkutulanMiktar = 0,
                        PaketMiktar = Convert.ToInt32(reader[0]),
                        PaketKodu = reader[1].ToString(),
                        PaketAdi = reader[2].ToString(),
                        UrunKodu = reader[3].ToString(),
                        SevkEmriNo = reader[4].ToString(),
                        CariAdi = reader[5].ToString(),
                        SiparisKodu = reader[6].ToString(),
                        SiparisSira = Convert.ToInt32(reader[7]),
                        CariKodu = reader[8].ToString(),
                    };
                    list_collection_sevk.Add(data_collection_sevk);
                }

                reader.Close();

                return list_collection_sevk;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public List<Cls_Sevk> PopulateTamamlananYuklemelerList(string yil)
        {
            try
            {
                list_collection_sevk.Clear();

                query = "Select * from vbvSevkTamamlananYuklemeler";

                reader = dataLayer.Select_Command_Data_Reader(query, yil);

                if (reader == null)
                {
                    MessageBox.Show("Sorgu Boş Sonuç Döndürdü");
                    return null;
                }

                while (reader.Read())
                {
                    Cls_Sevk data_collection_sevk = new Cls_Sevk
                    {
                        SevkEmriNo = reader[0].ToString(),
                        CariAdi = reader[1].ToString(),
                        YuklemeEmriNo = reader[2].ToString(),
                        OkutulanMiktar = Convert.ToInt32(reader[3]),
                        UrunKodu = reader[4].ToString(),
                        SiparisKodu = reader[5].ToString(),
                        SiparisSira = Convert.ToInt32(reader[6]),
                        CariKodu = reader[7].ToString(),
                    };
                    list_collection_sevk.Add(data_collection_sevk);
                }

                reader.Close();

                return list_collection_sevk;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public List<Cls_Sevk> PopulateGeciciKayitlar(string yil)
        {
            try
            {
                query = "select * from vbtElTerminaliGeciciKayit order by tarih desc";
                reader = dataLayer.Select_Command_Data_Reader(query, yil);

                if (reader == null)
                {
                    MessageBox.Show("Sorgu Boş Sonuç Döndürdü");
                    return null;
                }

                while (reader.Read())
                {
                    Cls_Sevk data_collection_sevk = new Cls_Sevk
                    {
                        OkutulanMiktar = Convert.ToInt32(reader[0]),
                        PaketMiktar = Convert.ToInt32(reader[1]),
                        PaketKodu = reader[2].ToString(),
                        PaketAdi = reader[3].ToString(),
                        UrunKodu = reader[4].ToString(),
                        SiparisKodu = reader[5].ToString(),
                        SiparisSira = Convert.ToInt32(reader[6]),
                        SevkEmriNo = reader[7].ToString(),
                        CariAdi = reader[8].ToString(),
                        CariKodu = reader[9].ToString(),
                        OkutmaTarihi = reader[10].ToString(),
                    };
                    list_collection_sevk.Add(data_collection_sevk);
                }
                reader.Close();
                return list_collection_sevk;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
            
        public List<Cls_Sevk> PopulatePaketListWithGeciciKayit(string yil, string kisit)
        {
            try
            {
                list_collection_sevk.Clear();
                query = "Select * from vbvSevkListe where " + kisit;

                reader = dataLayer.Select_Command_Data_Reader(query,yil);

                if (reader == null)
                {
                    MessageBox.Show("Sorgu Boş Sonuç Döndürdü");
                    return null;
                }


                while (reader.Read()) 
                {
                    Cls_Sevk data_collection_sevk = new Cls_Sevk
                    {
                        SevkEmriNo = reader[0].ToString(),
                        CariAdi = reader[1].ToString(),
                    };
                    list_collection_sevk.Add(data_collection_sevk);
                }
                reader.Close();
                return list_collection_sevk;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString()); 
                return null;
            }
        }
    
        public bool KayitlariGeriAl(List<Cls_Sevk> tumKayitlar, List<Cls_Sevk> silinecekKayit, string yil)
        {
            try
            {
                // Sort both lists by SevkEmriNo
                tumKayitlar = tumKayitlar.OrderBy(item => item.SevkEmriNo).ToList();
                silinecekKayit = silinecekKayit.OrderBy(item => item.SevkEmriNo).ToList();

                int tumKayitlarIndex = 0;
                int silinecekKayitIndex = 0;
                bool result = false;
                while (tumKayitlarIndex < tumKayitlar.Count && silinecekKayitIndex < silinecekKayit.Count)
                {
                    int tumKayitlarCount = 0;
                    int silinecekKayitCount = 0;

                    // Tüm Kayıtlardaki sevk emri no adedini say
                    string currentSevkEmriNo = tumKayitlar[tumKayitlarIndex].SevkEmriNo;
                    while (tumKayitlarIndex < tumKayitlar.Count && tumKayitlar[tumKayitlarIndex].SevkEmriNo == currentSevkEmriNo)
                    {
                        tumKayitlarCount++;
                        tumKayitlarIndex++;
                    }

                    // silinecek kayıtlardaki sevk emri no adedini say
                    while (silinecekKayitIndex < silinecekKayit.Count && silinecekKayit[silinecekKayitIndex].SevkEmriNo == currentSevkEmriNo)
                    {
                        silinecekKayitCount++;
                        silinecekKayitIndex++;
                    }

                        // eğer tüm kayıtlarda daha çok aynı sevk emri nosunu içeren satır var ise sadece silinecekKayitlarin satırlarını sil
                    if (silinecekKayitCount > 0)
                    {
                            if (tumKayitlarCount >= silinecekKayitCount)
                            {
                                Cls_Sevk sevkSilinecek = new Cls_Sevk();
                                sevkSilinecek.SevkEmriNo = currentSevkEmriNo;
                                List<Cls_Sevk> silinecekSatir = silinecekKayit.Where(item => item.SevkEmriNo == sevkSilinecek.SevkEmriNo).ToList();

                                foreach (Cls_Sevk item in silinecekSatir)
                                {
                                    result = dataLayer.Delete_Stored_Proc_Satir_Geri_Al("vbpElTerminaliSevkKayitlariGeriAlSatir",
                                                                                         "@belgeNo", currentSevkEmriNo,
                                                                                         "@fisno", item.SiparisKodu,
                                                                                         "@stra_sipkont", item.SiparisSira,
                                                                                         "@urunKodu", item.UrunKodu,
                                                                                         "@okutulanMiktar",item.OkutulanMiktar,
                                                                                         yil);
                                    if (!result) return false;
                                }
                            }

                            if (tumKayitlarCount == silinecekKayitCount)
                            {

                                result = dataLayer.Delete_Stored_Proc_Mas_Geri_Al("vbpElTerminaliSevkKayitlariGeriAl",
                                                                                         "@belgeNo", currentSevkEmriNo,
                                                                                         yil);
                                if (!result) return false;
                            }
                        }

                    }

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool GeciciYuklemeKaydet(List<Cls_Sevk> geciciPaketler, string yil)
        {
            try
            {
                bool result = false;

                result = GeciciTabloBosalt(yil);

                if (!result)
                    return false;

                foreach (Cls_Sevk item in geciciPaketler)
                {

                    result = dataLayer.Insert_Stored_Proc_Gecici_Paket("vbpElTerminaliGeciciKayit",
                                                                         "@okutulanMiktar", item.OkutulanMiktar,
                                                                         "@paketMiktar", item.PaketMiktar,
                                                                         "@paketKodu", item.PaketKodu,
                                                                         "@paketAdi", item.PaketAdi,
                                                                         "@urunKodu", item.UrunKodu,
                                                                         "@sipNo", item.SiparisKodu,
                                                                         "@sipSatir", item.SiparisSira,
                                                                         "@sevkEmriNo", item.SevkEmriNo,
                                                                         "@cariAdi", item.CariAdi,
                                                                         "@cariKod", item.CariKodu,
                                                                         yil);
                
                   if(!result) return false;
                }

                return true; 
            }
            catch{ return false; }
        }//programdan çıkış yapıldığında atılan kayıt

        public bool GeciciTabloBosalt(string yil)
        {
            try
            {
                dataLayer.Truncate("vbtElTerminaliGeciciKayit",
                                    "vbtElTerminaliGeciciKayitBarcodes", yil);
                return true;
            }
            catch {return false;}
            
        }

        public bool GeciciYuklemeSil(List<Cls_Sevk> geciciKayitlar, string yil)
        {
            try
            {
                bool result = false;
                foreach (Cls_Sevk item in geciciKayitlar)
                {

                    result = dataLayer.Delete_Stored_Proc_Gecici_Paket("vbpElTerminaliGeciciKayitSil",
                                                                         "@paketKodu", item.PaketKodu,
                                                                         "@urunKodu", item.UrunKodu,
                                                                         "@sipNo", item.SiparisKodu,
                                                                         "@sipSatir", item.SiparisSira,
                                                                         yil);
                
                   if(!result) return false;
                }

                return true; 
            }
            catch{ return false; }
        }
       
        public bool OkutulanlariYukle(List<Cls_Sevk> paketKontrol, int kullaniciKodu, string veriYili)
        {
            bool result = false;
            int sira = 0;
            string errorMessage = string.Empty;

            //sevk emirlerinin genel bilgilerini kaydet
            var okutulanMiktarFiltrele = paketKontrol.Where(item => item.OkutulanMiktar > 0).ToList();

            var distinctSevkEmriList = okutulanMiktarFiltrele.Select(item => item.SevkEmriNo).Distinct().ToList();

            var distinctCariKodu = okutulanMiktarFiltrele.Select(item => item.CariKodu).FirstOrDefault();

            SevkIrsaliyeNo = GetSevkIrsaliyeNo(veriYili,distinctCariKodu);

            if (SevkIrsaliyeNo == "HATA")
            {
                MessageBox.Show("Sevk İrsaliye Numarası Alınamadı.\r\n Veri Tabanına Bağlanırken Hata İle Karşılaşıldı.");
                return false;
            }

            foreach (var SevkEmriNo in distinctSevkEmriList)
            {

                result = dataLayer.Insert_Stored_Proc_Mas("vbpYuklemeKayitMas", "@userID", kullaniciKodu,
                                                          "@belgeNo", SevkEmriNo, veriYili);
                if (!result) return false;
            }
            //sevk emirlerinin satır bilgilerini kaydet
            for (int i = 0; i < paketKontrol.Count; i++)
            {
                sira++;
                result = dataLayer.Insert_Stored_Proc_Satir("vbpYuklemeKayitSatir",
                                                 "@sevkEmriNo", paketKontrol[i].SevkEmriNo,
                                                 "@sipNo", paketKontrol[i].SiparisKodu,
                                                 "@sipKont", paketKontrol[i].SiparisSira,
                                                 "@teslimCari", paketKontrol[i].CariKodu,
                                                 "@sira", sira,
                                                 "@miktar", paketKontrol[i].OkutulanMiktar,
                                                 "@stokKodu", paketKontrol[i].UrunKodu,
                                                 "@userId", kullaniciKodu,
                                                 "@sevkIrsaliyeNo", SevkIrsaliyeNo,
                                                 veriYili);

                if (!result)
                    return false;
            }
            return true;
        }//paket ekranında atılan kayıt
        
        public string GetSevkIrsaliyeNo(string yil, string cariKodu)
        {
            string sevkIrsaliyeNo = dataLayer.Get_Stored_Proc_Sevk_Irsaliye_No(yil,"@cariKodu",cariKodu);

            if (string.IsNullOrEmpty(sevkIrsaliyeNo))
            {
                return "HATA";
            }

            return sevkIrsaliyeNo;
        }

        public string GetExistingSevkIrsaliyeNo(string yil, string cariKodu)
        {
            string existingSevkIrsaliyeNo = dataLayer.Get_Stored_Proc_Sevk_Irsaliye_No_Existing(yil, "@cariKodu",cariKodu);

            if (string.IsNullOrEmpty(existingSevkIrsaliyeNo))
            {
                return "HATA";
            }

            return existingSevkIrsaliyeNo;
        }

        public bool SevkIrsaliyesiKaydet(List<Cls_Sevk> yukleneceklerListesi, int kullaniciKodu, string veriYili, bool irsaliyeVar_)
        {
            try
            {
                bool result = false;
                string errorMessage = string.Empty;
                if (!irsaliyeVar_)
                {
                    var distinctCariList = yukleneceklerListesi.Select(cari => new { cari.CariKodu, cari.SevkIrsaliyeNo }).Distinct().ToList();

                    foreach (var item in distinctCariList)
                    {

                        result = dataLayer.Insert_Stored_Proc_Sevk_Irsaliye("vbpElTerminaliIrsaliyeKaydet",
                                                                            "@cariKodu", item.CariKodu.ToString(),
                                                                            "@kullaniciKodu", kullaniciKodu,
                                                                            "@sevkIrsaliyesiNo", item.SevkIrsaliyeNo.ToString(), veriYili);
                        if (!result) return false;
                    }
                }

                var distinctBelgeNo = yukleneceklerListesi.Select(item => item.SevkEmriNo).Distinct().ToList();

                foreach (var item in distinctBelgeNo)
                {

                    result = dataLayer.Update_IrsFlag("vbpUpdateIrsFlag",
                                                      "@belgeNo", item, 
                                                      "@kullaniciKodu", kullaniciKodu.ToString(),
                                                      veriYili);
                    if (!result) return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }//yukleme tamamla
    
    }
}
