using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstradaDental.Models
{
    public class Cita
    {

        public int citaID { get; set; }


        public bool confirmacion { get; set; }


        //[Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime fechaIn { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime fechaOut { get; set; }

        ////[Required]
        //[Display(Name = "Doctor name")]
        //public int doctorID { get; set; }

        
        //[Required]
        [Display(Name = "Client name")]
        public string clienteID { get; set; }

        //[Required]
        [Display(Name = "Comments on the reason for the appointment")]
        public string comentario { get; set; }



        //Una cita tiene un cliente
        virtual public Cliente cliente { get; set; }
        //Una cita tiene un dentista
        //virtual public Doctor doctor { get; set; }
        virtual public Admxx admxx { get; set; }


    }
}