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
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
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
                        AgregarMesas();
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

        private static void AgregarMesas()
        {         
                Console.Write("Ingrese el número de mesas a agregar: ");
                int cantidadMesas = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i <= cantidadMesas; i++)
                {
                    Console.Write($"Ingrese el número de sillas para la mesa {i}: ");
                    int sillasPorMesa = Convert.ToInt32(Console.ReadLine());

                    Mesa mesa = new Mesa { Numero = _mesas.Count + 1, Sillas = sillasPorMesa, Ocupada = false };
                    _mesas.Add(mesa);
                    Console.WriteLine($"Mesa {mesa.Numero} con {sillasPorMesa} sillas agregada con éxito");
                }
        }

        private static void QuitarMesa()
        {
            Console.Clear();
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
            Console.Clear();
            Console.WriteLine("Mesas:");
            foreach (Mesa mesa in _mesas)
            {
                Console.WriteLine($"Número: {mesa.Numero}, Sillas: {mesa.Sillas}, Estado: {mesa.EstadoOcupacion()}");
            }
        }

        private static void CrearComanda()
        {
            Console.Clear();
            Console.Write("Ingrese el número de la comanda: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el número de la mesa: ");
            int numeroMesa = Convert.ToInt32(Console.ReadLine());

            Mesa mesa = _mesas.Find(m => m.Numero == numeroMesa);
            if (mesa != null)
            {
                // Crear nueva comanda
                Comanda comanda = new Comanda { Numero = numero, Mesa = mesa, Platillos = new List<Platillo>() };

                // Añadir platillos a la comanda
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Platillos disponibles:");
                    for (int i = 0; i < _platillos.Count; i++)
                    {
                        Platillo platillo = _platillos[i];
                        Console.WriteLine($"{i + 1}. {platillo.Nombre} - ${platillo.Precio}");
                    }
                    Console.WriteLine("Seleccione el número del platillo que desea agregar (o escriba '0' para terminar): ");

                    int seleccion = Convert.ToInt32(Console.ReadLine());

                    if (seleccion == 0)
                    {
                        break;
                    }
                    else if (seleccion > 0 && seleccion <= _platillos.Count)
                    {
                        Platillo platilloSeleccionado = _platillos[seleccion - 1];
                        comanda.Platillos.Add(platilloSeleccionado);
                        Console.WriteLine($"Platillo '{platilloSeleccionado.Nombre}' agregado a la comanda.");

                        // Esperar a que el usuario presione una tecla antes de continuar
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Selección inválida. Intente de nuevo.");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                }

                // Agregar comanda a la lista y marcar mesa como ocupada
                _comandas.Add(comanda);
                mesa.Ocupada = true;

                // Mostrar resumen de la comanda
                Console.WriteLine("\nComanda creada con éxito:");
                Console.WriteLine($"Número de Comanda: {comanda.Numero}");
                Console.WriteLine($"Número de Mesa: {comanda.Mesa.Numero}");
                Console.WriteLine("Platillos pedidos:");
                foreach (var platillo in comanda.Platillos)
                {
                    Console.WriteLine($"- {platillo.Nombre} (${platillo.Precio})");
                }
            }
            else
            {
                Console.WriteLine("Mesa no encontrada");
            }
        }



        private static void CerrarComanda()
        {
            Console.Clear();
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
            Console.Clear();
            Console.WriteLine("Disponibilidad de Mesas:");
            foreach (Mesa mesa in _mesas)
            {
                Console.WriteLine($"Número: {mesa.Numero}, Sillas: {mesa.Sillas}, Estado: {mesa.EstadoOcupacion()}");
            }
        }
    }
}