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

namespace OtelProject.Formlar.Urun
{
    public partial class FrmUrunHareketTanimi : Form
    {
        public FrmUrunHareketTanimi()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();
        Repository<TblUrunHareket> repo = new Repository<TblUrunHareket>(); // Ürün tablosundan bir nesne türettik.
        TblUrunHareket t = new TblUrunHareket();
        public int id;

        private void FrmUrunHareketTanimi_Load(object sender, EventArgs e)
        {
            //id Değeri
            TxtID.Text = id.ToString();
            TxtID.Enabled = false;


            // Ürün Listesi
            lookUpEditUrun.Properties.DataSource = (from x in db.TblUrun
                                                        select new
                                                        {
                                                            x.UrunID,
                                                            x.UrunAd
                                                        }).ToList();

            // Verilerin Kart Alanlarına Doldurulması

            if (id != 0)
            {
                var urun = repo.Find(x => x.Hareketid == id);
                lookUpEditUrun.EditValue = urun.Urun; //urun değişken, Urun tablodaki kısım.
                TxtMiktar.Text = urun.Miktar.ToString();
                TxtAciklama.Text=urun.Aciklama;
                comboBox1.Text = urun.HareketTuru;
                dateEdit1.Text = urun.Tarih.ToString();
            }


        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            t.Urun = int.Parse(lookUpEditUrun.EditValue.ToString());
            t.Tarih = DateTime.Parse(dateEdit1.Text);
            t.HareketTuru = comboBox1.Text;
            t.Miktar = decimal.Parse(TxtMiktar.Text);
            t.Aciklama = TxtAciklama.Text;
            repo.TAdd(t);
            XtraMessageBox.Show("Ürün hareketi sisteme kaydedildi!");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var urun = repo.Find(x => x.Hareketid == id);
            urun.Urun = int.Parse(lookUpEditUrun.EditValue.ToString());
            urun.Tarih = DateTime.Parse(dateEdit1.Text);
            urun.HareketTuru = comboBox1.Text;
            urun.Miktar = decimal.Parse(TxtMiktar.Text);
            urun.Aciklama = TxtAciklama.Text;
            repo.TUpdate(urun);
            XtraMessageBox.Show("Ürün hareketi başarılı bir şekilde güncellendi!");

        }
    }
}
