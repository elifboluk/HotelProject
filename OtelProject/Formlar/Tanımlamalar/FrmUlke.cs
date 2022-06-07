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
    public partial class FrmUlke : Form
    {
        public FrmUlke()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities(); // Entity'zi çağırdım. DbOtelEntities isimli sınıftan db isimli bir nesne türettik. Türettiğimiz bu nesne aracılığıyla gridControl'e atamalarımızı yapacağız.

        private void FrmUlke_Load(object sender, EventArgs e)
        {
            db.TblUlke.Load(); // Load metoduyla bize TblUlke değerleri yükleyecek.
            bindingSource1.DataSource = db.TblUlke.Local; // Binding Source'un veri kaynağı = db.TblUlke.Local (Local komutu ile birim tablosuna verileri göndereceğiz.) (ToList yerine load ve local komutları kullandık. Peki neleri listeleyecek? -Run designer kısmına gönderdiğimiz sütunları [Durum ID ve Durum Adı] listeleyecek.)
            
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent(); // Üzerinde aktif olarak çalıştığım alanı kaldır.
            db.SaveChanges(); // Ve değişiklikleri veritabanına kaydet.
        }
    

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Üzerinde çalıştığım formu kapat.
        }
    }
}
