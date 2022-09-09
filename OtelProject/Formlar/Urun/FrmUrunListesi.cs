﻿using OtelProject.Entity;
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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblUrun
                                       select new
                                       {
                                           x.UrunID,
                                           x.TblUrunGrup.UrunGrupAd,
                                           x.UrunAd, 
                                           x.Fiyat,
                                           x.Birim,
                                           x.Toplam
                                       }).ToList();

        }
    }
}
