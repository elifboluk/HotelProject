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
    public partial class FrmUrunGirisHareketleri : Form
    {
        public FrmUrunGirisHareketleri()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmUrunGirisHareketleri_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblUrunHareket
                                       select new
                                       {
                                           x.Hareketid,
                                           x.TblUrun.UrunAd,
                                           x.Miktar,
                                           x.Tarih,
                                           x.HareketTuru

                                       }).Where(y => y.HareketTuru == "Giriş").ToList();
        }
    }
}
