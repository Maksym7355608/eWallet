using System.Web.Mvc;

namespace eWallet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //[Route("aboutus")]
        public ActionResult About()
        {
            return View();
        }
    }
}