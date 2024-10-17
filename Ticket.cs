using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante2._0
{
    public class Ticket
    {
        public static string GenerarTicket(Comanda comanda)
        {
            if (comanda == null)
                throw new ArgumentNullException(nameof(comanda), "La comanda no puede ser nula.");

            StringBuilder ticket = new StringBuilder();
            ticket.AppendLine("***** RESTAURANTE *****");
            ticket.AppendLine("      TICKET DE COMANDA      ");
            ticket.AppendLine("*****************************");
            ticket.AppendLine($"Número de Comanda: {comanda.Numero}");
            ticket.AppendLine($"Mesa: {comanda.Mesa.Numero}");
            ticket.AppendLine($"Fecha y Hora: {comanda.FechaHora.ToString("dd/MM/yyyy HH:mm")}");
            ticket.AppendLine("Platillos:");
            ticket.AppendLine("-----------------------------");

            foreach (var platillo in comanda.Platillos)
            {
                ticket.AppendLine($"- {platillo.Nombre,-30} ({platillo.Precio:C})");
            }

            ticket.AppendLine("-----------------------------");
            ticket.AppendLine($"Total: {CalcularTotal(comanda.Platillos):C}");
            ticket.AppendLine("*****************************");
            ticket.AppendLine("¡Gracias por su visita!");
            ticket.AppendLine("*****************************");
            return ticket.ToString();
        }

        private static decimal CalcularTotal(List<Platillo> platillos)
        {
            decimal total = 0;
            foreach (var platillo in platillos)
            {
                total += platillo.Precio;
            }
            return total;
        }
    }
}