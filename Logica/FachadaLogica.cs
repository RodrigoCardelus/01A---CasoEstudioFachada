using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class FachadaLogica
    {
        public static void AgregarArticulo(Articulo A)
        {
            new LogicaArticulos().AgregarArticulo(A);
        }


        public static void EliminarArticulo(Articulo A)
        {
            new LogicaArticulos().EliminarArticulo(A);
        }


        public static void ModificarArticulo(Articulo A)
        {
            new LogicaArticulos().ModificarArticulo(A);
        }


        public static Articulo BuscarArticulo(int pCodigo)
        {

            return new LogicaArticulos().BuscarArticulo(pCodigo);

        }

        public static List<Articulo> ListarArticulo()
        {

            return new LogicaArticulos().ListarArticulo();

        }



    }
}
