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


        public string comentario { get; set; }

        public DateTime fecha { get; set; }


        public int clienteID { get; set; }
        virtual public Cliente cliente { get; set; }

    }
}