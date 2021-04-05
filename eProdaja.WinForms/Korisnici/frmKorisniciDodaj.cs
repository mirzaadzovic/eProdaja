using eProdaja.Model;
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
    public partial class frmKorisniciDodaj : Form
    {
        private APIService _korisnici = new APIService("Korisnici");
        private APIService _uloge = new APIService("Uloge");
        private Model.Korisnici korisnik = null;

        public object KorisniciUpsert { get; private set; }

        public frmKorisniciDodaj(Model.Korisnici korisnik=null)
        {
            InitializeComponent();
            this.korisnik = korisnik;

        }

        private async void frmKorisniciDodaj_Load(object sender, EventArgs e)
        {
            await LoadUloge();
            if (korisnik != null)
            {
                txtIme.Text = korisnik.Ime;
                txtPrezime.Text = korisnik.Prezime;
                txtKorisnickoIme.Text = korisnik.KorisnickoIme;
                txtEmail.Text = korisnik.Email;
                cbStatus.Checked = korisnik.Status.GetValueOrDefault(false);
            }
        }
        private async Task LoadUloge()
        {
            var uloge = await _uloge.Get<List<Model.Uloge>>();
            clbUloge.DataSource = uloge;
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            if (korisnik == null)
            {
                if(txtLozinka.Text.Equals(txtPotvrdaLozinke.Text))
                {
                    var UlogeList = clbUloge.CheckedItems.Cast<Uloge>();
                    var UlogeIdList = UlogeList.Select(u => u.UlogaId).ToList();
                    KorisniciInsertRequest korisnikInsert = new KorisniciInsertRequest()
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        KorisnickoIme = txtKorisnickoIme.Text,
                        Email = txtEmail.Text,
                        Password = txtLozinka.Text,
                        PasswordPotvrda = txtPotvrdaLozinke.Text,
                        Status = cbStatus.Checked,
                        Uloge = UlogeIdList
                    };

                    await _korisnici.Insert<KorisniciInsertRequest>(korisnikInsert);

                    MessageBox.Show($"Dodan korisnik {korisnikInsert.Ime} {korisnikInsert.Prezime}!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Potvrda lozinke se razlikuje od lozinke!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                KorisniciUpdateRequest korisnikUpdate = new KorisniciUpdateRequest()
                {
                    Ime = txtIme.Text,
                    Prezime=txtPrezime.Text,
                    Status=cbStatus.Checked
                };

                await _korisnici.Update<KorisniciUpdateRequest>(korisnik.KorisnikId, korisnikUpdate);
                
                MessageBox.Show("Promjene sačuvane!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
