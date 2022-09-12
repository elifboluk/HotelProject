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

namespace OtelProject.Formlar.Urun
{
    public partial class FrmUrunKarti : Form
    {
        public FrmUrunKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmUrunKarti_Load(object sender, EventArgs e)
        {
            // Ürün Grup Listesi
            lookUpEditUrunGrup.Properties.DataSource = (from x in db.TblUrunGrup
                                                    select new
                                                    {
                                                        x.UrunGrupID,
                                                        x.UrunGrupAd
                                                    }).ToList();

            // Birim Listesi
            lookUpEditBirim.Properties.DataSource = (from x in db.TblBirim
                                                    select new
                                                    {
                                                        x.BirimID,
                                                        x.BirimAd
                                                    }).ToList();

        }
    }
}
