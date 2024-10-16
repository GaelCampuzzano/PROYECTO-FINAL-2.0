using System;
using System.Collections.Generic;

namespace Restaurante2._0
{
    public class Program
    {
        private static List<Mesa> _mesas = new List<Mesa>();
        private static List<Comanda> _comandas = new List<Comanda>();
        private static List<Platillo> _platillos = new List<Platillo>();

        public static void Main(string[] args)
        {
            IniciarSistema();
        }

        private static void IniciarSistema()
        {
            Console.WriteLine("Sistema de Gestión de Restaurante");
            Console.WriteLine("-------------------------------");

            while (true)
            {
                Console.WriteLine("Opciones:");
                Console.WriteLine("1. Gestionar Menú");
                Console.WriteLine("2. Gestionar Mesas y Sillas");
                Console.WriteLine("3. Crear Comanda");
                Console.WriteLine("4. Ver Disponibilidad de Mesas");
                Console.WriteLine("5. Salir");

                Console.Write("Seleccione una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        GestionarMenu();
                        break;
                    case 2:
                        GestionarMesasYSillas();
                        break;
                    case 3:
                        CrearComanda();
                        break;
                    case 4:
                        VerDisponibilidadMesas();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }

        private static void GestionarMenu()
        {
            Console.WriteLine("Gestionar Menú");
            Console.WriteLine("------------");

            while (true)
            {
                Console.WriteLine("Opciones:");
                Console.WriteLine("1. Agregar Platillo");
                Console.WriteLine("2. Quitar Platillo");
                Console.WriteLine("3. Ver Platillos");
                Console.WriteLine("4. Regresar");

                Console.Write("Seleccione una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarPlatillo();
                        break;
                    case 2:
                        QuitarPlatillo();
                        break;
                    case 3:
                        VerPlatillos();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }

        private static void AgregarPlatillo()
        {
            Console.Write("Ingrese el nombre del platillo: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la descripción del platillo: ");
            string descripcion = Console.ReadLine();
            Console.Write("Ingrese la categoría del platillo: ");
            string categoria = Console.ReadLine();
            Console.Write("Ingrese el precio del platillo: ");
            decimal precio = Convert.ToDecimal(Console.ReadLine());

            Platillo platillo = new Platillo { Nombre = nombre, Descripcion = descripcion, Categoria = categoria, Precio = precio };
            _platillos.Add(platillo);

            Console.WriteLine("Platillo agregado con éxito!");
        }

        private static void QuitarPlatillo()
        {
            Console.Write("Ingrese el nombre del platillo a quitar: ");
            string nombre = Console.ReadLine();

            Platillo platillo = _platillos.Find(p => p.Nombre == nombre);
            if (platillo != null)
            {
                _platillos.Remove(platillo);
                Console.WriteLine("Platillo quitado con éxito");
            }
            else
            {
                Console.WriteLine("Platillo no encontrado");
            }
        }

        private static void VerPlatillos()
        {
            Console.WriteLine("Platillos:");
            foreach (Platillo platillo in _platillos)
            {
                Console.WriteLine($"Nombre: {platillo.Nombre}, Descripción: {platillo.Descripcion}, Categoría: {platillo.Categoria}, Precio: {platillo.Precio}");
            }
        }

        private static void GestionarMesasYSillas()
        {
            Console.Clear();
            Console.WriteLine("Gestionar Mesas y Sillas");
            Console.WriteLine("---------------------");

            while (true)
            {
                Console.WriteLine("Opciones:");
                Console.WriteLine("1. Agregar Mesa");
                Console.WriteLine("2. Quitar Mesa");
                Console.WriteLine("3. Ver Mesas");
                Console.WriteLine("4. Regresar");

                Console.Write("Seleccione una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarMesa();
                        break;
                    case 2:
                        QuitarMesa();
                        break;
                    case 3:
                        VerMesas();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }

        private static void AgregarMesa()
        {
            Console.Write("Ingrese el número de la mesa: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el número de sillas: ");
            int sillas = Convert.ToInt32(Console.ReadLine());

            Mesa mesa = new Mesa { Numero = numero, Sillas = sillas, Ocupada = false };
            _mesas.Add(mesa);

            Console.WriteLine("Mesa agregada con éxito");
        }

        private static void QuitarMesa()
        {
            Console.Write("Ingrese el número de la mesa a quitar: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Mesa mesa = _mesas.Find(m => m.Numero == numero);
            if (mesa != null)
            {
                _mesas.Remove(mesa);
                Console.WriteLine("Mesa quitada con éxito");
            }
            else
            {
                Console.WriteLine("Mesa no encontrada");
            }
        }

        private static void VerMesas()
        {
            Console.WriteLine("Mesas:");
            foreach (Mesa mesa in _mesas)
            {
                Console.WriteLine($"Número: {mesa.Numero}, Sillas: {mesa.Sillas}, Estado: {mesa.EstadoOcupacion()}");
            }
        }

        private static void CrearComanda()
        {
            Console.Write("Ingrese el número de la comanda: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el número de la mesa: ");
            int numeroMesa = Convert.ToInt32(Console.ReadLine());

            Mesa mesa = _mesas.Find(m => m.Numero == numeroMesa);
            if (mesa != null)
            {
                Comanda comanda = new Comanda { Numero = numero, Mesa = mesa, Platillos = new List<Platillo>() };
                _comandas.Add(comanda);

                // Actualiza la propiedad Ocupada de la mesa
                mesa.Ocupada = true;

                Console.WriteLine("Comanda creada con éxito");
            }
            else
            {
                Console.WriteLine("Mesa no encontrada");
            }
        }

        private static void CerrarComanda()
        {
            Console.Write("Ingrese el número de la comanda: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Comanda comanda = _comandas.Find(c => c.Numero == numero);
            if (comanda != null)
            {
                // Actualiza la propiedad Ocupada de la mesa
                comanda.Mesa.Ocupada = false;

                _comandas.Remove(comanda);

                Console.WriteLine("Comanda cerrada con éxito");
            }
            else
            {
                Console.WriteLine("Comanda no encontrada");
            }
        }

        private static void VerDisponibilidadMesas()
        {
            Console.WriteLine("Disponibilidad de Mesas:");
            foreach (Mesa mesa in _mesas)
            {
                Console.WriteLine($"Número: {mesa.Numero}, Sillas: {mesa.Sillas}, Estado: {mesa.EstadoOcupacion()}");
            }
        }
    }
}