using System;

namespace Entidades
{
    public class Cliente
    {
        public string Identidad { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public DateTime Fecha { get; set; }
        public string TipoSoporte { get; set; }
        public string DescripcionSoporte { get; set; }

        public Cliente()
        {
        }

        public Cliente(string identidad, string nombre, string telefono, string direccion, DateTime fecha, string tipoSoporte, string descripcionSoporte)
        {
            Identidad = identidad;
            Nombre = nombre;
            Telefono = telefono;
            Direccion = direccion;
            Fecha = fecha;
            TipoSoporte = tipoSoporte;
            DescripcionSoporte = descripcionSoporte;
        }
    }
}
