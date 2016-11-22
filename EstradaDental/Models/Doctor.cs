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

        //[Required]
        [Display(Name ="Name")]
        public string nombre { get; set; }

        //[Required]
        [Display(Name ="Last name")]
        public string apellidoP { get; set; }

        
        [Display(Name ="Mother last name")]
        public string apellidoM { get; set; }

        //[Required]
        [Display(Name ="Specialty")]
        public string especialidad { get; set; }

        //[Required]
        [Display(Name ="Address")]
        public string direccion { get; set; }

        //[Required]
        [Display(Name ="Phone number")]
        public string telefono { get; set; }

        //Un doctor tiene muchas citas
        virtual public ICollection<Cita> cita { get; set; }
        
    }
}