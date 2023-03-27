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

namespace OtelProject.Formlar.AnaForm
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            // Misafir Listesi
            gridControl3.DataSource = (from x in db.TblMisafir
                                       select new
                                       {
                                           x.AdSoyad                                           
                                       }).ToList();

            // Mesaj Listesi
            gridControl4.DataSource = (from x in db.TblMesaj
                                       select new
                                       {
                                           x.Gonderen,
                                           x.Konu
                                       }).ToList();

            // Bugün Gelecek Misafirler Listesi
            gridControl2.DataSource = (from x in db.TblRezervasyon
                                       select new
                                       {
                                           x.TblMisafir.AdSoyad,
                                           x.Durum
                                       }).Where(y=>y.Durum==3007).ToList();

        }
    }
}