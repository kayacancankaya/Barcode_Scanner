using System;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace VbElTerminali.Classes
{
    class Cls_Login
    {


        public string User { get; set; }

        public int UserID { get; set; }
        
        public int PortalID { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string Departman { get; set; }

        
       
        string hashedPass = string.Empty;

        private string query = string.Empty;

        DataLayer dataLayer = new DataLayer();
        
        SqlDataReader reader;

        List<Cls_Login> kullaniciListesi = new List<Cls_Login>();
        List<Cls_Login> readerCollection = new List<Cls_Login>();

        private string hashedAddr = string.Empty;
        
        public int CheckLoginAttemp(string username,string passwordentry, string yil)
        {
            try
            { 
            query = "select count(*) as miktar from vbtUserInfo where sifre='" + passwordentry + "' and KullaniciAdi='" + username + "' and Departman='Sevkiyat'";
            int NumberOfRecords = 0;
            
            reader = dataLayer.Select_Command_Data_Reader(query, yil);

            while (reader.Read())
            {
                NumberOfRecords = Convert.ToInt32(reader["miktar"]);
                
            }
            reader.Close();
            return NumberOfRecords;
            }
            catch {return 3; }
        }


        public List<Cls_Login> GetUserName(string yil)
        {
            
            try
            {
                kullaniciListesi.Clear();
                
                query = string.Format("select kullaniciAdi from vbtUserInfo where Departman='Sevkiyat'");

                reader = dataLayer.Select_Command_Data_Reader(query,yil);

                while (reader.Read())
                {
                    Cls_Login readerCollection = new Cls_Login
                    {
                        User = reader[0].ToString(),
                    };
                    kullaniciListesi.Add(readerCollection);
                }
                
            }
            catch { return null; }
            return kullaniciListesi;
        }

        public int GetUserId(string userName, string yil)
        {

            try
            {
                query = string.Format("select top 1 UserId from vbtUserInfo where KullaniciAdi='{0}'", userName);

                reader = dataLayer.Select_Command_Data_Reader(query, yil);
                while (reader.Read())
                {
                    UserID = Convert.ToInt32(reader[0]);
                    UserID = ConvertUserIDtoPortalID(UserID);
                }
                reader.Close();
            }
            catch { return 0; }
            return UserID;
        }

        public int ConvertUserIDtoPortalID(int userID)
        {
            try
            {

                switch(userID)
                { 
                    case (1):
                    PortalID = 71;
                    break;
                    
                    case (2):
                    PortalID = 3;
                    break;
                    
                    case (3):
                    PortalID = 94;
                    break;
                    
                    case (4):
                    PortalID = 96;
                    break;
                    
                    case (5):
                    PortalID = 82;
                    break;

                    case (6):
                    PortalID = 81;
                    break;

                    case (7):
                    PortalID = 100;
                    break;

                    case (8):
                    PortalID = 9;
                    break;

                    case (9):
                    PortalID = 79;
                    break;
                    case (10):
                    PortalID = 84;
                    break;
            }

                return PortalID;
            }
            catch {return 0; }
            
        }

    }
}
