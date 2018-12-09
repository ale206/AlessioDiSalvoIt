using System.Web.Mvc;

namespace TaechIdeas.Alessiodisalvo.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nav()
        {
            return View();
        }
    }
}