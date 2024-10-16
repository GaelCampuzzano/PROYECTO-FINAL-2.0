using System;
using System.Collections.Generic;

namespace PROYECTO_FINAL_2._0
{
    public class Comanda
    {
        public int NumeroMesa { get; }
        private List<Platillo> platillos;

        public Comanda(int numeroMesa)
        {
            NumeroMesa = numeroMesa;
            platillos = new List<Platillo>();
        }

        public void AgregarPlatillo(Platillo platillo)
        {
            platillos.Add(platillo);
        }

        public void QuitarPlatillo(string nombre)
        {
            var platillo = platillos.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (platillo != null)
            {
                platillos.Remove(platillo);
            }
            else
            {
                Console.WriteLine("Platillo no encontrado en la comanda.");
            }
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var platillo in platillos)
            {
                total += platillo.Precio;
            }
            return total;
        }
    }
}
