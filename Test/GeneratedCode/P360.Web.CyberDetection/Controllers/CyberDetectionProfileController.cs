





using System.Web.Mvc;
using System.Web.UI;

namespace _360.Portal.CyberDetection.Controllers
{
    [Authorize]
    [OutputCache(Duration = 0, NoStore = true, Location = OutputCacheLocation.None)]
    public class CyberDetectionProfileController : Controller
    {
        public ActionResult Index()
        {
            return View("CyberDetectionProfileList");
        }

        public ActionResult CyberDetectionProfileList()
        {
            return View();
        }

        public ActionResult CyberDetectionProfileDetail()
        {
            return View();
        }

        public ActionResult CyberDetectionProfileCreate()
        {
            return View();
        }

        public ActionResult CyberDetectionProfileUpdate()
        {
            return View();
        }
    }
}

