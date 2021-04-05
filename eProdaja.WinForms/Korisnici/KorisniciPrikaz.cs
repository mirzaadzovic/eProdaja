using eProdaja.Model;
using Flurl.Http.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdaja.WinForms.Korisnici
{
    public partial class KorisniciPrikaz : Form
    {
        private APIService _korisnici = new APIService("Korisnici");
        private APIService _uloge = new APIService("Uloge"); 
        public KorisniciPrikaz()
        {
            InitializeComponent();
        }

        private async void btnPrikaz_Click(object sender, EventArgs e)
        {
            KorisniciSearchObject search = new KorisniciSearchObject()
            {
                Ime = txtIme.Text
            };
            dgvKorisnici.DataSource = await _korisnici.Get<List<Model.Korisnici>>(search);
        }


        private void dgvKorisnici_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvKorisnici.SelectedRows[0].DataBoundItem;

            frmKorisniciDodaj frm = new frmKorisniciDodaj(item as Model.Korisnici);
            frm.ShowDialog();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmKorisniciDodaj frm = new frmKorisniciDodaj();
            frm.ShowDialog();
        }
    }
}
