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
    public class ContractCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContractCategories
        public ActionResult Index()
        {
            var contractCategories = db.ContractCategories.Include(c => c.Contract);
            return View(contractCategories.ToList());
        }

        // GET: ContractCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractCategory contractCategory = db.ContractCategories.Find(id);
            if (contractCategory == null)
            {
                return HttpNotFound();
            }
            return View(contractCategory);
        }

        // GET: ContractCategories/Create
        public ActionResult Create()
        {
            ViewBag.ContractID = new SelectList(db.Contracts, "ID", "Name");
            return View();
        }

        // POST: ContractCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ContractID")] ContractCategory contractCategory)
        {
            if (ModelState.IsValid)
            {
                db.ContractCategories.Add(contractCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContractID = new SelectList(db.Contracts, "ID", "Name", contractCategory.ContractID);
            return View(contractCategory);
        }

        // GET: ContractCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractCategory contractCategory = db.ContractCategories.Find(id);
            if (contractCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractID = new SelectList(db.Contracts, "ID", "Name", contractCategory.ContractID);
            return View(contractCategory);
        }

        // POST: ContractCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ContractID")] ContractCategory contractCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contractCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractID = new SelectList(db.Contracts, "ID", "Name", contractCategory.ContractID);
            return View(contractCategory);
        }

        // GET: ContractCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractCategory contractCategory = db.ContractCategories.Find(id);
            if (contractCategory == null)
            {
                return HttpNotFound();
            }
            return View(contractCategory);
        }

        // POST: ContractCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContractCategory contractCategory = db.ContractCategories.Find(id);
            db.ContractCategories.Remove(contractCategory);
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
