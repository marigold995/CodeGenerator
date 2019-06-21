using System.Web.Mvc;
using System.Web.UI;

namespace _360.Portal.CyberDetection.Controllers
{
    [Authorize]
    [OutputCache(Duration = 0, NoStore = true, Location = OutputCacheLocation.None)]
    public class SecurityAndItPolicyController : Controller
    {
        public ActionResult Index()
        {
            return View("SecurityAndItPolicyList");
        }

        public ActionResult SecurityAndItPolicyList()
        {
            return View();
        }

        public ActionResult SecurityAndItPolicyDetail()
        {
            return View();
        }

        public ActionResult SecurityAndItPolicyCreate()
        {
            return View();
        }

        public ActionResult SecurityAndItPolicyUpdate()
        {
            return View();
        }
    }
}
