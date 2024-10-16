using System;

namespace PROYECTO_FINAL_2._0
{
    public class Platillo
    {
        public string Nombre { get; }
        public string Descripcion { get; }
        public decimal Precio { get; }

        public Platillo(string nombre, string descripcion, decimal precio)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del platillo no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.");
            if (precio <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero.");

            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
        }
    }
}
