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
    }
}
