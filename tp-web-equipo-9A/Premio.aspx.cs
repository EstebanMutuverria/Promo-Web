using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Services;
using Utils;

namespace tp_web_equipo_9A
{
    public partial class Premio : System.Web.UI.Page
    {

        public List<Articulo> articuloList {  get; set; }
        public List<string> listimagenes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                ArticuloServices articuloServices = new ArticuloServices();
                articuloList = articuloServices.listar();

                Repetidor.DataSource = articuloList;
                Repetidor.DataBind();
            }
        }

        protected void btnElegirPremio_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Session.Add("IdArticuloSs", btn.CommandArgument);
            Response.Redirect("~/Formulario.aspx");
        }
    }
}