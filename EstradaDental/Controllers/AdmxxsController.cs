using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EstradaDental.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace EstradaDental.Controllers
{
    public class AdmxxsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admxxs
        public ActionResult Index()
        {
            return View(db.ApplicationUsers.ToList());
        }

        //// GET: Admxxs/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Admxx admxx = db.ApplicationUsers.Find(id);
        //    if (admxx == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(admxx);
        //}

        // GET: Admxxs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admxxs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,nombre,apellidoP,apellidoM,direccion,fechaNac,EmailPhoneNumber,UserName")] RegisterViewModel RVMadmxx)
        {
            if (ModelState.IsValid)
            {
                var UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                Admxx admxx = new Admxx(RVMadmxx);
                var result = await UserManager.CreateAsync(admxx, RVMadmxx.Password);

                if (result.Succeeded)
                {
                    UserManager.AddToRole(admxx.Id, "Admin");
                    return RedirectToAction("Index");
                }
            }

            return View(RVMadmxx);
        }

        //// GET: Admxxs/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Admxx admxx = db.ApplicationUsers.Find(id);
        //    if (admxx == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(admxx);
        //}

        // POST: Admxxs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,nombre,apellidoP,apellidoM,direccion,fechaNac,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] Admxx admxx)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(admxx).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(admxx);
        //}

        //// GET: Admxxs/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Admxx admxx = db.ApplicationUsers.Find(id);
        //    if (admxx == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(admxx);
        //}

        //// POST: Admxxs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Admxx admxx = db.ApplicationUsers.Find(id);
        //    db.ApplicationUsers.Remove(admxx);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
