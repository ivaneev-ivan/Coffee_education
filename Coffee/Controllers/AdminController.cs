using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Pages/Admin/Index.cshtml");
        }

        public ActionResult Users()
        {
            return View("~/Pages/Admin/Users.cshtml");
        }
    }
}