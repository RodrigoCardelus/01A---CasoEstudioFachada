using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EntidadesCompartidas
{
    public class Articulo:Interface
    {
        //atributos
        private int codigo;
        private string nombre;
        private decimal precio;
        
        //propiedades
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
               if(value == " " && value.Length > 20)
               {
                   throw new Exception("El Nombre no puede estar vacio ni ser mayor a 20 caracteres");

               }
              nombre = value;

            }
        }
        public decimal Precio
        {
            get { return precio; }
            set
            {
                if (value < 0)
                {

                    throw new Exception("El precio debe ser mayor a 0");
                }
                precio = value;
            }
        }

        //Contructor
        public Articulo(int pCodigo, string pNombre, decimal pPrecio)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
            Precio = pPrecio;
        }

        //operacion
        public int MiOperacion(int codigo)
        {
            return (codigo * Convert.ToInt32(precio));
        }


    }
}
