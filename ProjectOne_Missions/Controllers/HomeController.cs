using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectOne_Missions.Controllers
{
    public class HomeController : Controller
    {
        public static List<string> myList = new List<string>();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

    }
}