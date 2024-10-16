using System;

namespace PROYECTO_FINAL_2._0
{
    internal class Mesa
    {
        public int Numero { get; }
        public int Sillas { get; }
        public bool Ocupada { get; private set; }

        public Mesa(int numero, int sillas)
        {
            if (sillas <= 0)
                throw new ArgumentException("El número de sillas debe ser mayor que cero.");

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
