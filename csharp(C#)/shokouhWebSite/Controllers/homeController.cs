
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NuGet.Protocol.Plugins;
using shokouhWebSite.Models;

using System.Linq;



namespace shokouhWebSite.Controllers
{
   
    public class homeController : Controller
    {
       
        
        int userId;
        static int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
        int[] result = (from n in numbers select n).ToArray();
        //[Route("login/{name}")]
        //login(string name) 
      
        [Route("login")]
        public ActionResult login()
        {
            
            return View();
        }
        public ActionResult authentication(string userName, string pass)
        {
            
            
            ViewBag.User = userName;
            ViewBag.Pass = pass;
            if (userName != null && userName == "amir")
            {
                if (pass != null && pass == "123")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.message = "your data is incorroct";
                    return View("error");
                }
            }
            else
            {
                ViewBag.message = "your data is incorroct";
                return View("error");
            }
        }
        
        public ActionResult error()
        {
            return View();
        }
        
        public ActionResult Index()
        {
            ViewBag.license = "شماره ثبت: 480908";
            return View();
        }
        public ActionResult aboutUs()
        {
            return View();
        }
        public ActionResult conectUs()
        {
            return View();
        }
        public ActionResult products()
        {
            return View();
        }
        public ActionResult communicationForm()
        {
            return View();
        }
        [Route("sendMessage")]
        public ActionResult sendMessage(string topic ,string textMessage , int receiver , string email)
        {
            ShokouhContext SContext = new ShokouhContext();
            var message = new CommunicationTable
            {
                Topic = topic,
                TextMessage = textMessage,
                Receiver = receiver,
                SenderEmail = email
            };
            SContext.CommunicationTables.Add(message);
            SContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
