﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtelProject.Entity; //Entity'i kullandım.


namespace OtelProject.Formlar.Tanımlamalar
{
    public partial class FrmDurum : DevExpress.XtraEditors.XtraForm
    {
        public FrmDurum()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities(); // Entity'zi çağırdım. DbOtelEntities isimli sınıftan db isimli bir nesne türettik. Türettiğimiz bu nesne aracılığıyla gridControl'e atamalarımızı yapacağız.

        private void FrmDurum_Load(object sender, EventArgs e)
        {
            db.TblDurum.Load(); // Load metoduyla bize TblDurumdaki değerleri yükleyecek.
            bindingSource1.DataSource = db.TblDurum.Local; // Binding Source'un veri kaynağı = db.TblDurum.Local (Local komutu ile durum tablosuna verileri göndereceğiz.) (ToList yerine load ve local komutları kullandık. Peki neleri listeleyecek? -Run designer kısmına gönderdiğimiz sütunları [Durum ID ve Durum Adı] listeleyecek.)
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db.SaveChanges(); // Yapılan değişiklikler veri tabanına yansır.
        }
    }
}
