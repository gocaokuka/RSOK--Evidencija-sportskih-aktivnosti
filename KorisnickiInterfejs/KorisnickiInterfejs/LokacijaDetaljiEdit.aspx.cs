using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data;
using PrezentacionaLogika;
using System.Configuration;

namespace KorisnickiInterfejs
{
    public partial class LokacijaDetaljiEdit : System.Web.UI.Page
    {

        // atributi
        private string pSifra = "";
        clsFormaLokacijaDetaljiEdit objFormaLokacijaDetaljiEdit;

        // nase metode
        private void IsprazniKontrole()
        {
            txbSifra.Text = "";
            txbNaziv.Text = "";

        }

        private void AktivirajKontrole()
        {
            txbSifra.Enabled = true;
            txbNaziv.Enabled = true;
        }

        private void DeaktivirajKontrole()
        {
            txbSifra.Enabled = false;
            txbNaziv.Enabled = false;
        }


        private void PrikaziPodatke(clsFormaLokacijaDetaljiEdit objFormaLokacijaDetaljiEdit)
        {
            // podacima stranice upravlja klasa prezentacione logike, zato se uzimaju iz nje za prikaz
            txbSifra.Text = objFormaLokacijaDetaljiEdit.SifraPreuzeteLokacije;
            txbNaziv.Text = objFormaLokacijaDetaljiEdit.NazivPreuzeteLokacije;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            objFormaLokacijaDetaljiEdit = new clsFormaLokacijaDetaljiEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            pSifra = Request.QueryString["Sifra"].ToString();
            objFormaLokacijaDetaljiEdit.SifraPreuzeteLokacije = pSifra;
            // OVDE SE NE DOBIJA NAZIV SPOLJA, VEC SE IZRACUNAVA NAZIV na set svojstvu property za sifru UNUTAR KLASE  
            if (!IsPostBack)
            {
                PrikaziPodatke(objFormaLokacijaDetaljiEdit);
            }  
        }

        protected void btnOmoguciIzmenu_Click(object sender, EventArgs e)
        {
            // PREUZIMANJE POCETNIH, STARIH VREDNOSTI - OVDE NEMA POTREBE JER SE URADI NA PAGE LOAD
            //objFormaLokacijaDetaljiEdit.SifraPreuzeteLokacije = txbSifra.Text;
            // - ovo se izracuna iz sifre, pa se ne moze ni dodeliti: objFormaLokacijaDetaljiEdit.NazivPreuzeteLokacije = txbNaziv.Text; 
            AktivirajKontrole();
            txbSifra.Focus();
        }

        protected void btnSnimiIzmenu_Click(object sender, EventArgs e)
        {
            objFormaLokacijaDetaljiEdit.SifraIzmenjeneLokacije = txbSifra.Text;
            objFormaLokacijaDetaljiEdit.NazivIzmenjeneLokacije = txbNaziv.Text;
            bool uspehIzmene = objFormaLokacijaDetaljiEdit.IzmeniLokaciju();
            if (uspehIzmene)
            {
                lblStatus.Text = "Uspesno izmenjen zapis!";
                IsprazniKontrole();
            }
            else
            {
                lblStatus.Text = "NEUSPEH BRISANJA zapisa!";
            }
            DeaktivirajKontrole();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            objFormaLokacijaDetaljiEdit.SifraPreuzeteLokacije = txbSifra.Text;
            bool uspehBrisanja = objFormaLokacijaDetaljiEdit.ObrisiLokaciju();
            if (uspehBrisanja)
            {
                lblStatus.Text = "Uspesno obrisan zapis!";
                IsprazniKontrole();
            }
            else
            {
                lblStatus.Text = "NEUSPEH BRISANJA zapisa!";
            }
        }

       
    }
}