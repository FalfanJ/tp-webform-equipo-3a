using System;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        public Clientes BuscarPorDni(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            Clientes cliente = null;

            try
            {
                datos.SetearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, Cp FROM Clientes WHERE Documento = @dni");
                datos.SetearParametro("@dni", dni);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    cliente = new Clientes
                    {
                        Id = (int)datos.Lector["Id"],
                        Documento = (string)datos.Lector["Documento"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Apellido = (string)datos.Lector["Apellido"],
                        Email = (string)datos.Lector["Email"],
                        Direccion = datos.Lector["Direccion"] != DBNull.Value ? (string)datos.Lector["Direccion"] : "",
                        Ciudad = datos.Lector["Ciudad"] != DBNull.Value ? (string)datos.Lector["Ciudad"] : "",
                        Cp = datos.Lector["Cp"] != DBNull.Value ? Convert.ToInt32(datos.Lector["Cp"]) : 0
                    };
                }

                return cliente;
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

        public void RegistrarCliente(Clientes nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, Cp) VALUES (@doc, @nom, @ape, @mail, @dir, @ciu, @cp)");
                datos.SetearParametro("@doc", nuevo.Documento);
                datos.SetearParametro("@nom", nuevo.Nombre);
                datos.SetearParametro("@ape", nuevo.Apellido);
                datos.SetearParametro("@mail", nuevo.Email);
                datos.SetearParametro("@dir", nuevo.Direccion);
                datos.SetearParametro("@ciu", nuevo.Ciudad);
                datos.SetearParametro("@cp", nuevo.Cp);
                datos.EjecutarAccion();
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
