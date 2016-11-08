using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstradaDental.Models
{
    public class Doctor
    {
        [Key]
        public int doctorID { get; set; }

        public string nombre { get; set; }

        public string apellidoP { get; set; }

        public string apellidoM { get; set; }

        public string especialidad { get; set; }

        public string direccion { get; set; }

        public int telefono { get; set; }

        //Un doctor tiene muchas citas
        virtual public ICollection<Cita> cita { get; set; }
        
    }
}