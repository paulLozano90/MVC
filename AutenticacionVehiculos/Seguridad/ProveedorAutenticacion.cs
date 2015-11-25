using System.Configuration;
using System.Linq;
using System.Web.Security;
using AutenticacionVehiculos.Models;
using AutenticacionVehiculos.Utilidades;

namespace AutenticacionVehiculos.Seguridad
{
    public class ProveedorAutenticacion:MembershipProvider
    {
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
            bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new System.NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new System.NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new System.NotImplementedException();
        }
        //Validar el usuario
        public override bool ValidateUser(string username, string password)
        {
            using (var db = new AutenticacionVehiculosEntities())
            {
                //var clave = ConfigurationManager.AppSettings["ClaveCifrado"];
                //var login = SeguridadUtilidades.Cifrar(username, clave);
                var pass = SeguridadUtilidades.GetSha1(password);

                return db.Usuario.Any(o => o.password == pass && o.login == username);
            }
        }

        public override bool UnlockUser(string userName)
        {
            throw new System.NotImplementedException();
        }
        //Obtiene el usuario
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new System.NotImplementedException();
        }
        //Obtiene el usuario
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            using (var db = new AutenticacionVehiculosEntities())
            {
                //var clave = ConfigurationManager.AppSettings["ClaveCifrado"];
                //var login = SeguridadUtilidades.Cifrar(username, clave);
                var user = db.Usuario.FirstOrDefault(o => o.login == username);

                if (user == null)
                {
                    return null;
                }
                return new UsuarioMembership(user);
            }
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override bool EnablePasswordRetrieval { get; }
        public override bool EnablePasswordReset { get; }
        public override bool RequiresQuestionAndAnswer { get; }
        public override string ApplicationName { get; set; }
        public override int MaxInvalidPasswordAttempts { get; }
        public override int PasswordAttemptWindow { get; }
        public override bool RequiresUniqueEmail { get; }
        public override MembershipPasswordFormat PasswordFormat { get; }
        public override int MinRequiredPasswordLength { get; }
        public override int MinRequiredNonAlphanumericCharacters { get; }
        public override string PasswordStrengthRegularExpression { get; }
    }
}