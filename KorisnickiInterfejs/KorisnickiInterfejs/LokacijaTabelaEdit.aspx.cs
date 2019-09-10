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
    public partial class LokacjaTabelaEdit : System.Web.UI.Page
    {

        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakLokacijaEdit.DataSource = ds.Tables[0];
            gvSpisakLokacijaEdit.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clsFormaLokacijaTabelaEdit objFormaZvanjeTabelaEdit = new clsFormaLokacijaTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                
            }
        }

        protected void gvSpisakLokacijaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("LokacijaDetaljiEdit.aspx?Sifra=" + gvSpisakLokacijaEdit.Rows[gvSpisakLokacijaEdit.SelectedIndex].Cells[1].Text); 
        }
    }
}