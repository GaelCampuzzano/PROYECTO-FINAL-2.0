using System;
using System.Collections.Generic;

namespace Restaurante2._0
{
    public class Comanda
    {
        public int Numero { get; private set; }
        public Mesa Mesa { get; private set; }
        public List<Platillo> Platillos { get; private set; }
        public DateTime FechaHora { get; private set; }

        public Comanda(Mesa mesa, List<Platillo> platillos, int numero)
        {
            Mesa = mesa;
            Platillos = platillos;
            Numero = numero;
            FechaHora = DateTime.Now;
        }
    }
}