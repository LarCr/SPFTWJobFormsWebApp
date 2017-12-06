using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SPFTWJobFormsWebApp.Models;

namespace SPFTWJobFormsWebApp.Controllers
{
    public class EngineersController : Controller
    {
        private SPFTWDatabaseEntities db = new SPFTWDatabaseEntities();

        // GET: Engineers
        public ActionResult Index()
        {
            return View(db.Engineers.ToList());
        }

        // GET: Engineers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engineer engineer = db.Engineers.Find(id);
            if (engineer == null)
            {
                return HttpNotFound();
            }
            return View(engineer);
        }

        // GET: Engineers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Engineers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EngID,EngFname,EngSname,EngPhone,EngEmail")] Engineer engineer)
        {
            if (ModelState.IsValid)
            {
                db.Engineers.Add(engineer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(engineer);
        }

        // GET: Engineers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engineer engineer = db.Engineers.Find(id);
            if (engineer == null)
            {
                return HttpNotFound();
            }
            return View(engineer);
        }

        // POST: Engineers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EngID,EngFname,EngSname,EngPhone,EngEmail")] Engineer engineer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(engineer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(engineer);
        }

        // GET: Engineers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engineer engineer = db.Engineers.Find(id);
            if (engineer == null)
            {
                return HttpNotFound();
            }
            return View(engineer);
        }

        // POST: Engineers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Engineer engineer = db.Engineers.Find(id);
            db.Engineers.Remove(engineer);
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
