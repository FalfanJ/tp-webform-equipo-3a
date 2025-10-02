using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace PromoGana
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string codigoVoucher = txtVoucher.Text.Trim();

            VoucherNegocio negocio = new VoucherNegocio();
            var resultado = negocio.ValidarVoucherConEstado(codigoVoucher);

            if (resultado.Estado == EstadoVoucher.NoExiste)
            {
                Session["ErrorMsg"] = "❌ El voucher ingresado no existe.";
                Response.Redirect("Error.aspx");
            }
            else if (resultado.Estado == EstadoVoucher.Usado)
            {
                Session["ErrorMsg"] = "⚠️ El voucher ingresado ya fue utilizado.";
                Response.Redirect("Error.aspx");
            }
            else if (resultado.Estado == EstadoVoucher.Disponible)
            {
                Session["CodigoVoucher"] = codigoVoucher;
                Response.Redirect("SeleccionPremio.aspx");
            }
        }
    }
}
