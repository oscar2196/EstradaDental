using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EstradaDental.Models;
using Microsoft.AspNet.Identity;

namespace EstradaDental.Controllers
{
    public class CitasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Citas
        [Authorize(Roles = "Admin")]
        public ActionResult citas()
        {
            var cita = db.cita.Include(c => c.cliente).Include(c => c.doctor);
            return View(cita.ToList());
        }

        // GET: Citas/index/
        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            var resBusqueda = new List<Cita>();
            if (!string.IsNullOrEmpty(id))
            {
                resBusqueda = db.cita.Where(a => a.clienteID.Contains(id)).ToList();
            }
            else
            {
                resBusqueda = db.cita.ToList();
            }
           
            return View(resBusqueda);
        }
        [Authorize(Roles = "User, Admin")]
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
        [Authorize(Roles = "User")]
        // GET: Citas/Create
        public ActionResult Create()
        {

            ViewBag.clienteID = new SelectList(db.Users, "Id", "nombre");
            ViewBag.doctorID = new SelectList(db.doctor, "doctorID", "nombre");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "citaID,confirmacion,fechaIn,fechaOut,doctorID,clienteID,comentario")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                cita.clienteID = User.Identity.GetUserId();
                //cita.confirmacion = false;
                db.cita.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clienteID = new SelectList(db.Users, "Id", "nombre", cita.clienteID);
            ViewBag.doctorID = new SelectList(db.doctor, "doctorID", "nombre", cita.doctorID);
            return View(cita);
        }
        [Authorize(Roles = "User, Admin")]
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
            ViewBag.clienteID = new SelectList(db.Users, "Id", "nombre", cita.clienteID);
            ViewBag.doctorID = new SelectList(db.doctor, "doctorID", "nombre", cita.doctorID);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "citaID,confirmacion,fechaIn,fechaOut,doctorID,clienteID,comentario")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                cita.clienteID = User.Identity.GetUserId();
                cita.confirmacion = false;
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clienteID = new SelectList(db.Users, "Id", "nombre", cita.clienteID);
            ViewBag.doctorID = new SelectList(db.doctor, "doctorID", "nombre", cita.doctorID);
            return View(cita);
        }
        [Authorize(Roles = "User")]
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
        [Authorize(Roles = "User")]
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


        [Authorize(Roles = "Admin")]
        // GET: Citas/editarA/5
        public ActionResult editarA(int? id)
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
            ViewBag.clienteID = new SelectList(db.Users, "Id", "nombre", cita.clienteID);
            ViewBag.doctorID = new SelectList(db.doctor, "doctorID", "nombre", cita.doctorID);
            return View(cita);
        }

        // POST: Citas/editarA/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editarA([Bind(Include = "citaID,confirmacion,fechaIn,fechaOut,doctorID,clienteID,comentario")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                //cita.clienteID = User.Identity.GetUserId();
                //cita.confirmacion = false;
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("citas");
            }
            ViewBag.clienteID = new SelectList(db.Users, "Id", "nombre", cita.clienteID);
            ViewBag.doctorID = new SelectList(db.doctor, "doctorID", "nombre", cita.doctorID);
            return View(cita);
        }
        [Authorize(Roles = "Admin")]
        // GET: Citas/Delete/5
        public ActionResult eliminacion(int? id)
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
        [Authorize(Roles = "Admin")]
        // POST: Citas/Delete/5
        [HttpPost, ActionName("eliminacion")]
        [ValidateAntiForgeryToken]
        public ActionResult eliminacionConfirmada(int id)
        {
            Cita cita = db.cita.Find(id);
            db.cita.Remove(cita);
            db.SaveChanges();
            return RedirectToAction("citas");
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
