using System;
using System.Collections.Generic;

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

        public void MenuPrincipal()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("       ---- Sistema de Restaurante ----");
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Gestionar Menú");
                Console.WriteLine("2. Gestionar Categorías");
                Console.WriteLine("3. Gestionar Mesas y Sillas");
                Console.WriteLine("4. Gestionar Comandas");
                Console.WriteLine("5. Ver disponibilidad de Mesas");
                Console.WriteLine("0. Salir");
                Console.WriteLine("=====================================");
                opcion = LeerOpcion("Seleccione una opción: ");

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
                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida, por favor intente de nuevo.");
                        break;
                }

            } while (opcion != 0);
        }

        // Métodos de gestión...

        public void GestionarMenu()
        {
            Console.Clear();
            if (categorias.Count == 0)
            {
                Console.WriteLine("No hay categorías de menú disponibles.");
                PausarConMensaje();
                return;
            }

            MostrarCategorias();
            int seleccionCategoria = LeerNumero("Seleccione una categoría para gestionar: ");
            if (seleccionCategoria > 0 && seleccionCategoria <= categorias.Count)
            {
                var categoriaSeleccionada = categorias[seleccionCategoria - 1];
                GestionarPlatillos(categoriaSeleccionada);
            }
            else
            {
                Console.WriteLine("Selección de categoría inválida.");
            }
            PausarConMensaje();
        }

        private void GestionarPlatillos(CategoriaMenu categoria)
        {
            Console.Clear();
            Console.WriteLine($"---- Gestión de Platillos para {categoria.Nombre} ----");
            Console.WriteLine("1. Agregar Platillo");
            Console.WriteLine("2. Ver Platillos");
            int opcion = LeerOpcion("Seleccione una opción: ");

            switch (opcion)
            {
                case 1:
                    AgregarPlatillo(categoria);
                    break;
                case 2:
                    MostrarPlatillos(categoria);
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }

        private void AgregarPlatillo(CategoriaMenu categoria)
        {
            string nombrePlatillo = LeerCadena("Ingrese el nombre del platillo: ");
            string descripcionPlatillo = LeerCadena("Ingrese la descripción del platillo: ");
            decimal precioPlatillo = LeerDecimal("Ingrese el precio del platillo: ");

            categoria.AgregarPlatillo(new Platillo(nombrePlatillo, descripcionPlatillo, precioPlatillo));
            Console.WriteLine("Platillo agregado exitosamente.");
            PausarConMensaje();
        }

        private void MostrarPlatillos(CategoriaMenu categoria)
        {
            Console.Clear();
            Console.WriteLine($"---- Platillos en la categoría {categoria.Nombre} ----");
            if (categoria.Platillos.Count == 0)
            {
                Console.WriteLine("No hay platillos en esta categoría.");
                return;
            }
            foreach (var platillo in categoria.Platillos)
            {
                Console.WriteLine($"{platillo.Nombre}: {platillo.Precio:C} - {platillo.Descripcion}");
            }
            PausarConMensaje();
        }

        public void GestionarCategorias()
        {
            Console.Clear();
            Console.WriteLine("---- Gestión de Categorías ----");
            Console.WriteLine("1. Agregar Categoría");
            Console.WriteLine("2. Ver Categorías");
            int opcion = LeerOpcion("Seleccione una opción: ");

            switch (opcion)
            {
                case 1:
                    string nombreCategoria = LeerCadena("Ingrese el nombre de la categoría: ");
                    string descripcionCategoria = LeerCadena("Ingrese la descripción de la categoría: ");
                    categorias.Add(new CategoriaMenu(nombreCategoria, descripcionCategoria));
                    Console.WriteLine("Categoría agregada exitosamente.");
                    break;
                case 2:
                    MostrarCategorias();
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
            PausarConMensaje();
        }

        private void MostrarCategorias()
        {
            Console.Clear();
            Console.WriteLine("---- Categorías Disponibles ----");
            if (categorias.Count == 0)
            {
                Console.WriteLine("No hay categorías disponibles.");
                return;
            }
            for (int i = 0; i < categorias.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categorias[i].Nombre} - {categorias[i].Descripcion}");
            }
        }

        public void GestionarMesasYSillas()
        {
            Console.Clear();
            int numMesas = LeerNumero("Ingrese el número de mesas: ");
            for (int i = 1; i <= numMesas; i++)
            {
                int numSillas = LeerNumero($"Ingrese el número de sillas para la mesa {i}: ");
                mesas.Add(new Mesa(i, numSillas));
            }
            Console.WriteLine("Mesas y sillas agregadas exitosamente.");
            PausarConMensaje();
        }

        public void GestionarComandas()
        {
            Console.Clear();
            int numeroMesa = LeerNumero("Ingrese el número de la mesa: ");
            Mesa mesa = mesas.Find(m => m.Numero == numeroMesa);
            if (mesa == null)
            {
                Console.WriteLine("Mesa no encontrada.");
                PausarConMensaje();
                return;
            }

            Comanda comanda = new Comanda(numeroMesa);
            comandas.Add(comanda);

            int opcion;
            do
            {
                Console.WriteLine("1. Agregar platillo a la comanda");
                Console.WriteLine("2. Quitar platillo de la comanda");
                Console.WriteLine("3. Finalizar comanda");
                opcion = LeerOpcion("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        string nombrePlatillo = LeerCadena("Ingrese el nombre del platillo: ");
                        Platillo platillo = ObtenerPlatilloPorNombre(nombrePlatillo);
                        if (platillo != null)
                        {
                            comanda.AgregarPlatillo(platillo);
                            Console.WriteLine("Platillo agregado a la comanda.");
                        }
                        else
                        {
                            Console.WriteLine("Platillo no encontrado.");
                        }
                        break;
                    case 2:
                        string nombreQuitar = LeerCadena("Ingrese el nombre del platillo a quitar: ");
                        comanda.QuitarPlatillo(nombreQuitar);
                        Console.WriteLine("Platillo quitado de la comanda.");
                        break;
                    case 3:
                        Console.WriteLine("Comanda finalizada.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            } while (opcion != 3);

            PausarConMensaje();
        }

        private Platillo ObtenerPlatilloPorNombre(string nombre)
        {
            foreach (var categoria in categorias)
            {
                var platillo = categoria.BuscarPlatillo(nombre);
                if (platillo != null)
                    return platillo;
            }
            return null;
        }

        public void VerDisponibilidadMesas()
        {
            Console.Clear();
            Console.WriteLine("---- Disponibilidad de Mesas ----");
            foreach (var mesa in mesas)
            {
                string estado = mesa.Ocupada ? "Ocupada" : "Disponible";
                Console.WriteLine($"Mesa {mesa.Numero}: {estado}");
            }
            PausarConMensaje();
        }

        // Métodos auxiliares

        private int LeerOpcion(string mensaje)
        {
            Console.Write(mensaje);
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
            }
            return opcion;
        }

        private string LeerCadena(string mensaje)
        {
            Console.Write(mensaje);
            return Console.ReadLine();
        }

        private decimal LeerDecimal(string mensaje)
        {
            decimal valor;
            Console.Write(mensaje);
            while (!decimal.TryParse(Console.ReadLine(), out valor) || valor <= 0)
            {
                Console.WriteLine("Por favor, ingrese un número válido mayor que cero.");
            }
            return valor;
        }

        private int LeerNumero(string mensaje)
        {
            Console.Write(mensaje);
            int numero;
            while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0)
            {
                Console.WriteLine("Por favor, ingrese un número válido mayor que cero.");
            }
            return numero;
        }

        private void PausarConMensaje()
        {
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
