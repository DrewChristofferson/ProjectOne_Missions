using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectOne_Missions.DAL;
using ProjectOne_Missions.Models;

namespace ProjectOne_Missions.Controllers
{
    public class MissionQuestionsController : Controller
    {
        private MissionContext db = new MissionContext();

        public static int M_ID = 0;
       
        [Authorize]
        // GET: MissionQuestions
        public ActionResult Index()
        {
            var id = Session["M_ID"];
            M_ID = Convert.ToInt32(id);
            var missionQuestions = db.MissionQuestions.Include(m => m.Missions).Include(m => m.Users);
            var thisMission = db.MissionQuestions.Where(d => d.MissionID == M_ID).ToList();

            return View(thisMission);
        }

        // GET: MissionQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestions);
        }

        // GET: MissionQuestions/Create
        public ActionResult Create()
        {
            ViewBag.MissionID = new SelectList(db.Missions, "MissionID", "MissionName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserFName");
            return View();
        }

        // POST: MissionQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MissionQ_ID,Question,Answer,MissionID,UserID")] MissionQuestions missionQuestions)
        {
            if (ModelState.IsValid)
            {
                missionQuestions.MissionID = M_ID;
                var id = Session["UserID"];
                int U_ID = Convert.ToInt32(id);
                if (string.IsNullOrEmpty(U_ID.ToString()) || U_ID == 0)
                {
                    missionQuestions.UserID = 1;
                }
                else
                {
                    missionQuestions.UserID = U_ID;

                }

                db.MissionQuestions.Add(missionQuestions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MissionID = new SelectList(db.Missions, "MissionID", "MissionName", missionQuestions.MissionID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserFName", missionQuestions.UserID);
            return View(missionQuestions);
        }

        // GET: MissionQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            ViewBag.MissionID = new SelectList(db.Missions, "MissionID", "MissionName", missionQuestions.MissionID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserFName", missionQuestions.UserID);
            return View(missionQuestions);
        }

        // POST: MissionQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MissionQ_ID,Question,Answer,MissionID,UserID")] MissionQuestions missionQuestions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missionQuestions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MissionID = new SelectList(db.Missions, "MissionID", "MissionName", missionQuestions.MissionID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserFName", missionQuestions.UserID);
            return View(missionQuestions);
        }

        // GET: MissionQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestions);
        }

        // POST: MissionQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
            db.MissionQuestions.Remove(missionQuestions);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
