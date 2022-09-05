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
    public partial class FrmMisafirListesi : Form
    {
        public FrmMisafirListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmMisafirListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource=(from x in db.TblMisafir
                                     select new
                                     {
                                         x.AdSoyad,
                                         x.TC,
                                         x.Telefon,
                                         x.Mail,
                                         x.Sehir,
                                         x.ilce
                                     } ).ToList();

        }
    }
}
