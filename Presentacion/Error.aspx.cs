using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PromoGana
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["ErrorMsg"] != null)
            {
                lblErrorMsg.Text = Session["ErrorMsg"].ToString();
                Session.Remove("ErrorMsg"); // limpiar para no repetir en la próxima
            }
            else
            {
                lblErrorMsg.Text = "Ocurrió un error inesperado.";
            }
        }
    }
}