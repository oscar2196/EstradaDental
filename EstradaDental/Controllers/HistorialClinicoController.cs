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
    public class HistorialClinicoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HistorialClinico
       
        // GET: HistorialClinico/Details/5
        public ActionResult Details()
        {
            string iduser = User.Identity.GetUserId();
            var Hist = new List<HistorialClinico>();
           Hist= db.historialclinico.Where(a => a.clienteID == iduser).ToList();
           
           return View(Hist);
        }
        [Authorize(Roles = "User, Admin")]
        // GET: HistorialClinico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistorialClinico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

      
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "historialClinicoID,clienteID,pregunta1,pregunta2,pregunta3,pregunta4,pregunta5,pregunta6,pregunta7,pregunta8,pregunta9,pregunta10,pregunta11,pregunta12,pregunta13,pregunta14,pregunta15,pregunta16,pregunta17,pregunta18,pregunta19,pregunta20,pregunta21,pregunta22,pregunta23,pregunta24,pregunta25,pregunta26,pregunta27,pregunta28,pregunta29,observaciones,antecedenteClinico")] HistorialClinico historialClinico)
        {
            
                if (ModelState.IsValid)
                {
                    //cita.clienteID = User.Identity.GetUserId();
                    historialClinico.clienteID = User.Identity.GetUserId();
                    db.historialclinico.Add(historialClinico);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                } 
          

            return View(historialClinico);
        }

        // GET: HistorialClinico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialClinico historialClinico = db.historialclinico.Find(id);
            if (historialClinico == null)
            {
                return HttpNotFound();
            }
            return View(historialClinico);
        }

        // POST: HistorialClinico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "historialClinicoID,clienteID,pregunta1,pregunta2,pregunta3,pregunta4,pregunta5,pregunta6,pregunta7,pregunta8,pregunta9,pregunta10,pregunta11,pregunta12,pregunta13,pregunta14,pregunta15,pregunta16,pregunta17,pregunta18,pregunta19,pregunta20,pregunta21,pregunta22,pregunta23,pregunta24,pregunta25,pregunta26,pregunta27,pregunta28,pregunta29,observaciones,antecedenteClinico")] HistorialClinico historialClinico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historialClinico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historialClinico);
        }

        // GET: HistorialClinico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialClinico historialClinico = db.historialclinico.Find(id);
            if (historialClinico == null)
            {
                return HttpNotFound();
            }
            return View(historialClinico);
        }

        // POST: HistorialClinico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistorialClinico historialClinico = db.historialclinico.Find(id);
            db.historialclinico.Remove(historialClinico);
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
