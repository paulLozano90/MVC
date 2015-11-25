using System.Security.Principal;

namespace AutenticacionVehiculos.Seguridad
{
    public class PrincipalPersonalizado:IPrincipal
    {
        public bool IsInRole(string role)
        {
            return MiIdentidadPersonalizado.Rol == role;
        }

        public IIdentity Identity { get; private set; }

        public IdentityPersonalizado MiIdentidadPersonalizado
        {
            get { return (IdentityPersonalizado) Identity; }
            set { Identity = value; }
        }

        public PrincipalPersonalizado(IdentityPersonalizado identity)
        {
            Identity = identity;
        }
    }
}