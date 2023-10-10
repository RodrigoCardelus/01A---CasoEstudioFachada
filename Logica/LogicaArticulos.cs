using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaArticulos
    {
        internal void AgregarArticulo(Articulo A)
        {
            FachadaPersistencia.AgregarArticulo(A);

        }

        internal void EliminarArticulo(Articulo A)
        {
            FachadaPersistencia.EliminarArticulo(A);

        }


        internal void ModificarArticulo(Articulo A)
        {
            FachadaPersistencia.ModificarArticulo(A);
        }

        internal Articulo BuscarArticulo(int pCodigo)
        {

           return(FachadaPersistencia.BuscarArticulo(pCodigo));
      
        }

        internal List<Articulo> ListarArticulo()
        {

            return (FachadaPersistencia.ListarArticulo());

        }


    }
}
