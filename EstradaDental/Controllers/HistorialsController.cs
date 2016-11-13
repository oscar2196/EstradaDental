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
            var historial = db.historial.Include(h => h.cliente);
            return View(historial.ToList());
        }

        // GET: Historials/Details/5
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
        public ActionResult Create(int id)
        {

            ViewBag.clienteID = new SelectList(db.cliente, "clienteID", "nombre");
            return View();
        }

        // POST: Historials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "historialID,comentario,fecha,clienteID")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                db.historial.Add(historial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clienteID = new SelectList(db.cliente, "clienteID", "nombre", historial.clienteID);
            return View(historial);
        }

        // GET: Historials/Edit/5
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
            ViewBag.clienteID = new SelectList(db.cliente, "clienteID", "nombre", historial.clienteID);
            return View(historial);
        }

        // POST: Historials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "historialID,comentario,fecha,clienteID")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clienteID = new SelectList(db.cliente, "clienteID", "nombre", historial.clienteID);
            return View(historial);
        }

        // GET: Historials/Delete/5
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
