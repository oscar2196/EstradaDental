using EstradaDental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstradaDental.Controllers
{   [Authorize(Roles ="Admin, User")]
    public class ArchivosController : Controller
    {   
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Archivos
        
        public FileResult download(int id)
        {
            Archivo arch = db.archivo.Find(id);
            return File(arch.contenido, arch.formatoContenido);
        }
    }
}