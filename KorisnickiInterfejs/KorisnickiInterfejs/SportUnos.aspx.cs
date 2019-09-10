using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data;
using System.Configuration;
using PrezentacionaLogika;


namespace KorisnickiInterfejs
{
    public partial class SportUnos : System.Web.UI.Page
    {

        // atributi
        clsFormaSportUnos objFormaSportUnos;

        // konstruktor


        // nase metode
        private void NapuniCombo()
        {
            // IZDVAJANJE PODATAKA IZ XML POSREDSTVOM WEB SERVISA
            DataSet dsDatumTreninga = new DataSet();
            dsDatumTreninga = objFormaSportUnos.DajPodatkeZaCombo();

            int ukupno = dsDatumTreninga.Tables[0].Rows.Count;

            // PUNJENJE COMBO PODACIMA IZ DATASETA
            ddlDatumTreninga.Items.Add("Izaberite...");
            for (int i = 0; i < ukupno; i++)
            {
                ddlDatumTreninga.Items.Add(dsDatumTreninga.Tables[0].Rows[i].ItemArray[1].ToString());
            }

        }

        private void IsprazniKontrole()
        {
            txbNazivSporta.Text = "";
            ddlDatumTreninga.Text = "Izaberite...";
            lblStatus.Text = "";
        }



        protected void Page_Load(object sender, EventArgs e)
        {

            objFormaSportUnos = new clsFormaSportUnos(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            if (!IsPostBack)
            {
                NapuniCombo();
            }

        }


        protected void btnSnimi_Click(object sender, EventArgs e)
        {

            // ***********preuzimanje vrednosti sa korisnickog interfejsa
            // 2. nacin - preuzimaju atributi klase prezentacione logike
            objFormaSportUnos.NazivSporta = txbNazivSporta.Text;
            objFormaSportUnos.DatumTreninga = ddlDatumTreninga.Text;
            

            // *********** provera ispravnosti vrednosti
            // 1. provera popunjenosti
            bool SvePopunjeno = objFormaSportUnos.DaLiJeSvePopunjeno();

            // 2. provera ispravnosti - karakteri, vrednost iz domena, jedinstvenost zapisa
            bool JedinstvenZapis = objFormaSportUnos.DaLiJeJedinstvenZapis();


            // 3. provera ispravnosti - provera uskladjenosti podataka sa poslovnim pravilima
            bool UskladjenoSaPoslovnimPravilima = objFormaSportUnos.DaLiSuPodaciUskladjeniSaPoslovnimPravilima();

            // ********** snimanje u bazu podataka
            string porukaStatusaSnimanja = "";
            if (SvePopunjeno)
            {
                if (JedinstvenZapis)
                {
                    if (UskladjenoSaPoslovnimPravilima)
                    {
                        // snimanje podataka
                        objFormaSportUnos.SnimiPodatke();
                        // priprema teksta poruke o uspehu snimanja
                        porukaStatusaSnimanja = "USPESNO SNIMLJENI PODACI!";
                    }
                    else
                    {
                        porukaStatusaSnimanja = "PODACI NISU U SKLADU SA POSLOVNIM PRAVILIMA!";
                    }
                }
                else
                {
                    porukaStatusaSnimanja = "VEC POSTOJI SPORT SA ISTIM NAZIVOM!";
                }
            }
            else
            {
                // priprema teksta poruke o gresci
                porukaStatusaSnimanja = "NISU SVI PODACI POPUNJENI!";
                txbNazivSporta.Focus();
            }


            // ********** obavestavanje korisnika o statusu snimanja
            lblStatus.Text = porukaStatusaSnimanja; 


        }

        protected void btnPonisti_Click(object sender, EventArgs e)
        {
            IsprazniKontrole();
        }

        protected void ddlDatumTreninga_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}