﻿using DevExpress.XtraEditors;
using OtelProject.Entity;
using OtelProject.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelProject.Formlar.Misafir
{
    public partial class FrmMisafirKarti : Form
    {
        public FrmMisafirKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        Repository<TblMisafir> repo = new Repository<TblMisafir>();
        TblMisafir t = new TblMisafir();
        public int id;
        string resim1, resim2;
        private void FrmMisafirKarti_Load(object sender, EventArgs e)
        {
            // Ülke Listesi
            lookUpEditUlke.Properties.DataSource = (from x in db.TblUlke
                                                    select new
                                                    {
                                                        x.UlkeID,
                                                        x.UlkeAd
                                                    }).ToList();

            // Şehir Listesi
            lookUpEditSehir.Properties.DataSource = (from x in db.iller
                                                     select new
                                                     {
                                                         Id = x.id,
                                                         Şehir = x.sehir
                                                     }).ToList();

            try
            {
                // Güncellenecek kart bilgileri
                if (id != 0) //Form yüklendiğinde id sıfır değilse aşağıdaki işlemleri yap.
                {
                    var misafir = repo.Find(x => x.MisafirID == id);
                    TxtAdSoyad.Text = misafir.AdSoyad;
                    TxtTc.Text = misafir.TC;
                    TxtAdres.Text = misafir.Adres;
                    TxtTelefon.Text = misafir.Telefon;
                    TxtMail.Text = misafir.Mail;
                    TxtAciklama.Text = misafir.Aciklama;
                    lookUpEditSehir.EditValue = misafir.sehir; // Misafir kartına şehir bilgisi geldi.
                    lookUpEditUlke.EditValue = misafir.Ulke; // Misafir kartına ülke bilgisi geldi.
                    lookUpEditilce.EditValue = misafir.ilce; // Misafir kartına ilçe bilgisi geldi.                    
                    PictureEditKimlikOn.Image = Image.FromFile(misafir.KimlikFoto1); // Kimliğin ön kısmındaki fotoğrafı aldık.
                    PictureEditKimlikArka.Image = Image.FromFile(misafir.KimlikFoto2); // Kimliğin arka kısmındaki fotoğrafı aldık.
                    resim1 = misafir.KimlikFoto1; // Kod hiyerarşisi önemli!!!
                    resim2 = misafir.KimlikFoto2; // Kod hiyerarşisi önemli!!!
                }                
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Bir hata oluştu lütfen sütunları kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void lookUpEditUlke_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEditSehir_EditValueChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen = int.Parse(lookUpEditSehir.EditValue.ToString());
            lookUpEditilce.Properties.DataSource = (from x in db.ilceler
                                                    select new
                                                    {
                                                        Id = x.id,
                                                        İlçe = x.ilce,
                                                        Şehir = x.sehir
                                                    }).Where(y => y.Şehir == secilen).ToList();
        }


        private void PictureEditKimlikOn_EditValueChanged(object sender, EventArgs e)
        {
            resim1 = PictureEditKimlikOn.GetLoadedImageLocation().ToString();
        }

        private void PictureEditKimlikArka_EditValueChanged(object sender, EventArgs e)
        {
            resim2 = PictureEditKimlikArka.GetLoadedImageLocation().ToString();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.MisafirID == id); // x öyle ki => repo nesnesinin bağlı bulunduğu T entity'sine göre bu T entity'e ait property'ler gelecek. TblMisafir'de çalıştığımız için TblMisafir'deki verileri getirecek.(MisafirID = dışarıdan gönderdiğimiz id'ye.)
            deger.AdSoyad = TxtAdSoyad.Text;
            deger.TC = TxtTc.Text;
            deger.Mail = TxtMail.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.Adres = TxtAdres.Text;
            deger.Aciklama = TxtAciklama.Text;
            deger.KimlikFoto1 = resim1;
            deger.KimlikFoto2 = resim2;
            deger.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
            deger.sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
            deger.ilce = int.Parse(lookUpEditilce.EditValue.ToString());
            deger.Durum = 1;
            repo.TUpdate(deger);
            XtraMessageBox.Show("Misafir kartı bilgileri başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (PictureEditKimlikArka.Image!=null && PictureEditKimlikOn.Image != null)
            {
                t.AdSoyad = TxtAdSoyad.Text;
                t.TC = TxtTc.Text;
                t.Telefon = TxtTelefon.Text;
                t.Mail = TxtMail.Text;
                t.Adres = TxtAdres.Text;
                t.Aciklama = TxtAciklama.Text;
                t.Durum = 1;
                t.sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
                t.ilce = int.Parse(lookUpEditilce.EditValue.ToString());
                t.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
                t.KimlikFoto1 = resim1;
                t.KimlikFoto2 = resim2;
                repo.TAdd(t);
                XtraMessageBox.Show("Misafir sisteme başarılı bir şekilde kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Lütfen bilgileri eksiksiz doldurun.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }
    }
}
