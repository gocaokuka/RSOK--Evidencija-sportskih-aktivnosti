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
    public partial class LokacijaStampa : System.Web.UI.Page
    {
        // atributi

        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakLokacija.DataSource = ds.Tables[0];
            gvSpisakLokacija.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            clsFormaLokacijaStampa objFormaLokacijaStampa = new clsFormaLokacijaStampa(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            string filter = Request.QueryString["filter"].ToString();

            if (filter.Equals(""))
            {
                lblNaslov.Text = "SPISAK SVIH LOKACIJA";
            }
            else
            {
                lblNaslov.Text = "FILTRIRANI SPISAK LOKACIJA, naziv=" + filter;
            }

            NapuniGrid(objFormaLokacijaStampa.DajPodatkeZaGrid(filter));
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}