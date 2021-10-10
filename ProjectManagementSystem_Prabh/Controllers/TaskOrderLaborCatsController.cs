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
    public class TaskOrderLaborCatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TaskOrderLaborCats
        public ActionResult Index()
        {
            var taskOrderLaborCats = db.TaskOrderLaborCats.Include(t => t.TaskOrder);
            return View(taskOrderLaborCats.ToList());
        }

        // GET: TaskOrderLaborCats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskOrderLaborCat taskOrderLaborCat = db.TaskOrderLaborCats.Find(id);
            if (taskOrderLaborCat == null)
            {
                return HttpNotFound();
            }
            return View(taskOrderLaborCat);
        }

        // GET: TaskOrderLaborCats/Create
        public ActionResult Create()
        {
            ViewBag.TaskOrderID = new SelectList(db.TaskOrders, "ID", "Name");
            return View();
        }

        // POST: TaskOrderLaborCats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,TaskOrderID,LaborCategory")] TaskOrderLaborCat taskOrderLaborCat)
        {
            if (ModelState.IsValid)
            {
                db.TaskOrderLaborCats.Add(taskOrderLaborCat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaskOrderID = new SelectList(db.TaskOrders, "ID", "Name", taskOrderLaborCat.TaskOrderID);
            return View(taskOrderLaborCat);
        }

        // GET: TaskOrderLaborCats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskOrderLaborCat taskOrderLaborCat = db.TaskOrderLaborCats.Find(id);
            if (taskOrderLaborCat == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaskOrderID = new SelectList(db.TaskOrders, "ID", "Name", taskOrderLaborCat.TaskOrderID);
            return View(taskOrderLaborCat);
        }

        // POST: TaskOrderLaborCats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,TaskOrderID,LaborCategory")] TaskOrderLaborCat taskOrderLaborCat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskOrderLaborCat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaskOrderID = new SelectList(db.TaskOrders, "ID", "Name", taskOrderLaborCat.TaskOrderID);
            return View(taskOrderLaborCat);
        }

        // GET: TaskOrderLaborCats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskOrderLaborCat taskOrderLaborCat = db.TaskOrderLaborCats.Find(id);
            if (taskOrderLaborCat == null)
            {
                return HttpNotFound();
            }
            return View(taskOrderLaborCat);
        }

        // POST: TaskOrderLaborCats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskOrderLaborCat taskOrderLaborCat = db.TaskOrderLaborCats.Find(id);
            db.TaskOrderLaborCats.Remove(taskOrderLaborCat);
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
