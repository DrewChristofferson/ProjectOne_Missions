using ProjectOne_Missions.DAL;
using ProjectOne_Missions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectOne_Missions.Controllers
{

    public class HomeController : Controller
    {
        private MissionContext db = new MissionContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password, bool rememberMe = false)
        {
            IEnumerable<Users> currentUser = db.Database.SqlQuery<Users>(
                "Select * " +
                "FROM [Users] " +
                "WHERE UserEmail = '" + email + "' AND " +
                "Password = '" + password + "'");

            if (currentUser.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);

                var min = currentUser.Min();
                ViewBag.james = min;
                Session["UserID"] = min.UserID;
                return RedirectToAction("Index", "Missions");

            }
            else
            {
                return View();
            }
            
        }


        public ActionResult SignUp()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Users newUser)
        {
            db.Users.Add(newUser);
            db.SaveChanges();
            return RedirectToAction("Index", "Missions");
            
        }


    }
}