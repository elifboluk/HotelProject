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

namespace OtelProject.Formlar.WebSite
{
    public partial class FrmHakkimizda : Form
    {
        public FrmHakkimizda()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        Repository<TblHakkimda> repo = new Repository<TblHakkimda>();

        private void FrmHakkimizda_Load(object sender, EventArgs e)
        {
            var hakkimda = repo.Find(x => x.ID == 1);

            TxtAciklama1.Text = hakkimda.Hakkimda1;
            TxtAciklama2.Text = hakkimda.Hakkimda2;
            TxtAciklama3.Text = hakkimda.Hakkimda3;
            TxtAciklama4.Text = hakkimda.Hakkimda4;
            

        }
    }
}
