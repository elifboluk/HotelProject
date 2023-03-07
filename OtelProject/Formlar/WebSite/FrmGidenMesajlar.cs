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

namespace OtelProject.Formlar.WebSite
{
    public partial class FrmGidenMesajlar : Form
    {
        public FrmGidenMesajlar()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmGidenMesajlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblMesaj2
                                       select new
                                       {
                                           x.MesajID,
                                           x.Alici,
                                           x.Konu,
                                           x.Tarih,
                                           x.Gonderen
                                       }).Where(x => x.Gonderen == "Admin").ToList();

        }
    }
}
