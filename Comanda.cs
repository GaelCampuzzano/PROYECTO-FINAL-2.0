using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL_2._0
{
    public class Comanda
    {
        public int NumeroMesa { get; set; }
        public List<Platillo> Platillos { get; set; }

        public Comanda(int numeroMesa)
        {
            NumeroMesa = numeroMesa;
            Platillos = new List<Platillo>();
        }

        public void AgregarPlatillo(Platillo platillo)
        {
            Platillos.Add(platillo);
        }

        public void QuitarPlatillo(string nombrePlatillo)
        {
            Platillos.RemoveAll(p => p.Nombre == nombrePlatillo);
        }
    }
}