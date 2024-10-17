using System;
using System.Collections.Generic;

namespace Restaurante2._0
{
    public class Program
    {
        private static List<Mesa> _mesas = new List<Mesa>();
        private static List<Comanda> _comandas = new List<Comanda>();
        private static List<Platillo> _platillos = new List<Platillo>();
        private static int ultimoNumeroComanda = 0;

        public static void Main(string[] args)
        {
            IniciarSistema();
        }

        private static void IniciarSistema()
        {
            while (true)
            {
                MostrarMenuPrincipal();
                if (!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 1 || opcion > 6)
                {
                    MostrarMensaje("Opción inválida. Inténtelo de nuevo.");
                    continue;
                }

                Console.Clear();
                Console.WriteLine($"Opción seleccionada: {opcion}");
                switch (opcion)
                {
                    case 1: GestionarMenu(); break;
                    case 2: GestionarMesasYSillas(); break;
                    case 3: CrearComanda(); break;
                    case 4: VerDisponibilidadMesas(); break;
                    case 5: GenerarTicket(); break;
                    case 6: return;
                }
            }
        }

        private static void MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine("      Sistema de Gestión de Restaurante      ");
            Console.WriteLine("=============================================");
            Console.WriteLine("1. Gestionar Menú");
            Console.WriteLine("2. Gestionar Mesas y Sillas");
            Console.WriteLine("3. Crear Comanda");
            Console.WriteLine("4. Ver Disponibilidad de Mesas");
            Console.WriteLine("5. Generar Ticket");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
        }

        private static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void GestionarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("============ Gestionar Menú ============\n");
                Console.WriteLine("1. Agregar Platillo");
                Console.WriteLine("2. Quitar Platillo");
                Console.WriteLine("3. Ver Platillos");
                Console.WriteLine("4. Regresar");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion) && opcion >= 1 && opcion <= 4)
                {
                    Console.Clear();
                    switch (opcion)
                    {
                        case 1: AgregarPlatillo(); break;
                        case 2: QuitarPlatillo(); break;
                        case 3: VerPlatillos(); break;
                        case 4: return;
                    }
                }
                else
                {
                    MostrarMensaje("Opción inválida. Inténtelo de nuevo.");
                }
            }
        }

        private static void AgregarPlatillo()
        {
            Console.Clear();
            Console.WriteLine("==== Agregar Platillo ====\n");

            string nombre = LeerEntrada("Ingrese el nombre del platillo: ");
            string descripcion = LeerEntrada("Ingrese la descripción del platillo: ");
            string categoria = LeerEntrada("Ingrese la categoría del platillo: ");
            decimal precio = LeerDecimal("Ingrese el precio del platillo: ");

            Platillo platillo = new Platillo
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Categoria = categoria,
                Precio = precio
            };

            _platillos.Add(platillo);

            Console.WriteLine($"Platillo agregado: {platillo.Nombre} - {platillo.Descripcion} - {platillo.Categoria} - {platillo.Precio:C}");
            Console.WriteLine($"Total de platillos después de agregar: {_platillos.Count}");

            MostrarMensaje("¡Platillo agregado con éxito!");
        }



        private static void QuitarPlatillo()
        {
            Console.Clear();
            Console.WriteLine("==== Quitar Platillo ====\n");

            string nombre = LeerEntrada("Ingrese el nombre del platillo a quitar: ");
            Platillo platillo = _platillos.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (platillo != null)
            {
                _platillos.Remove(platillo);
                MostrarMensaje("¡Platillo quitado con éxito!");
            }
            else
            {
                MostrarMensaje("Platillo no encontrado.");
            }
        }

        private static void VerPlatillos()
        {
            Console.Clear();
            Console.WriteLine("==== Lista de Platillos ====\n");
            Console.WriteLine($"Total de platillos: {_platillos.Count}");

            if (_platillos.Count > 0)
            {
                foreach (Platillo platillo in _platillos)
                {
                    Console.WriteLine($"Nombre: {platillo.Nombre}");
                    Console.WriteLine($"Descripción: {platillo.Descripcion}");
                    Console.WriteLine($"Categoría: {platillo.Categoria}");
                    Console.WriteLine($"Precio: {platillo.Precio:C}\n");
                }
            }
            else
            {
                Console.WriteLine("No hay platillos en el menú.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }



        private static void GestionarMesasYSillas()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Gestionar Mesas y Sillas ====\n");
                Console.WriteLine("1. Agregar Mesa");
                Console.WriteLine("2. Quitar Mesa");
                Console.WriteLine("3. Ver Mesas");
                Console.WriteLine("4. Regresar");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion) && opcion >= 1 && opcion <= 4)
                {
                    Console.Clear();
                    switch (opcion)
                    {
                        case 1: AgregarMesa(); break;
                        case 2: QuitarMesa(); break;
                        case 3: VerMesas(); break;
                        case 4: return;
                    }
                }
                else
                {
                    MostrarMensaje("Opción inválida. Inténtelo de nuevo.");
                }
            }
        }

        private static void AgregarMesa()
        {
            Console.Clear();
            Console.WriteLine("==== Agregar Mesa ====\n");

            int cantidadMesas = LeerEntero("Ingrese el número de mesas a agregar: ");
            for (int i = 1; i <= cantidadMesas; i++)
            {
                int sillasPorMesa = LeerEntero($"Ingrese el número de sillas para la mesa {i}: ");
                Mesa mesa = new Mesa { Numero = _mesas.Count + 1, Sillas = sillasPorMesa, Ocupada = false };
                _mesas.Add(mesa);
                Console.WriteLine($"Mesa {mesa.Numero} con {sillasPorMesa} sillas agregada con éxito. Total de mesas ahora: {_mesas.Count}\n");
            }

            
            Console.WriteLine("Mesas agregadas con éxito. Presione cualquier tecla para continuar...");
            Console.ReadKey();  
        }



        private static void QuitarMesa()
        {
            Console.Clear();
            Console.WriteLine("==== Quitar Mesa ====\n");

            int numeroMesa = LeerEntero("Ingrese el número de la mesa a quitar: ");
            Mesa mesa = _mesas.Find(m => m.Numero == numeroMesa);
            if (mesa != null)
            {
                _mesas.Remove(mesa);
                MostrarMensaje("¡Mesa quitada con éxito!");
            }
            else
            {
                MostrarMensaje("Mesa no encontrada.");
            }
        }

        private static void VerMesas()
        {
            Console.Clear();
            Console.WriteLine("==== Lista de Mesas ====\n");

            if (_mesas.Count > 0)
            {
                foreach (Mesa mesa in _mesas)
                {
                    Console.WriteLine($"Número: {mesa.Numero}");
                    Console.WriteLine($"Sillas: {mesa.Sillas}");
                    Console.WriteLine($"Estado: {mesa.EstadoOcupacion()}\n");
                }
            }
            else
            {
                MostrarMensaje("No hay mesas registradas.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void CrearComanda()
        {
            Console.Clear();
            Console.WriteLine("==== Crear Comanda ====\n");

            int numeroMesa = LeerEntero("Ingrese el número de la mesa: ");
            Mesa mesa = _mesas.Find(m => m.Numero == numeroMesa);
            if (mesa != null)
            {
                List<Platillo> platillosSeleccionados = new List<Platillo>();
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("==== Seleccionar Platillos ====\n");
                    for (int i = 0; i < _platillos.Count; i++)
                    {
                        Platillo platillo = _platillos[i];
                        Console.WriteLine($"{i + 1}. {platillo.Nombre} - ${platillo.Precio}");
                    }

                    Console.Write("\nSeleccione el número del platillo que desea agregar (o escriba '0' para terminar): ");
                    string seleccionInput = Console.ReadLine();
                    int seleccion;

                    if (int.TryParse(seleccionInput, out seleccion))
                    {
                        if (seleccion == 0)
                        {
                            break;
                        }
                        else if (seleccion > 0 && seleccion <= _platillos.Count)
                        {
                            Platillo platilloSeleccionado = _platillos[seleccion - 1];
                            platillosSeleccionados.Add(platilloSeleccionado);
                            Console.WriteLine($"\n{platilloSeleccionado.Nombre} agregado a la comanda.\n");
                        }
                        else
                        {
                            MostrarMensaje("Selección inválida.");
                        }
                    }
                    else
                    {
                        MostrarMensaje("Entrada inválida. Por favor, ingrese un número válido.");
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

                ultimoNumeroComanda++;
                Comanda comanda = new Comanda(mesa, platillosSeleccionados, ultimoNumeroComanda);
                _comandas.Add(comanda);
                mesa.Ocupada = true;
                MostrarMensaje("¡Comanda creada con éxito!");
            }
            else
            {
                MostrarMensaje("Mesa no encontrada.");
            }
        }

        private static void VerDisponibilidadMesas()
        {
            Console.Clear();
            Console.WriteLine("==== Disponibilidad de Mesas ====\n");

            if (_mesas.Count > 0)
            {
                foreach (Mesa mesa in _mesas)
                {
                    Console.WriteLine($"Mesa {mesa.Numero}: {mesa.EstadoOcupacion()}\n");
                }
            }
            else
            {
                Console.WriteLine("No hay mesas registradas.");
            }

            
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void GenerarTicket()
        {
            Console.Clear();
            Console.WriteLine("==== Generar Ticket ====\n");

            if (_comandas.Count == 0)
            {
                MostrarMensaje("No hay comandas disponibles.");
                return;
            }

            
            for (int i = 0; i < _comandas.Count; i++)
            {
                Comanda comanda = _comandas[i];
                Console.WriteLine($"{i + 1}. Comanda #{comanda.Numero} - Mesa {comanda.Mesa.Numero}");
            }

            
            Console.Write("\nSeleccione el número de la comanda para generar el ticket: ");
            string input = Console.ReadLine();

            
            if (int.TryParse(input, out int seleccion) && seleccion > 0 && seleccion <= _comandas.Count)
            {
                Comanda comandaSeleccionada = _comandas[seleccion - 1];

                
                string ticket = Ticket.GenerarTicket(comandaSeleccionada);

                
                Console.Clear();
                Console.WriteLine("==== Ticket Generado ====\n");
                Console.WriteLine(ticket);  
            }
            else
            {
                MostrarMensaje("Selección inválida.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static string LeerEntrada(string mensaje)
        {
            Console.Write(mensaje);
            return Console.ReadLine();
        }

        private static decimal LeerDecimal(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (decimal.TryParse(Console.ReadLine(), out decimal valor))
                {
                    return valor;
                }
                else
                {
                    MostrarMensaje("El valor ingresado no es un número válido. Intente nuevamente.");
                }
            }
        }

        private static int LeerEntero(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out int valor) && valor > 0)
                {
                    return valor;
                }
                else
                {
                    MostrarMensaje("El valor ingresado no es un número entero positivo. Intente nuevamente.");
                }
            }
        }
    }
}