using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstradaDental.Models
{
    public class Admxx : ApplicationUser
    {
        public Admxx() { }

        public Admxx(RegisterViewModel admxx) : base(admxx) { }

        virtual public ICollection<Cita> cita { get; set; }
        //Un cliente tiene muchos historiales
        virtual public ICollection<Archivo> archivos { get; set; }




    }
}