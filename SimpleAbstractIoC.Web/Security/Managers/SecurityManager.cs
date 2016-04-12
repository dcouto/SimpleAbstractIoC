using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SimpleAbstractIoC.Web.Data.DbContexts;
using Sitecore.Security.Accounts;
using Sitecore.Security.Authentication;

namespace SimpleAbstractIoC.Web.Security.Managers
{
    public class SecurityManager : ISecurityManager
    {
        public bool AuthenticateUser(string email, string password)
        {
            var hashedPassword = GetHashedPassword(password);

            using (var db = new CustomMembershipContext())
            {
                var matchingUser = db.Users.FirstOrDefault(i => i.Email == email && i.Password == password);

                if (matchingUser != null)
                {
                    var virtualUser = AuthenticationManager.BuildVirtualUser(email, true);

                    virtualUser.Roles.Add(Role.FromName("extranet\\Simple IoC Logged In Users"));
                    
                    virtualUser.Profile.Email = email;
                    virtualUser.Profile.Name = string.Format("{0} {1}", matchingUser.FirstName, matchingUser.LastName);

                    return AuthenticationManager.LoginVirtualUser(virtualUser);
                }
            }

            return false;
        }

        private string GetHashedPassword(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);

            data = new SHA512Managed().ComputeHash(data);

            return Encoding.ASCII.GetString(data);
        }
    }
}
