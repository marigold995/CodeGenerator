using System.Web.Mvc;
using System.Web.UI;

namespace _360.Portal.CyberDetection.Controllers
{
    [Authorize]
    [OutputCache(Duration = 0, NoStore = true, Location = OutputCacheLocation.None)]
    public class ZoneProfileController : Controller
    {
        public ActionResult Index()
        {
            return View("ZoneProfileList");
        }

        public ActionResult ZoneProfileList()
        {
            return View();
        }

        public ActionResult ZoneProfileDetail()
        {
            return View();
        }

        public ActionResult ZoneProfileCreate()
        {
            return View();
        }

        public ActionResult ZoneProfileUpdate()
        {
            return View();
        }
    }
}
