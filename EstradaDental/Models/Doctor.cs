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

        [Display(Name ="Name")]
        public string nombre { get; set; }
        [Display(Name ="Last name")]
        public string apellidoP { get; set; }
        [Display(Name ="Mother last name")]
        public string apellidoM { get; set; }
        [Display(Name ="Specialty")]
        public string especialidad { get; set; }
        [Display(Name ="Address")]
        public string direccion { get; set; }
        [Display(Name ="Phone number")]
        public int telefono { get; set; }

        //Un doctor tiene muchas citas
        virtual public ICollection<Cita> cita { get; set; }
        
    }
}