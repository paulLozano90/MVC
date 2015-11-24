using System;
using System.Configuration;
using System.Web.Security;
using AutenticacionPractica.Models;
using AutenticacionPractica.Utilidades;

namespace AutenticacionPractica.Seguridad
{
    public class UsuarioMembership:MembershipUser
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string imagen { get; set; }
        public override String Email { get; set; }
        public String Rol { get; set; }

        public UsuarioMembership(Usuario us)
        {
            var clave = ConfigurationManager.AppSettings["ClaveCifrado"];
            id = us.id;
            nombre = us.nombre;
            apellidos = us.apellidos;
            imagen = us.imagen;
            Rol = us.Rol.nombre;
            //Se convierte a un string y de descrifra
            Email = SeguridadUtilidades.DesCifrar(Convert.FromBase64String(us.email), clave);
            login = us.login;
        }
    }
}