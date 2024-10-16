using System;
using System.Collections.Generic;

namespace PROYECTO_FINAL_2._0
{
    internal class CategoriaMenu
    {
        public string Nombre { get; }
        public string Descripcion { get; }
        public List<Platillo> Platillos { get; }

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

        public Platillo BuscarPlatillo(string nombre)
        {
            return Platillos.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
    }
}
