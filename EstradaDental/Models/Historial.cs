﻿using System;
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

        [Display(Name = "Please enter your dental history")]
        public string comentario { get; set; }

        [Display(Name ="Day and hour")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }


        public int clienteID { get; set; }
        virtual public ApplicationUser cliente { get; set; }

    }
}