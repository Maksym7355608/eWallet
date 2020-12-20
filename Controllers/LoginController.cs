using eWallet.BLL.Interfaces;
using eWallet.Models;
using System.Web.Mvc;

namespace eWallet.Controllers
{
    public class LoginController : Controller
    {
        private IClientService clientService;

        public LoginController(IClientService service)
        {
            clientService = service;
        }
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult SignIn(string email, string password)
        {
            var clientId = clientService.ValidateClient(email, password);
            if (clientId == null)
                return null;
            
            return RedirectToAction("Getter", "Account", new { id = clientId });
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public void SignUp(ClientViewModel client)
        {
            clientService.CreateClient(new BLL.DTO.PersonalAccountDTO.ClientDTO { Name = client.Name, Surname = client.Surname, Email = client.Email, Password = client.Password });
            Response.Redirect("/Login/SignIn");
        }
    }
}