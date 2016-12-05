using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstradaDental.Models
{
    public class Historial
    {
        [Key]
        public int historialID { get; set; }

        [Display(Name = "Reason for consultation")]
        public string comentario { get; set; }

        [Display(Name ="Day and hour")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]/*dd-MM-yyyy*/
        public DateTime fecha { get; set; }



        public string clienteID { get; set; }
        virtual public ApplicationUser clientes { get; set; }

    }
}