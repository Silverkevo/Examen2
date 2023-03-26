using System;

namespace Entidades
{
    public class DetalleTicket
    {

        public int Id { get; set; }
        public int IdTicket { get; set; }
        public DateTime FechaTicket { get; set; }
        public string TipoTicket { get; set; }

        public string DescripcionSolicitud { get; set; }
        public string Respuesta { get; set; }

        public decimal Precio { get; set; }
        public decimal Total { get; set; }

        public DetalleTicket()
        {
        }

        public DetalleTicket(int id, int idTicket, DateTime fechaTicket, string tipoTicket, string descripcionSolicitud, string respuesta, decimal precio, decimal total)
        {
            Id = id;
            IdTicket = idTicket;
            FechaTicket = fechaTicket;
            TipoTicket = tipoTicket;
            DescripcionSolicitud = descripcionSolicitud;
            Respuesta = respuesta;
            Precio = precio;
            Total = total;
        }
    }
}
