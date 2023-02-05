﻿using DevExpress.XtraEditors;
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
            lookUpEditKisi2.Properties.DataSource = (from x in db.TblMisafir
                                                       select new
                                                       {
                                                           x.MisafirID,
                                                           x.AdSoyad
                                                       }).ToList();

            // Misafir Listesi 3
            lookUpEditKisi3.Properties.DataSource = (from x in db.TblMisafir
                                                       select new
                                                       {
                                                           x.MisafirID,
                                                           x.AdSoyad
                                                       }).ToList();

            // Misafir Listesi 4
            lookUpEditKisi4.Properties.DataSource = (from x in db.TblMisafir
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
                                                        }).Where(y=>y.DurumAd=="Aktif").ToList();


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
                t.Kisi1 = int.Parse(lookUpEditKisi2.EditValue.ToString());
            }

            if (numericUpDown1.Value == 3)
            {
                t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                t.Kisi1 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                t.Kisi2 = int.Parse(lookUpEditKisi3.EditValue.ToString());
            }
            if (numericUpDown1.Value == 4)
            {
                t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                t.Kisi1 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                t.Kisi2 = int.Parse(lookUpEditKisi3.EditValue.ToString());
                t.Kisi3 = int.Parse(lookUpEditKisi4.EditValue.ToString());
            }
            t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
            t.Kisi1 = int.Parse(lookUpEditKisi2.EditValue.ToString());
            t.Kisi2 = int.Parse(lookUpEditKisi3.EditValue.ToString());
            t.Kisi3 = int.Parse(lookUpEditKisi4.EditValue.ToString());
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
    }
}
