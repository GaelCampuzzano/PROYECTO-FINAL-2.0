using PROYECTO_FINAL_2._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante2._0
{
    public class Comanda
    {
        public int Numero { get; set; }
        public Mesa Mesa { get; set; }
        public List<Platillo> Platillos { get; set; }
    }
}
