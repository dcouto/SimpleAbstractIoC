using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using SimpleAbstractIoC.Web.Security.Managers;
using SimpleAbstractIoC.Web.ViewModels.Security;

namespace SimpleAbstractIoC.Web.Controllers.Security
{
    public class LoginController : Controller
    {
        private readonly ISecurityManager _securityManager;

        public LoginController(ISecurityManager securityManager)
        {
            _securityManager = securityManager;
        }

        // GET: Login
        public ActionResult Index()
        {
            var vm = new LoginViewModel();

            vm.ErrorMessage = Session["Login.ErrorMessage"] != null ? Session["Login.ErrorMessage"].ToString() : "";

            return View("~/Views/SimpleIoC/Renderings/Security/Login.cshtml", vm);
        }

        [HttpPost]
        public RedirectResult Login(LoginViewModel vm)
        {
            var success = _securityManager.AuthenticateUser(vm.Email, vm.Password);

            if (success)
            {
                if (Request.UrlReferrer != null)
                {
                    var parsedQS = ParseQueryString(Request.UrlReferrer.Query);

                    return Redirect(parsedQS["returnUrl"]);
                }
            }

            return Redirect(Request.RawUrl);
        }

        private NameValueCollection ParseQueryString(string qs)
        {
            return HttpUtility.ParseQueryString(qs);
        }
    }
}