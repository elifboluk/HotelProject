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
    public partial class FrmPersonelListesi : Form
    {
        public FrmPersonelListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmPersonelListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblPersonel select new
            {
                x.PersonelID,
                x.AdSoyad,
                x.TC,
                x.Telefon,
                x.Mail,
                x.TblDepartman.DepartmanAd,
                x.TblGorev.GorevAd,
                x.TblDurum.DurumAd // Personel izinli olabilir.

            }).ToList();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Personel.FrmPersonelKarti fr = new FrmPersonelKarti();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("PersonelID").ToString());// (Odaklanılan satırı al=GetFocusedRow), (Hücrenin değeri=CellValue) Odaklanılan satırdaki hücrenin değerini al. Çift tırnak içerisinde değeri alınacak olan hücreyi yazarız. (ToString=string formatında al)
            fr.Show();
        }
    }
}
