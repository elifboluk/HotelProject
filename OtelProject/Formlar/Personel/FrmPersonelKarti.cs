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

namespace OtelProject.Formlar.Personel
{
    public partial class FrmPersonelKarti : Form
    {
        public FrmPersonelKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

      
        private void FrmPersonelKarti_Load(object sender, EventArgs e)
        {
            lookUpEditDepartman.Properties.DataSource = (from x in db.TblDepartman select new
            {
                x.DepartmanID,
                x.DepartmanAd
            }).ToList();

            lookUpEditGorev.Properties.DataSource = (from x in db.TblGorev select new
            {
                x.GorevID,
                x.GorevAd
            }).ToList();

        }
    }
}
