using System;
using Dominio;
using Negocio;
using System.Text.RegularExpressions;

namespace Presentacion
{
    public partial class registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LimpiarClasesValidacion();

                // ---- Recuperamos los valores guardados en session
                string codigoVoucher = Session["CodigoVoucher"] as string;
                int? codPremio = Session["CodPremio"] as int?;

                if (string.IsNullOrEmpty(codigoVoucher) || codPremio == null)
                {
                    // ---- Si no hay datos guardados, vamos al inicio
                    Response.Redirect("MainForm.aspx");
                    return;
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            LimpiarClasesValidacion();
            lblError.Text = "";

            string dni = txtDni.Text.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                txtDni.CssClass = "form-control is-invalid";
                return;
            }

            ClienteNegocio negocio = new ClienteNegocio();
            Clientes cliente = negocio.BuscarPorDni(dni);

            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCp.Text = cliente.Cp.ToString();

                txtDni.CssClass = "form-control is-valid";
                txtNombre.CssClass = "form-control is-valid";
                txtApellido.CssClass = "form-control is-valid";
                txtEmail.CssClass = "form-control is-valid";
                txtDireccion.CssClass = "form-control is-valid";
                txtCiudad.CssClass = "form-control is-valid";
                txtCp.CssClass = "form-control is-valid";
            }
            else
            {
                txtDni.CssClass = "form-control is-invalid";
                lblError.Text = "DNI no encontrado. Complete el formulario para registrarse.";
                lblError.CssClass = "text-danger mt-2";
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            bool formularioValido = true;
            LimpiarClasesValidacion();
            lblError.Text = "";

            Regex soloLetras = new Regex("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$");

            // ---- Validar DNI
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                txtDni.CssClass = "form-control is-invalid";
                formularioValido = false;
            }
            else
            {
                txtDni.CssClass = "form-control is-valid";
            }

            // ---- Validar Nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || !soloLetras.IsMatch(txtNombre.Text.Trim()))
            {
                txtNombre.CssClass = "form-control is-invalid";
                formularioValido = false;
            }
            else
            {
                txtNombre.CssClass = "form-control is-valid";
            }

            // ---- Validar Apellido
            if (string.IsNullOrWhiteSpace(txtApellido.Text) || !soloLetras.IsMatch(txtApellido.Text.Trim()))
            {
                txtApellido.CssClass = "form-control is-invalid";
                formularioValido = false;
            }
            else
            {
                txtApellido.CssClass = "form-control is-valid";
            }

            // ---- Validar Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !EsEmailValido(txtEmail.Text))
            {
                txtEmail.CssClass = "form-control is-invalid";
                formularioValido = false;
            }
            else
            {
                txtEmail.CssClass = "form-control is-valid";
            }

            // ---- Validar Dirección
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                txtDireccion.CssClass = "form-control is-invalid";
                formularioValido = false;
            }
            else
            {
                txtDireccion.CssClass = "form-control is-valid";
            }

            // ---- Validar Ciudad
            if (string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                txtCiudad.CssClass = "form-control is-invalid";
                formularioValido = false;
            }
            else
            {
                txtCiudad.CssClass = "form-control is-valid";
            }

            // ---- Validar Código Postal
            if (!int.TryParse(txtCp.Text, out int cpValue) || cpValue <= 0)
            {
                txtCp.CssClass = "form-control is-invalid";
                formularioValido = false;
            }
            else
            {
                txtCp.CssClass = "form-control is-valid";
            }

            // ---- Validar Términos
            if (!chkTerminos.Checked)
            {
                chkTerminos.CssClass = "form-check-input is-invalid";
                formularioValido = false;
            }
            else
            {
                chkTerminos.CssClass = "form-check-input is-valid";
            }

            if (!formularioValido) return;

            // ---- Recuperamos los datos del voucher y premio de la session
            string codigoVoucher = Session["CodigoVoucher"] as string;
            int idArticulo = (int)Session["CodPremio"];

            ClienteNegocio clienteNeg = new ClienteNegocio();
            VoucherNegocio voucherNeg = new VoucherNegocio();

            try
            {
                // ---- Buscamos si el cliente ya existe
                Clientes clienteExistente = clienteNeg.BuscarPorDni(txtDni.Text.Trim());
                int idCliente;

                if (clienteExistente == null)
                {
                    // ---- Registramos un nuevo cliente
                    Clientes nuevo = new Clientes
                    {
                        Documento = txtDni.Text.Trim(),
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = txtApellido.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Direccion = txtDireccion.Text.Trim(),
                        Ciudad = txtCiudad.Text.Trim(),
                        Cp = cpValue
                    };

                    clienteNeg.RegistrarCliente(nuevo);
                    idCliente = clienteNeg.BuscarPorDni(nuevo.Documento).Id;
                }
                else
                {
                    // ---- Si ya existe
                    idCliente = clienteExistente.Id;
                }

                // ---- Registramos el canje del voucher
                voucherNeg.RegistrarCanje(codigoVoucher, idCliente, idArticulo);

                // ---- Redirigimos a la página de éxito
                Response.Redirect("exito.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al procesar el registro o canje: " + ex.Message;
                lblError.CssClass = "text-danger mt-2";
            }
        }

        // ---- Reset form 
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDni.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtCp.Text = string.Empty;
            chkTerminos.Checked = false;

            LimpiarClasesValidacion();
            lblError.Text = "";
        }

        // ---- Limpiamos los mensajes de error
        private void LimpiarClasesValidacion()
        {
            txtDni.CssClass = "form-control";
            txtNombre.CssClass = "form-control";
            txtApellido.CssClass = "form-control";
            txtEmail.CssClass = "form-control";
            txtDireccion.CssClass = "form-control";
            txtCiudad.CssClass = "form-control";
            txtCp.CssClass = "form-control";
            chkTerminos.CssClass = "form-check-input";
        }

        // ---- Validar mail con regex
        private bool EsEmailValido(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
