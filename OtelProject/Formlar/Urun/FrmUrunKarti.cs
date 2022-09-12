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
    public partial class FrmUrunKarti : Form
    {
        public FrmUrunKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmUrunKarti_Load(object sender, EventArgs e)
        {
            // Ürün Grup Listesi
            lookUpEditUrunGrup.Properties.DataSource = (from x in db.TblUrunGrup
                                                    select new
                                                    {
                                                        x.UrunGrupID,
                                                        x.UrunGrupAd
                                                    }).ToList();

            // Birim Listesi
            lookUpEditBirim.Properties.DataSource = (from x in db.TblBirim
                                                    select new
                                                    {
                                                        x.BirimID,
                                                        x.BirimAd
                                                    }).ToList();

            // Durum Listesi
            lookUpEditDurum.Properties.DataSource = (from x in db.TblDurum
                                                    select new
                                                    {
                                                        x.DurumID,
                                                        x.DurumAd
                                                    }).ToList();

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close(); // Üzerinde çalıştığın formu kapat.

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Repository<TblUrun> repo = new Repository<TblUrun>(); // Ürün tablosundan bir nesne türettik.
            TblUrun t = new TblUrun();
            t.UrunAd = TxtUrunAdi.Text;
            t.UrunGrup = int.Parse(lookUpEditUrunGrup.EditValue.ToString());
            t.Birim = int.Parse(lookUpEditBirim.EditValue.ToString());
            t.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            t.Fiyat = decimal.Parse(TxtFiyat.Text);            
            t.Toplam = decimal.Parse(TxtToplam.Text);
            t.Kdv = byte.Parse(TxtKdv.Text);
            repo.TAdd(t);
            XtraMessageBox.Show("Ürün başarılı bir şekilde veri tabanına kaydedildi.");




        }

        
    }
}
