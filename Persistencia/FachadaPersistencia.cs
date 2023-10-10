using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    public class FachadaPersistencia
    {
        public static void AgregarArticulo(Articulo A)
        {
            PersistenciaArticulos pArticulos = new PersistenciaArticulos();
            pArticulos.AgregarArt(A);

        }

        public static void EliminarArticulo(Articulo A)
        {
            PersistenciaArticulos pArticulos = new PersistenciaArticulos();
            pArticulos.EliminarArt(A);

        }


        public static void ModificarArticulo(Articulo A)
        {
            PersistenciaArticulos pArticulos = new PersistenciaArticulos();
            pArticulos.ModificarArt(A);
        }

        public static Articulo BuscarArticulo(int pCodigo)
        {

            PersistenciaArticulos pArticulos = new PersistenciaArticulos();
            return pArticulos.BuscarArt(pCodigo);

        }

        public static List<Articulo> ListarArticulo()
        {

            PersistenciaArticulos PArticulos = new PersistenciaArticulos();
            return PArticulos.ListarArt();


        }



    }
}
