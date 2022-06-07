﻿using DevExpress.XtraEditors;
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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            db.TblDepartman.Load(); // Load metoduyla bize TblBirimdeki değerleri yükleyecek.
            bindingSource1.DataSource = db.TblDepartman.Local; // Binding Source'un veri kaynağı = db.TblBirim.Local (Local komutu ile birim tablosuna verileri göndereceğiz.) (ToList yerine load ve local komutları kullandık. Peki neleri listeleyecek? -Run designer kısmına gönderdiğimiz sütunları [Durum ID ve Durum Adı] listeleyecek.)
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
