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

namespace OtelProject.Formlar.Urun
{
    public partial class FrmUrunHareketTanimi : Form
    {
        public FrmUrunHareketTanimi()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();
        Repository<TblUrun> repo = new Repository<TblUrun>(); // Ürün tablosundan bir nesne türettik.
        TblUrun t = new TblUrun();
        public int id;

        private void FrmUrunHareketTanimi_Load(object sender, EventArgs e)
        {
            // Ürün Grup Listesi
            lookUpEditUrun.Properties.DataSource = (from x in db.TblUrun
                                                        select new
                                                        {
                                                            x.UrunID,
                                                            x.UrunAd
                                                        }).ToList();


        }
    }
}
