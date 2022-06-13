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

        public int id; // Erişim sağlamak için public olarak tanımladık.
        Repository<TblPersonel> repo = new Repository<TblPersonel>();
        private void FrmPersonelKarti_Load(object sender, EventArgs e)
        {
            this.Text = id.ToString(); // Formun sol üst köşesine id'yi yazdırsın. Id'nin değeri FrmPersonelListesi.cs'ten çekilerek gelecek.

            lookUpEditDepartman.Properties.DataSource = (from x in db.TblDepartman
                                                         select new
                                                         {
                                                             x.DepartmanID,
                                                             x.DepartmanAd
                                                         }).ToList();

            lookUpEditGorev.Properties.DataSource = (from x in db.TblGorev
                                                     select new
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

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.PersonelID == id); // x öyle ki => repo nesnesinin bağlı bulunduğu T entity'sine göre bu T entity'e ait property'ler gelecek. TblPersonel'de çalıştığımız için TblPersonel'deki verileri getirecek.(PersonelID = dışarıdan gönderdiğimiz id'ye.)
            deger.AdSoyad = TxtAdSoyad.Text;
            deger.TC = TxtTc.Text;
            deger.Adres = TxtAdres.Text;
            //deger.Telefon = TxtTelefon.Text;
            //deger.IseGirisTarih = DateTime.Parse(dateEditGiris.Text);
            //deger.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
            //deger.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
            //deger.Aciklama = TxtAciklama.Text;
            //deger.Mail = TxtMail.Text;
            //deger.KimlikOn = PictureEditKimlikOn.GetLoadedImageLocation();
            //deger.KimlikArka = PictureEditKimlikArka.GetLoadedImageLocation();
            repo.TUpdate(deger);
            XtraMessageBox.Show("Personel kartı bilgileri başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
