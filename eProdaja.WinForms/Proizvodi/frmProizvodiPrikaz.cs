using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdaja.WinForms.Proizvodi
{
    public partial class frmProizvodiPrikaz : Form
    {
        private readonly APIService _jediniceMjere = new APIService("JediniceMjere");
        private readonly APIService _vrsteProizvoda = new APIService("VrsteProizvoda");
        private readonly APIService _proizvodi = new APIService("Proizvod");
        public frmProizvodiPrikaz()
        {
            InitializeComponent();
        }

        private async void frmProizvodiPrikaz_Load(object sender, EventArgs e)
        {
            await LoadProizvodi();
            await LoadJedinicaMjere();
            await LoadVrsteProizvoda();
        }

        private async Task LoadProizvodi(int vrstaId=0)
        {
            ProizvodiSearchObject search = new ProizvodiSearchObject();
            search.IncludeList = new string[]
            {
                "JedinicaMjere",
                "Vrsta"
            };

            if (vrstaId == 0)
            {
                search.VrstaId = vrstaId;
            }

            dgvKorisnici.DataSource = await _proizvodi.Get<List<Model.Proizvodi>>(search);
        }

        private async Task LoadJedinicaMjere()
        {
            var result = await _jediniceMjere.Get<List<Model.JedinicaMjere>>();

            result.Insert(0, new Model.JedinicaMjere());
            cmbJedinicaMjere.DataSource = result;

            cmbJedinicaMjere.DisplayMember = "Naziv";
            cmbJedinicaMjere.ValueMember = "JedinicaMjereId";
        }

        private async Task LoadVrsteProizvoda()
        {
            var result = await _vrsteProizvoda.Get<List<Model.VrsteProizvodum>>();

            result.Insert(0, new Model.VrsteProizvodum());
            cmbVrstaProizvoda.DataSource = result;

            cmbVrstaProizvoda.DisplayMember = "Naziv";
            cmbVrstaProizvoda.ValueMember = "VrstaId";
        }

        private async void cmbVrstaProizvoda_SelectedIndexChanged(object sender, EventArgs e)
        {
            var IdObj = cmbVrstaProizvoda.SelectedValue;

            if(int.TryParse(IdObj.ToString(), out int id))
            {
                await LoadProizvodi(id);
            }
        }

        private void btnPhotoPicker_Click(object sender, EventArgs e)
        {
            var result = ofdSlika.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filename = ofdSlika.FileName;//Path do slike
                var file = File.ReadAllBytes(filename);//byte[] fajla

                txtSlika.Text = filename;
                pbProizvod.Image = Image.FromFile(filename);
            }
        }
    }
}
