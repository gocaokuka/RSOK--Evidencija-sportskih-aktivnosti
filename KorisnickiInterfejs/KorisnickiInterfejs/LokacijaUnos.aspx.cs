using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Configuration; 

namespace KorisnickiInterfejs
{
    public partial class LokacijaUnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSnimi_Click(object sender, EventArgs e)
        {
            KlasePodataka.clsLokacijaDB objLokacijaDB = new KlasePodataka.clsLokacijaDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            KlasePodataka.clsLokacija objLokacija = new KlasePodataka.clsLokacija();
            objLokacija.Naziv = txbNaziv.Text;
            objLokacija.Sifra = txbSifra.Text;
            objLokacijaDB.SnimiNovuLokaciju(objLokacija);
            lblStatus.Text = "Snimljeno";
        }

        protected void btnOdustani_Click(object sender, EventArgs e)
        {

        }
    }
}