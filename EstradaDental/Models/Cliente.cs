using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstradaDental.Models
{
    public class Cliente 
    {
        public int clienteID { get; set; }
        //[Required]
        [Display(Name ="Name")]
        public string nombre { get; set; }

        //[Required]
        [Display(Name ="Last name")]
        public string apellidoP { get; set; }

       
        [Display(Name ="Mother last name")]
        public string apellidoM { get; set; }

        //[Required]
        [Display(Name ="Address")]
        public string direccion { get; set; }

        //[Required]
        [Display(Name = "Number phone")]
        public int telefono { get; set; }
        
        //public Image imagen { get; set; }+

        //Un cliente tiene muchas Citas
        virtual public ICollection<Cita> cita { get; set; }

        //Un cliente tiene muchos historiales
        virtual public ICollection<Historial> historiales { get; set; }

    }
}