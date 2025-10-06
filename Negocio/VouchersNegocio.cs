using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public enum EstadoVoucher
    {
        NoExiste,
        Usado,
        Disponible
    }

    public class ResultadoVoucher
    {
        public EstadoVoucher Estado { get; set; }
        public Vouchers Voucher { get; set; }
    }

    public class VoucherNegocio
    {
        public ResultadoVoucher ValidarVoucherConEstado(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers WHERE CodigoVoucher = @codigo");
                datos.SetearParametro("@codigo", codigo);
                datos.EjecutarLectura();

                if (!datos.Lector.Read())
                {
                    // no existe
                    return new ResultadoVoucher { Estado = EstadoVoucher.NoExiste };
                }

                object idClienteObj = datos.Lector["IdCliente"];
                object fechaObj = datos.Lector["FechaCanje"];

                if (idClienteObj != DBNull.Value && fechaObj != DBNull.Value)
                {
                    // ya está usado
                    return new ResultadoVoucher { Estado = EstadoVoucher.Usado };
                }

                // disponible
                Vouchers v = new Vouchers
                {
                    CodigoVoucher = datos.Lector["CodigoVoucher"].ToString()
                };

                return new ResultadoVoucher
                {
                    Estado = EstadoVoucher.Disponible,
                    Voucher = v
                };
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // ---- Registramos el canje del voucher
        public void RegistrarCanje(string codigoVoucher, int idCliente, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE Vouchers SET IdCliente = @idCliente, FechaCanje = @fecha, IdArticulo = @idArticulo WHERE CodigoVoucher = @codigo");
                datos.SetearParametro("@idCliente", idCliente);
                datos.SetearParametro("@fecha", DateTime.Now);
                datos.SetearParametro("@idArticulo", idArticulo);
                datos.SetearParametro("@codigo", codigoVoucher);
                datos.EjecutarAccion();
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
