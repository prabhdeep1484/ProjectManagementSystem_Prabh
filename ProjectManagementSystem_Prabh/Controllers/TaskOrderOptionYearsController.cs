using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagementSystem_Prabh.Models;

namespace ProjectManagementSystem_Prabh.Controllers
{
    public class TaskOrderOptionYearsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TaskOrderOptionYears
        public ActionResult Index()
        {
            var taskOrderOptionYears = db.TaskOrderOptionYears.Include(t => t.TaskOrder);
            return View(taskOrderOptionYears.ToList());
        }

        // GET: TaskOrderOptionYears/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskOrderOptionYear taskOrderOptionYear = db.TaskOrderOptionYears.Find(id);
            if (taskOrderOptionYear == null)
            {
                return HttpNotFound();
            }
            return View(taskOrderOptionYear);
        }

        // GET: TaskOrderOptionYears/Create
        public ActionResult Create()
        {
            ViewBag.TaskOrderID = new SelectList(db.TaskOrders, "ID", "Name");
            return View();
        }

        // POST: TaskOrderOptionYears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,TaskOrderID,LaborCategory,StartDate,EndDate")] TaskOrderOptionYear taskOrderOptionYear)
        {
            if (ModelState.IsValid)
            {
                db.TaskOrderOptionYears.Add(taskOrderOptionYear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaskOrderID = new SelectList(db.TaskOrders, "ID", "Name", taskOrderOptionYear.TaskOrderID);
            return View(taskOrderOptionYear);
        }

        // GET: TaskOrderOptionYears/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskOrderOptionYear taskOrderOptionYear = db.TaskOrderOptionYears.Find(id);
            if (taskOrderOptionYear == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaskOrderID = new SelectList(db.TaskOrders, "ID", "Name", taskOrderOptionYear.TaskOrderID);
            return View(taskOrderOptionYear);
        }

        // POST: TaskOrderOptionYears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,TaskOrderID,LaborCategory,StartDate,EndDate")] TaskOrderOptionYear taskOrderOptionYear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskOrderOptionYear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaskOrderID = new SelectList(db.TaskOrders, "ID", "Name", taskOrderOptionYear.TaskOrderID);
            return View(taskOrderOptionYear);
        }

        // GET: TaskOrderOptionYears/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskOrderOptionYear taskOrderOptionYear = db.TaskOrderOptionYears.Find(id);
            if (taskOrderOptionYear == null)
            {
                return HttpNotFound();
            }
            return View(taskOrderOptionYear);
        }

        // POST: TaskOrderOptionYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskOrderOptionYear taskOrderOptionYear = db.TaskOrderOptionYears.Find(id);
            db.TaskOrderOptionYears.Remove(taskOrderOptionYear);
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
