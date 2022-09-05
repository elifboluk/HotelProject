using DevExpress.XtraEditors;
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
                                                        Id=x.id,
                                                        Şehir=x.sehir
                                                    }).ToList();
        }

        private void lookUpEditUlke_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEditSehir_EditValueChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen = int.Parse(lookUpEditSehir.EditValue.ToString());
            lookUpEditilce.Properties.DataSource=(from x in db.ilceler
                                                  select new
                                                  {
                                                     Id= x.id,
                                                     İlçe=x.ilce, 
                                                      Şehir = x.sehir
                                                  } ).Where(y=>y.Şehir==secilen).ToList();
        }
        string resim1, resim2;

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

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Repository<TblMisafir> repo = new Repository<TblMisafir>();
            TblMisafir t = new TblMisafir();
            t.AdSoyad = TxtAdSoyad.Text;
            t.TC = TxtTc.Text;
            t.Telefon = TxtTelefon.Text;
            t.Mail = TxtMail.Text;
            t.Adres = TxtAdres.Text;
            t.Aciklama = TxtAciklama.Text;
            t.Durum = 1;
            t.Sehir = lookUpEditSehir.Text;
            t.ilce = lookUpEditilce.Text;
            t.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
            repo.TAdd(t);
            t.KimlikFoto1 = resim1;
            t.KimlikFoto2 = resim2;
            XtraMessageBox.Show("Misafir sisteme başarılı bir şekilde kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
