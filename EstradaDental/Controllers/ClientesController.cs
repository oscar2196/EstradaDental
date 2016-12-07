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
    public class ClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.ApplicationUsers.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.ApplicationUsers.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "nombre,apellidoP,apellidoM,direccion,fechaNac,Email,Password,ConfirmPassword,PhoneNumber,ciudad")] RegisterViewModel cliente, HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {
                Archivo ar = new Archivo();
                if (foto != null && foto.ContentLength > 0)
                {

                    ar.formatoContenido = foto.ContentType;
                    ar.nombre = foto.FileName;
                    ar.tipo = "Cliente";
                    var leer = new System.IO.BinaryReader(foto.InputStream);
                    ar.contenido = leer.ReadBytes(foto.ContentLength);

                }
                var UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                Cliente Clientes = new Cliente(cliente);
                var result = await UserManager.CreateAsync(Clientes, cliente.Password);

                //clientenuevo.archivos = new List<Archivo> { ar };
                //db.ApplicationUsers.Add(clientenuevo);
                // db.SaveChanges();
                if (result.Succeeded)
                {
                    UserManager.AddToRole(Clientes.Id,"User");
                    return RedirectToAction("Index","Home");
                }
               
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.ApplicationUsers.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,apellidoP,apellidoM,direccion,fechaNac,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,ciudad,MyProperty")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.ApplicationUsers.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cliente cliente = db.ApplicationUsers.Find(id);
            db.ApplicationUsers.Remove(cliente);
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
