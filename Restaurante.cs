using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL_2._0
{
    public class Restaurante
    {
        private List<CategoriaMenu> categorias;
        private List<Mesa> mesas;
        private List<Comanda> comandas;

        public Restaurante()
        {
            categorias = new List<CategoriaMenu>();
            mesas = new List<Mesa>();
            comandas = new List<Comanda>();
        }

        // Método principal del menú
        public void MenuPrincipal()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("---- Sistema de Restaurante ----");
                Console.WriteLine("1. Gestionar Menú");
                Console.WriteLine("2. Gestionar Categorías");
                Console.WriteLine("3. Gestionar Mesas y Sillas");
                Console.WriteLine("4. Gestionar Comandas");
                Console.WriteLine("5. Ver disponibilidad de Mesas");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        GestionarMenu();
                        break;
                    case 2:
                        GestionarCategorias();
                        break;
                    case 3:
                        GestionarMesasYSillas();
                        break;
                    case 4:
                        GestionarComandas();
                        break;
                    case 5:
                        VerDisponibilidadMesas();
                        break;
                }

            } while (opcion != 0);
        }

        // Otros métodos relacionados a la gestión del restaurante...

        public void GestionarMenu() { /* Implementación */ }

        public void GestionarCategorias() { /* Implementación */ }

        public void GestionarMesasYSillas() { /* Implementación */ }

        public void GestionarComandas() { /* Implementación */ }

        public void VerDisponibilidadMesas() { /* Implementación */ }
    }
}
