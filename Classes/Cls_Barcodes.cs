using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VbElTerminali.Classes
{
    public class Cls_Barcodes
    {
        public string BarcodeNo { get; set; }

        public string PaketKodu { get; set; }

        public string PaketAdi { get; set; }

        public string UrunKodu { get; set; }

        public string SiparisNo { get; set; }

        public int SiparisSatir { get; set; }

        DataLayer dataLayer = new DataLayer();
        List<Cls_Barcodes> list_collection_barcodes = new List<Cls_Barcodes>();
        SqlDataReader reader;

        public List<Cls_Barcodes> GetBarcodeNumbers(string kisit, string yil)
        {
            try 
	        {	        
                string query = "select * from vbtElTerminaliGeciciKayitBarcodes " + kisit;
                list_collection_barcodes.Clear();

                reader = dataLayer.Select_Command_Data_Reader(query, yil);

                if (reader == null)
                {
                    MessageBox.Show("Sorgu Boş Sonuç Döndürdü");
                    return null;
                }


                while (reader.Read())
                {
                    Cls_Barcodes data_collection_barcodes = new Cls_Barcodes
                    {
                        BarcodeNo = reader[0].ToString(),
                        PaketKodu = reader[1].ToString(),
                        PaketAdi = reader[2].ToString(),
                        UrunKodu = reader[3].ToString(),
                        SiparisNo = reader[4].ToString(),
                        SiparisSatir = Convert.ToInt32(reader[5]),
                    };
                    list_collection_barcodes.Add(data_collection_barcodes);
                }

                return list_collection_barcodes;
            }
	        catch (Exception ex)
	        {
		        MessageBox.Show(ex.Message.ToString());
                return null;
	        }
        }

        public bool GeciciYuklemeKaydet(List<Cls_Barcodes> geciciBarkodlar, string yil)
        {
            try
            {
                bool result = false;
                foreach (Cls_Barcodes item in geciciBarkodlar)
                {

                    result = dataLayer.Insert_Stored_Proc_Gecici_Barkod("vbpElTerminaliGeciciKayitBarcodes",
                                                                         "@barcodeNo", item.BarcodeNo,
                                                                         "@paketKodu", item.PaketKodu,
                                                                         "@paketAdi", item.PaketAdi,
                                                                         "@urunKodu", item.UrunKodu,
                                                                         "@sipNo", item.SiparisNo,
                                                                         "@sipSatir", item.SiparisSatir,
                                                                         yil);

                    if (!result) return false;
                }

                return true;
            }
            catch { return false; }
        }
    }
}
