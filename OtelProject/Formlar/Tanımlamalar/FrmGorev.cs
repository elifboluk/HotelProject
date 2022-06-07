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
    public partial class FrmGorev : Form
    {
        public FrmGorev()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmGorev_Load(object sender, EventArgs e)
        {
            db.TblGorev.Load(); // Load metoduyla bize TblGorev'deki değerleri yükleyecek.
            bindingSource1.DataSource = db.TblGorev.Local; // Binding Source'un veri kaynağı = db.TblGorev.Local (Local komutu ile birim tablosuna verileri göndereceğiz.) (ToList yerine load ve local komutları kullandık. Peki neleri listeleyecek? -Run designer kısmına gönderdiğimiz sütunları [DepartmanID, DepartmanAd ve Durum ID, Durum Ad] listeleyecek.)
            repositoryItemLookUpEditDepartman.DataSource = (from x in db.TblDepartman
                                                        select new
                                                        {
                                                            x.DepartmanID,
                                                            x.DepartmanAd
                                                        }).ToList(); // DepartmanID ve DepartmanAd'ı getir, listele, repositoryItemLookUpEditDepartman'ın veri kaynağına atamasını yap.

            repositoryItemLookUpEditDurum.DataSource = (from x in db.TblDurum
                                                        select new
                                                        {
                                                            x.DurumID,
                                                            x.DurumAd
                                                        }).ToList(); // DurumID ve DurumAd'ı getir, listele, repositoryItemLookUpEditDurum'un veri kaynağına atamasını yap.

        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                db.SaveChanges();

            }
            catch (Exception)
            {

                XtraMessageBox.Show("Bilgiler kaydedilirken hata oluştu, kontrol edip tekrar deneyiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Message Box'ın ilk parametresi hata mesajıdır, ikinci parametresi başlıktır, üçüncü parametresi butondur, dördüncü parametresi ise ikondur.);

            }
        }
    }
}
