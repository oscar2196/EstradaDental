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
    public class HistorialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Historials
        [Authorize(Roles = "User")]
        public ActionResult Index()
        {

            string iduser = User.Identity.GetUserId();
            var Hist = new List<Historial>();
            Hist = db.historial.Where(a => a.clienteID == iduser).ToList();
            //string nombre = db.Users.were(a => a.nombre  );

            return View(Hist);
        }
        // GET: Historials
        [Authorize(Roles = "Admin")]
        public ActionResult inicio(string id)
        {

            
            var Hist = new List<Historial>();
            Hist = db.historial.Where(a => a.clienteID ==  id).ToList();
            //string nombre = db.Users.were(a => a.nombre  );

            return View(Hist);
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
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
           
            ViewBag.clienteID = new SelectList(db.Users, "Id", "nombre");
            return View();
        }

        // POST: Historials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles ="Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "historialID,comentario,fecha,clienteID")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                //historial.clienteID = User.Identity.GetUserId();
                db.historial.Add(historial);
                db.SaveChanges();
                return RedirectToAction("inicio", "Historials", new { id= historial.clienteID});
            }
            ViewBag.clienteID = new SelectList(db.Users, "Id", "nombre", historial.clienteID);
            return View(historial);
        }

        // GET: Historials/Edit/5
        [Authorize(Roles ="Admin")]
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
        [Authorize(Roles ="Admin")]
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
