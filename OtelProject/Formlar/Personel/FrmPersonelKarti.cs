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

namespace OtelProject.Formlar.Personel
{
    public partial class FrmPersonelKarti : Form
    {
        public FrmPersonelKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

      
        private void FrmPersonelKarti_Load(object sender, EventArgs e)
        {
            lookUpEditDepartman.Properties.DataSource = (from x in db.TblDepartman select new
            {
                x.DepartmanID,
                x.DepartmanAd
            }).ToList();

            lookUpEditGorev.Properties.DataSource = (from x in db.TblGorev select new
            {
                x.GorevID,
                x.GorevAd
            }).ToList();

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            TxtAciklama.Text = PictureEditKimlikOn.GetLoadedImageLocation();
        }
            
        private void BtnKaydet_Click(object sender, EventArgs e) // Kaydetme işlemi için önce Repository'mizi çağırmalıyız.↓
            //<TblPersonel> Elmas içerisinde bir T değeri göndermemiz gerekiyor. Buradan bir nesne türetiyoruz (ismi repo olsun)
        {
            Repository<TblPersonel> repo = new Repository<TblPersonel>();
            TblPersonel t = new TblPersonel(); // Personel sınıfından da bir t nesnesi türetiyoruz, ikinci türetmiş olduğumuz nesne; personel tablomuz içerisinde yer alan kaydetmek istediğim sütunlara erişmemi sağlayacak.↓
            t.AdSoyad = TxtAdSoyad.Text;
            t.TC = TxtTc.Text;
            t.Adres = TxtAdres.Text;
            t.Telefon = TxtTelefon.Text;
            t.IseGirisTarih = DateTime.Parse(dateEditGiris.Text);
            t.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
            t.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
            t.Aciklama = TxtAciklama.Text;
            t.Mail = TxtMail.Text;
            t.KimlikOn = PictureEditKimlikOn.GetLoadedImageLocation();
            t.KimlikArka = PictureEditKimlikArka.GetLoadedImageLocation();
            //t.Sifre = TxtSifre.Text;
            t.Durum = 1; // 1 aktif anlamına gelir.
            repo.TAdd(t);
            XtraMessageBox.Show("Personel başarılı bir şekilde sisteme kaydedildi.");


        }
    }
}
