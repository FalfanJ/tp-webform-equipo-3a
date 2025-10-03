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

            if (string.IsNullOrEmpty(codigoVoucher))
            {
                lblMensaje.Text = "⚠️ Debés ingresar un código de voucher.";
                return;
            }

            VoucherNegocio negocio = new VoucherNegocio();
            Vouchers voucher = negocio.ValidarVoucher(codigoVoucher);

            if (voucher == null)
            {
                // Si no es válido, lo mando a la pantalla de error
                Response.Redirect("Error.aspx");
            }
            else
            {
                // Guardar en sesión para usarlo en el siguiente paso
                Session["CodigoVoucher"] = codigoVoucher;

                // Redirigir a la selección de premios
                Response.Redirect("SeleccionPremio.aspx");
            }
        }
    }
}
