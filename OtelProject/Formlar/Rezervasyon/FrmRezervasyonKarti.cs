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

namespace OtelProject.Formlar.Rezervasyon
{
    public partial class FrmRezervasyonKarti : Form
    {
        public FrmRezervasyonKarti()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();
        Repository<TblRezervasyon> repo = new Repository<TblRezervasyon>(); // Rezervasyon tablosundan bir nesne türettik.
        TblRezervasyon t = new TblRezervasyon();
        public int id;

        private void FrmRezervasyonKarti_Load(object sender, EventArgs e)
        {

            // Misafir Listesi
            lookUpEditMisafir.Properties.DataSource = (from x in db.TblMisafir
                                                       select new
                                                       {
                                                           x.MisafirID,
                                                           x.AdSoyad
                                                       }).ToList();

            // Misafir Listesi 2
            lookUpEditKisi1.Properties.DataSource = (from x in db.TblMisafir
                                                     select new
                                                     {
                                                         x.MisafirID,
                                                         x.AdSoyad
                                                     }).ToList();

            // Misafir Listesi 3
            lookUpEditKisi2.Properties.DataSource = (from x in db.TblMisafir
                                                     select new
                                                     {
                                                         x.MisafirID,
                                                         x.AdSoyad
                                                     }).ToList();

            // Misafir Listesi 4
            lookUpEditKisi3.Properties.DataSource = (from x in db.TblMisafir
                                                     select new
                                                     {
                                                         x.MisafirID,
                                                         x.AdSoyad
                                                     }).ToList();




            // Oda Listesi
            lookUpEditOda.Properties.DataSource = (from x in db.TblOda
                                                   select new
                                                   {
                                                       x.OdaID,
                                                       x.OdaNo,
                                                       x.TblDurum.DurumAd
                                                   }).Where(y => y.DurumAd == "Aktif").ToList();


            // Durum Listesi
            lookUpEditDurum.Properties.DataSource = (from x in db.TblDurum
                                                     select new
                                                     {
                                                         x.DurumID,
                                                         x.DurumAd
                                                     }).ToList();

            // Ürün Güncelleme Alanı
            if (id != 0)
            {
                var rezervasyon = repo.Find(x => x.RezervasyonID == id);
                lookUpEditMisafir.EditValue = rezervasyon.Misafir;
                dateEditGiris.Text = rezervasyon.GirisTarih.ToString();
                dateEditCikis.Text = rezervasyon.CikisTarih.ToString();
                numericUpDown1.Value = decimal.Parse(rezervasyon.Kisi.ToString());
                lookUpEditOda.EditValue = rezervasyon.Oda;
                TxtTelefon.Text = rezervasyon.Telefon;
                lookUpEditDurum.EditValue = rezervasyon.Durum;
                TxtAciklama.Text = rezervasyon.Aciklama;
                lookUpEditKisi1.EditValue = rezervasyon.Kisi1;
                lookUpEditKisi2.EditValue = rezervasyon.Kisi2;
                lookUpEditKisi3.EditValue = rezervasyon.Kisi3;
            }

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblRezervasyon t = new TblRezervasyon();
            if (numericUpDown1.Value == 1)
            {
                t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
            }

            if (numericUpDown1.Value == 2)
            {
                t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                t.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
            }

            if (numericUpDown1.Value == 3)
            {
                t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                t.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
                t.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
            }
            if (numericUpDown1.Value == 4)
            {
                t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                t.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
                t.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                t.Kisi3 = int.Parse(lookUpEditKisi3.EditValue.ToString());
            }
            t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
            t.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
            t.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
            t.Kisi3 = int.Parse(lookUpEditKisi3.EditValue.ToString());
            t.GirisTarih = DateTime.Parse(dateEditGiris.Text);
            t.CikisTarih = DateTime.Parse(dateEditCikis.Text);
            t.Kisi = numericUpDown1.Value.ToString();
            t.Oda = int.Parse(lookUpEditOda.EditValue.ToString());
            // t.RezervasyonAdSoyad = TxtRezervasyonAdSoyad.Text;
            t.Telefon = TxtTelefon.Text;
            t.Aciklama = TxtAciklama.Text;
            t.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            repo.TAdd(t);
            XtraMessageBox.Show("Rezervasyon başarılı bir şekilde oluşturuldu.");
        }

        private void lookUpEditMisafir_EditValueChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen = int.Parse(lookUpEditMisafir.EditValue.ToString());
            var telefon = db.TblMisafir.Where(x => x.MisafirID == secilen).Select(y => y.Telefon).FirstOrDefault();
            TxtTelefon.Text = telefon.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var rezervasyon = repo.Find(x => x.RezervasyonID == id);
            rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
            rezervasyon.GirisTarih = DateTime.Parse(dateEditGiris.Text);
            rezervasyon.CikisTarih = DateTime.Parse(dateEditCikis.Text);
            rezervasyon.Kisi = numericUpDown1.Value.ToString();
            rezervasyon.Oda = int.Parse(lookUpEditOda.EditValue.ToString());
            rezervasyon.Telefon = TxtTelefon.Text;
            rezervasyon.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            if (numericUpDown1.Value == 1)
            {
                rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
            }

            if (numericUpDown1.Value == 2)
            {
                rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                rezervasyon.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
            }

            if (numericUpDown1.Value == 3)
            {
                rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                rezervasyon.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
                rezervasyon.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
            }

            if (numericUpDown1.Value == 4)
            {
                rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                rezervasyon.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
                rezervasyon.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                rezervasyon.Kisi3 = int.Parse(lookUpEditKisi3.EditValue.ToString());
            }

            
            rezervasyon.Aciklama = TxtAciklama.Text;

            repo.TUpdate(rezervasyon);
            XtraMessageBox.Show("Rezervasyon başarılı bir şekilde güncellendi.");
        }
    }
}
