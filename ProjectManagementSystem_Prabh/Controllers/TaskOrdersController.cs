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
    public class TaskOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TaskOrders
        public ActionResult Index()
        {
            var taskOrders = db.TaskOrders.Include(t => t.Contract);
            return View(taskOrders.ToList());
        }

        // GET: TaskOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskOrder taskOrder = db.TaskOrders.Find(id);
            if (taskOrder == null)
            {
                return HttpNotFound();
            }
            return View(taskOrder);
        }

        // GET: TaskOrders/Create
        public ActionResult Create()
        {
            ViewBag.ContractID = new SelectList(db.Contracts, "ID", "Name");
            return View();
        }

        // POST: TaskOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ContractID,Code")] TaskOrder taskOrder)
        {
            if (ModelState.IsValid)
            {
                db.TaskOrders.Add(taskOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContractID = new SelectList(db.Contracts, "ID", "Name", taskOrder.ContractID);
            return View(taskOrder);
        }

        // GET: TaskOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskOrder taskOrder = db.TaskOrders.Find(id);
            if (taskOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractID = new SelectList(db.Contracts, "ID", "Name", taskOrder.ContractID);
            return View(taskOrder);
        }

        // POST: TaskOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ContractID,Code")] TaskOrder taskOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractID = new SelectList(db.Contracts, "ID", "Name", taskOrder.ContractID);
            return View(taskOrder);
        }

        // GET: TaskOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskOrder taskOrder = db.TaskOrders.Find(id);
            if (taskOrder == null)
            {
                return HttpNotFound();
            }
            return View(taskOrder);
        }

        // POST: TaskOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskOrder taskOrder = db.TaskOrders.Find(id);
            db.TaskOrders.Remove(taskOrder);
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
