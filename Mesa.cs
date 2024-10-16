using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante2._0
{
    public class Mesa
    {
        public int Numero { get; set; }
        public int Sillas { get; set; }
        public bool Ocupada { get; set; }

        public string EstadoOcupacion()
        {
            return Ocupada ? "Ocupada" : "Disponible";
        }
    }
}
