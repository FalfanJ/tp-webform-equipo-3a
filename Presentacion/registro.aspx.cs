using System;
using System.Web.UI;

namespace Presentacion
{
    public partial class registro : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            //  ---- Por ahora solo simulamos guardado , mas adelante asgrego el registro a la db con validaciones , solo happy path
            string dni = txtDni.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;

   
            Response.Redirect("exito.aspx");
        }
    }
}
