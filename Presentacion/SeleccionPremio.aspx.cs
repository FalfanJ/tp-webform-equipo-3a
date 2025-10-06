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
        public List<Imagenes> listImg { get; set; }

        void Cargar()
        {
            try
            {
                ArticulosNegocio artNeg = new ArticulosNegocio();
                ImagenesNegocio imgNeg = new ImagenesNegocio();
                listArt = artNeg.Listar();
                listImg = imgNeg.Listar();
                foreach (Articulos item in listArt)
                {
                    item.Imagenes = listImg.FindAll(x => x.IdArticulo == item.Id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string url0(int numero)
        {
            if (listArt.Find(x => x.Id == numero).Imagenes.Count != 0)
            {
                return listArt.Find(x => x.Id == numero).Imagenes[0].ImagenURL;
            }
            else
            {
                return "";
            }
        }

        public string Active(int numero)
        {
            return (numero == 0) ? "active" : "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar();
                if (!IsPostBack)
                {
                    Repetidor.DataSource = listArt;
                    Repetidor.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

        protected void btnSelecionador_Click(object sender, EventArgs e)
        {
            int valor = int.Parse(((Button)sender).CommandArgument);
            Session["CodPremio"] = valor;
            Response.Redirect("registro.aspx");
        }
    }
}