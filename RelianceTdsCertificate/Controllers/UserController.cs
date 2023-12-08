using Microsoft.AspNetCore.Mvc;

namespace RelianceTdsCertificate.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Download()
        {
            return View();
        }
    }
}
