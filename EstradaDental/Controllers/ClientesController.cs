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
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.cliente.ToList());
        }
        [Authorize(Roles = "Admin, User")]
        //// GET: Clientes/Details/5 meter historialcinico
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "nombre,apellidoP,apellidoM,direccion,fechaNac,Email,Password,ConfirmPassword,PhoneNumber,ciudad")] RegisterViewModel cliente, HttpPostedFileBase fotoUpload)
        {
            Cliente Clientes = new Cliente(cliente);
            if (ModelState.IsValid)
            {
               
                   if (fotoUpload != null && fotoUpload.ContentLength > 0)
                {
                     Archivo ar = new Archivo();
                    ar.formatoContenido = fotoUpload.ContentType;
                    ar.nombre = fotoUpload.FileName;
                    ar.tipo = "Cliente";
                    var leer = new System.IO.BinaryReader(fotoUpload.InputStream);
                    ar.contenido = leer.ReadBytes(fotoUpload.ContentLength);
                    Clientes.archivos = new List<Archivo> { ar };
                }
                var UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
               
                var result = await UserManager.CreateAsync(Clientes, cliente.Password);

                
                /*db.cliente.Add(Clientes);
                db.SaveChanges();*/
                if (result.Succeeded)
                {
                    UserManager.AddToRole(Clientes.Id,"User");
                    return RedirectToAction("Create", "HistorialClinico");
                }
               
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        [Authorize(Roles = "Admin, User")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,nombre,apellidoP,apellidoM,direccion,fechaNac,Email,PhoneNumber,ciudad,PasswordHash,UserName")]
        Cliente cliente, HttpPostedFileBase fotoUpload)
        {
            if (ModelState.IsValid)
            {
                if (fotoUpload != null && fotoUpload.ContentLength > 0)
                {
                    //int archivoID = alumnoEditado.archivos.Single()
                    Archivo fotoPerfil = db.archivo.Single(ar => ar.clienteID == cliente.Id);
                    var reader = new System.IO.BinaryReader(fotoUpload.InputStream);
                    fotoPerfil.contenido = reader.ReadBytes(fotoUpload.ContentLength);

                    //Se modifica el registro de la foto
                    db.Entry(fotoPerfil).State = EntityState.Modified;
                }



                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }
        [Authorize(Roles = "Admin")]
        // GET: Clientes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [Authorize(Roles = "Admin, User")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cliente cliente = db.cliente.Find(id);
            db.Users.Remove(cliente);
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
