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
    public partial class SportSpisak : System.Web.UI.Page
    {

        // atributi
       // private clsFormaSportSpisak objFormaSportSpisak;

        // konstruktor


        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSportovi.DataSource = ds.Tables[0];
            gvSportovi.DataBind();
        }



      //  public partial class SportSpisak : System.Web.UI.Page
      //  {
      //      protected void Page_Load(object sender, EventArgs e)
      //      {
      //          objFormaSportSpisak = new clsFormaSportSpisak(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);

      //      }

      //      protected void btnFiltriraj_Click(object sender, EventArgs e)
      //      {
      //          NapuniGrid(objFormaSportSpisak.DajPodatkeZaGrid(txbFilter.Text));
      //      }

      //      protected void btnSvi_Click(object sender, EventArgs e)
      //      {
      //          NapuniGrid(objFormaSportSpisak.DajPodatkeZaGrid(""));
      //      }
      //  }
    }
}