using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Configuration;
using System.Data;

namespace KorisnickiInterfejs
{
    public partial class LokacijaTabelarni : System.Web.UI.Page
    {


        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakLokacija.DataSource = ds.Tables[0];
            gvSpisakLokacija.DataBind();
        }
        


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            KlasePodataka.clsLokacijaDB objLokacijaDB = new KlasePodataka.clsLokacijaDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            
        }

        protected void btnSvi_Click(object sender, EventArgs e)
        {
            KlasePodataka.clsLokacijaDB objLokacijaDB = new KlasePodataka.clsLokacijaDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(objLokacijaDB.DajSveLokacije()); 
        }

     
    }
}