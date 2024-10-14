using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL_2._0
{
    internal class CategoriaMenu
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Platillo> Platillos { get; set; }

        public CategoriaMenu(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Platillos = new List<Platillo>();
        }

        public void AgregarPlatillo(Platillo platillo)
        {
            Platillos.Add(platillo);
        }

    }
}
