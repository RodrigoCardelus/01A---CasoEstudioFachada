using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaArticulos
    {
        //Operaciones
        internal void AgregarArt(Articulo A)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AltaArticulo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter codigo = new SqlParameter("@cod", A.Codigo);
            SqlParameter nombre = new SqlParameter("@nom", A.Nombre);
            SqlParameter precio = new SqlParameter("@pre", A.Precio);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(codigo);
            oComando.Parameters.Add(nombre);
            oComando.Parameters.Add(precio);
            oComando.Parameters.Add(Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("Error en Alta");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

         }

        internal void EliminarArt(Articulo A)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BajaArticulo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter codigo = new SqlParameter("@cod",A.Codigo);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(codigo);
            oComando.Parameters.Add(Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El Articulo No existe");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

        }

        internal void ModificarArt(Articulo A)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("ModArticulo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter codigo = new SqlParameter("@cod", A.Codigo);
            SqlParameter nombre = new SqlParameter("@nom", A.Nombre);
            SqlParameter precio = new SqlParameter("@pre", A.Precio);
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(codigo);
            oComando.Parameters.Add(nombre);
            oComando.Parameters.Add(precio);
            oComando.Parameters.Add(Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("No Existe el Articulo");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

        }

        internal Articulo BuscarArt(int pCodigo)
        {
            int codigo;
            string nombre;
            decimal precio;
            Articulo a = null;
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("Exec BuscoArticulo " + pCodigo, oConexion);

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    codigo = (int)oReader["CodArt"];
                    nombre = (string)oReader["NomArt"];
                    precio = (decimal)oReader["PreArt"];
                    a = new Articulo(codigo,nombre,precio);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return a;
        }

        internal List<Articulo> ListarArt()
        {
            int codigo;
            string nombre;
            decimal precio;
            List<Articulo> _Lista = new List<Articulo>();
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("Exec ListoArticulo", _Conexion);
            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                while (_Reader.Read())
                {
                    codigo = (int)_Reader["CodArt"];
                    nombre = (string)_Reader["NomArt"];
                    precio = (decimal)_Reader["PreArt"];
                    Articulo a = new Articulo(codigo,nombre, precio);
                   _Lista.Add(a);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }
            return _Lista;
        }

    }
}
