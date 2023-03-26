using System;

namespace Entidades
{
    public class Usuario
    {
        public string CodigoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Rol { get; set; }
        public byte[] Foto { get; set; }
        public bool EstaActivo { get; set; }

        public Usuario()
        {
        }

        public Usuario(string codigoUsuario, string nombre, string contraseña, string correo, DateTime fechaCreacion, string rol, byte[] foto, bool estaActivo)
        {
            CodigoUsuario = codigoUsuario;
            Nombre = nombre;
            Contraseña = contraseña;
            Correo = correo;
            FechaCreacion = fechaCreacion;
            Rol = rol;
            Foto = foto;
            EstaActivo = estaActivo;
        }
    }
}
