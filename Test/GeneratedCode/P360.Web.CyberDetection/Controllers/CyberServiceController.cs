using System.Web.Mvc;
using System.Web.UI;

namespace _360.Portal.CyberDetection.Controllers
{
    [Authorize]
    [OutputCache(Duration = 0, NoStore = true, Location = OutputCacheLocation.None)]
    public class CyberServiceController : Controller
    {
        public ActionResult Index()
        {
            return View("CyberServiceList");
        }

        public ActionResult CyberServiceList()
        {
            return View();
        }

        public ActionResult CyberServiceDetail()
        {
            return View();
        }

        public ActionResult CyberServiceCreate()
        {
            return View();
        }

        public ActionResult CyberServiceUpdate()
        {
            return View();
        }
    }
}
