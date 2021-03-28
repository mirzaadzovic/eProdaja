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
        private APIService _service = new APIService("Korisnici");
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
            dgvKorisnici.DataSource = await _service.Get<List<Model.Korisnici>>(search);
        }
    }
}
