using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class VoucherNegocio
    {
        public Vouchers ValidarVoucher(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers WHERE CodigoVoucher = @codigo");
                datos.SetearParametro("@codigo", codigo);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    // si ya tiene cliente y fecha → ya usado
                    if (datos.Lector["IdCliente"] != DBNull.Value && datos.Lector["FechaCanje"] != DBNull.Value)
                        return null;

                    Vouchers v = new Vouchers
                    {
                        CodigoVoucher = (string)datos.Lector["CodigoVoucher"]
                    };
                    return v;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}

