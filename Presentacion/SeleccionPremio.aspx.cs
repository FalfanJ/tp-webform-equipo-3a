using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class SeleccionPremio : System.Web.UI.Page
    {
        public List<Articulos> listArt { get; set; }

        void Cargar()
        {
            ArticulosNegocio artNeg = new ArticulosNegocio();
            listArt = artNeg.Listar();
        }

        public string Active(int numero)
        {
            return (numero == 0) ? "active" : "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar();
            Repetidor.DataSource = listArt;
            Repetidor.DataBind();
        }
    }
}