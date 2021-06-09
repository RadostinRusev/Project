using ProjMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjMVC.Controllers
{
    public class UUsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            List<UserVM> userVMs = new List<UserVM>();

            using(SoapService.Service1Client service = new SoapService.Service1Client())
            {
                foreach(var item in service.GetUser())
                {
                    userVMs.Add(new UserVM(item));
                }

            }
            return View(userVMs);
        }
    }
}