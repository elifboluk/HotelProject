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

namespace OtelProject.Formlar.Grafikler
{
    public partial class FrmGrafik1 : Form
    {
        public FrmGrafik1()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmGrafik1_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.OdaDurum(); // Stored Procedure
        }
    }
}
