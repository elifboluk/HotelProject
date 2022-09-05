using OtelProject.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelProject.Formlar.Misafir
{
    public partial class FrmMisafirKarti : Form
    {
        public FrmMisafirKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmMisafirKarti_Load(object sender, EventArgs e)
        {
            // Ülke Listesi
            lookUpEditUlke.Properties.DataSource = (from x in db.TblUlke
                                                    select new
                                                    {
                                                        x.UlkeID,
                                                        x.UlkeAd
                                                    }).ToList();

            // Şehir Listesi
            lookUpEditSehir.Properties.DataSource = (from x in db.iller
                                                    select new
                                                    {
                                                        Id=x.id,
                                                        Şehir=x.sehir
                                                    }).ToList();
        }

        private void lookUpEditUlke_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
