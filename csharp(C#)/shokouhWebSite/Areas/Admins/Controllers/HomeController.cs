using Microsoft.AspNetCore.Mvc;
using shokouhWebSite.Models;

namespace shokouhWebSite.Areas.Admins.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admins") , Route("Index")]
        public ActionResult Index()
        {
            return View();
        }
        [Area("Admins")]
        public ActionResult login()
        {
            return View();
        }
        [Area("Admins")]
        public ActionResult authentication(string userName, string pass) 
        {
            ShokouhContext context = new ShokouhContext();
            if (context.Admins.Any(u => u.Username == userName && u.Password == pass))
            { 
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("login");
            }
            
            
        }
    }
}
