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
    public class CitasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Citas
        public ActionResult Index()
        {

            var cita = db.cita.Include(c => c.cliente).Include(c => c.doctor);
            return View(cita.ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.clienteID = new SelectList(db.cliente, "clienteID", "nombre");
            ViewBag.doctorID = new SelectList(db.doctor, "doctorID", "nombre");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "citaID,confirmacion,fechaIn,fechaOut,doctorID,clienteID,comentario")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.cita.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clienteID = new SelectList(db.cliente, "clienteID", "nombre", cita.clienteID);
            ViewBag.doctorID = new SelectList(db.doctor, "doctorID", "nombre", cita.doctorID);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.clienteID = new SelectList(db.cliente, "clienteID", "nombre", cita.clienteID);
            ViewBag.doctorID = new SelectList(db.doctor, "doctorID", "nombre", cita.doctorID);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "citaID,confirmacion,fechaIn,fechaOut,doctorID,clienteID,comentario")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clienteID = new SelectList(db.cliente, "clienteID", "nombre", cita.clienteID);
            ViewBag.doctorID = new SelectList(db.doctor, "doctorID", "nombre", cita.doctorID);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cita cita = db.cita.Find(id);
            db.cita.Remove(cita);
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
