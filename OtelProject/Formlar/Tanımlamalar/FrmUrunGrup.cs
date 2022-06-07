using DevExpress.XtraEditors;
using OtelProject.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelProject.Formlar.Tanımlamalar
{
    public partial class FrmUrunGrup : Form
    {
        public FrmUrunGrup()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmUrunGrup_Load(object sender, EventArgs e)
        {
            db.TblUrunGrup.Load(); // Load metoduyla bize TblUrunGrup değerleri yükleyecek.
            bindingSource1.DataSource = db.TblUrunGrup.Local; // Binding Source'un veri kaynağı = db.TblUrunGrup.Local (Local komutu ile birim tablosuna verileri göndereceğiz.) (ToList yerine load ve local komutları kullandık. Peki neleri listeleyecek? -Run designer kısmına gönderdiğimiz sütunları [Durum ID ve Durum Adı] listeleyecek.)
            repositoryItemLookUpEditDurum.DataSource = (from x in db.TblDurum
                                                        select new
                                                        {
                                                            x.DurumID,
                                                            x.DurumAd
                                                        }).ToList(); // DurumID ve DurumAd'ı getir, listele, repositoryItemLookUpEditDurum'un veri kaynağına atamasını yap.


        }
        

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent(); // Üzerinde aktif olarak çalıştığım alanı kaldır.
            db.SaveChanges(); // Ve değişiklikleri veritabanına kaydet.
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Üzerinde çalıştığım formu kapat.
        }

        private void gridView1_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                db.SaveChanges(); // Yapılan değişiklikler veri tabanına yansır.
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Hatalı veri girişi, lütfen  tekrar deneyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Message Box'ın ilk parametresi hata mesajıdır, ikinci parametresi başlıktır, üçüncü parametresi butondur, dördüncü parametresi ise ikondur.
            }

        }
            // delete from tablename
            // DBCC CHECKIDENT('tablename', RESEED, 0)
    }
}
