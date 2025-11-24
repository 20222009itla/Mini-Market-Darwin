using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_de_crud
{
    public class Personas1
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public int Precio { get; set; }

        public int Stock { get; set; }
        //public int Id { get; internal set; }

        //public int MostrarRegistro { get; set; }

        public Personas1() { }

        public Personas1(int id, string nombre, string descripcion, string marca, int precio, int stock)
        {
            this.id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Marca = marca;
            Precio = precio;
            Stock = stock;
           // MostrarRegistro = MostrarRegistro;
        }

     
    }
}
