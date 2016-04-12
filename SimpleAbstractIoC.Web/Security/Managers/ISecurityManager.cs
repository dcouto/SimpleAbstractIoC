namespace SimpleAbstractIoC.Web.Security.Managers
{
    public interface ISecurityManager
    {
        bool AuthenticateUser(string email, string password); 
    }
}