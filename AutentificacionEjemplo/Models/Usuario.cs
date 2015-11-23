using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutentificacionEjemplo.Models
{
    public class Usuario
    {
        [DisplayName("Nombre de usuario:")]
        public string Login { get; set; }
        [DisplayName("Contraseña:")]
        public string Password { get; set; }
    }
}