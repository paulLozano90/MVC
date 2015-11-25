using System;
using System.Configuration;
using System.Linq;
using System.Web.Security;
using AutenticacionVehiculos.Models;
using AutenticacionVehiculos.Utilidades;

namespace AutenticacionVehiculos.Seguridad
{
    public class ProveedorRol : RoleProvider {

        //Indica si un usuario tiene un rol determinado
        public override bool IsUserInRole(string username, string roleName)
        {
            //var clave = ConfigurationManager.AppSettings["ClaveCifrado"];
            //var cif = SeguridadUtilidades.Cifrar(username, clave);

            using (var db = new AutenticacionVehiculosEntities())
            {
                try
                {
                    var us = db.Usuario.First(o => o.login == username);
                    return us.Rol.nombre == roleName;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        //Muestra los roles de un usuario
        public override string[] GetRolesForUser(string username)
        {
            //var clave = ConfigurationManager.AppSettings["ClaveCifrado"];
            //var cif = SeguridadUtilidades.Cifrar(username, clave);

            using (var db = new AutenticacionVehiculosEntities())
            {
                try
                {
                    var us = db.Usuario.First(o => o.login == username);
                    return new[] {us.Rol.nombre};
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }
        //Verificar si exite
        public override bool RoleExists(string roleName)
        {
            throw new System.NotImplementedException();
        }
        //Añadir usuarios a roles
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }
        //Eliminar usuarios de roles
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }
        //
        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }
        //Conocer todos los roles
        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }
        //Buscar usuarios de un rol
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}