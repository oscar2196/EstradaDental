using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EstradaDental.Models;

namespace EstradaDental.Controllers
{
    public class HistorialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Historials
        public ActionResult Index()
        {
            return View(db.historial.ToList());
        }

        // GET: Historials/Details/5
        [Authorize(Roles ="User, Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial historial = db.historial.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
        }

        // GET: Historials/Create
        [Authorize(Roles ="User, Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Historials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles ="User, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "historialID,comentario,fecha,clienteID")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                db.historial.Add(historial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historial);
        }

        // GET: Historials/Edit/5
        [Authorize(Roles ="User, Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial historial = db.historial.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
        }

        // POST: Historials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles ="User,Amin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "historialID,comentario,fecha,clienteID")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historial);
        }

        // GET: Historials/Delete/5
        [Authorize(Roles ="Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial historial = db.historial.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
        }

        // POST: Historials/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles ="Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historial historial = db.historial.Find(id);
            db.historial.Remove(historial);
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
