using Microsoft.AspNetCore.Mvc;

namespace RelianceTdsCertificate.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Upload()
        {
            return View();
        }
    }
}
