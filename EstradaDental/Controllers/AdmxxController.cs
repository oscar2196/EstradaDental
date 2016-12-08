using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EstradaDental.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace EstradaDental.Controllers
{
    public class AdmxxController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admxx
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

      
        // GET: Admxx/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admxx/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "nombre,apellidoP,apellidoM,direccion,fechaNac,Email,Password,ConfirmPassword,PhoneNumber")] RegisterViewModel admxx)
        {
            if (ModelState.IsValid)
            {
                var UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                Admxx admin = new Admxx(admxx);
                var result = await UserManager.CreateAsync(admin, admxx.Password);

                if (result.Succeeded)
                {
                    UserManager.AddToRole(admin.Id, "Admin");
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }

            return View(admxx);
        }

       

    

        // GET: Admxx/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Admxx admxx = .Find(id);
        //    if (admxx == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(admxx);
        //}

        // POST: Admxx/Delete/5
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
