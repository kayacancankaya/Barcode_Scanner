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
    public partial class Frm_Login : Form
    {
        List<Cls_Login> kullaniciListesi = new List<Cls_Login>();
        Cls_Login login = new Cls_Login();
        string yil = string.Empty;
        string paketKisit = string.Empty;
        List<Cls_Sevk> paketListe = new List<Cls_Sevk>();

        public Frm_Login()
        {
            InitializeComponent();

            yil = "2023";

            txt_yil.Text= yil; 

        }

        int returnedColumnNumber = 0;
        private void btn_giris_clicked(object sender, EventArgs e)
        {
            yil = txt_yil.Text.ToString().Trim();
            returnedColumnNumber = login.CheckLoginAttemp(lbl_kullanici.Text.Trim(),txt_password.Text.Trim(),yil);

            if (returnedColumnNumber == 0) { MessageBox.Show("Giriş Başarısız. Hatalı Şifre veya Yanlış Kullanıcı."); return; }
            if (returnedColumnNumber == 3) { 
                MessageBox.Show("Veri Tabanına Bağlanırken Hata İle Karşılaşıldı.");return; }
            if (returnedColumnNumber > 0) 
            {
                login.UserID = login.GetUserId(lbl_kullanici.Text.Trim(), yil);

                if (login.UserID == 0) { MessageBox.Show("Kullanıcı ID'si Alınamadı."); return; }

                Frm_Cari_Secim frm = new Frm_Cari_Secim(login.UserID,yil,paketKisit,paketListe);
                
                frm.Show();
                this.Hide();
            }
        }

        private void btn_closed_clicked(object sender, EventArgs e)
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