using ProjectOne_Missions.DAL;
using ProjectOne_Missions.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
namespace ProjectOne_Missions.Controllers
{
    public class MissionsController : Controller
    {
        private static MissionContext db = new MissionContext();



        // GET: Mission
        [HttpGet]
        public ActionResult Index()
        {

            ViewBag.Missions = db.Missions.ToList();
            return View();
        }

        
        [HttpPost]
        public ActionResult Index(Missions myMission)
        {
            int M_ID = myMission.MissionID;
            Missions searchMission = db.Missions.Find(M_ID);
                //lstMissions.Find(x => x.MissionID == myMission.MissionID);
            ViewBag.Search = searchMission;
            Session["M_ID"] = M_ID;

            return RedirectToAction("Missions", searchMission);
        }

        [HttpPost]
        public ActionResult Reply()
        {
            
            return RedirectToAction("Missions");
        }

        
        public ActionResult Missions(Missions myMission)
        {
            
            return View(myMission);
        }


        




    }
}