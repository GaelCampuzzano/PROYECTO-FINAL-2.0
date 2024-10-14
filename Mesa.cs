using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL_2._0
{
    internal class Mesa
    {
        public int Numero { get; set; }
        public int Sillas { get; set; }
        public bool Ocupada { get; set; }

        public Mesa(int numero, int sillas)
        {
            Numero = numero;
            Sillas = sillas;
            Ocupada = false;
        }

        public void OcuparMesa()
        {
            Ocupada = true;
        }

        public void LiberarMesa()
        {
            Ocupada = false;
        }

    }
}
