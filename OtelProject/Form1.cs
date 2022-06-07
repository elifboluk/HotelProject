using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmDurum fr = new Formlar.Tanımlamalar.FrmDurum { };
            fr.Show();
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmBirim fr = new Formlar.Tanımlamalar.FrmBirim(); // fr isimli nesne türetildi. Üstteki fr ile bu fr karışmaz çünkü herbiri kendi scope dediğimiz süslü parantezinin içindedir.
            fr.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnDepartmanTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmDepartman fr = new Formlar.Tanımlamalar.FrmDepartman(); // fr isimli nesne türetildi. Üstteki fr ile bu fr karışmaz çünkü herbiri kendi scope dediğimiz süslü parantezinin içindedir.
            fr.Show();
        }

        private void BtnGorevTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmGorev fr = new Formlar.Tanımlamalar.FrmGorev(); // fr isimli nesne türetildi. Üstteki fr ile bu fr karışmaz çünkü herbiri kendi scope dediğimiz süslü parantezinin içindedir.
            fr.Show();
        }

        private void BtnKasaTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmKasa fr = new Formlar.Tanımlamalar.FrmKasa(); // fr isimli nesne türetildi. Üstteki fr ile bu fr karışmaz çünkü herbiri kendi scope dediğimiz süslü parantezinin içindedir.
            fr.Show();

        }

        private void BtnKurTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmKur fr = new Formlar.Tanımlamalar.FrmKur(); // fr isimli nesne türetildi. Üstteki fr ile bu fr karışmaz çünkü herbiri kendi scope dediğimiz süslü parantezinin içindedir.
            fr.Show();

        }

        private void BtnOdaTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmOda fr = new Formlar.Tanımlamalar.FrmOda(); // fr isimli nesne türetildi. Üstteki fr ile bu fr karışmaz çünkü herbiri kendi scope dediğimiz süslü parantezinin içindedir.
            fr.Show();
        }

        private void BtnTelefonTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmTelefon fr = new Formlar.Tanımlamalar.FrmTelefon(); // fr isimli nesne türetildi. Üstteki fr ile bu fr karışmaz çünkü herbiri kendi scope dediğimiz süslü parantezinin içindedir.
            fr.Show();

        }

        private void BtnUlkeTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmUlke fr = new Formlar.Tanımlamalar.FrmUlke(); // fr isimli nesne türetildi. Üstteki fr ile bu fr karışmaz çünkü herbiri kendi scope dediğimiz süslü parantezinin içindedir.
            fr.Show();

        }

        private void barButtonItem2_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmUrunGrup fr = new Formlar.Tanımlamalar.FrmUrunGrup(); // fr isimli nesne türetildi. Üstteki fr ile bu fr karışmaz çünkü herbiri kendi scope dediğimiz süslü parantezinin içindedir.
            fr.Show();
        }
    }
}
