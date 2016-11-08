using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstradaDental.Models
{
    public class Cita
    {

        public int citaID { get; set; }

        public bool confirmacion { get; set; }

        public DateTime fechaIn { get; set; }

        public DateTime fechaOut { get; set; }

        public int doctorID { get; set; }

        public int clienteID { get; set; }

        public string comentario { get; set; }

        //Una cita tiene un cliente
        virtual public Cliente cliente { get; set; }
        //Una cita tiene un dentista
        virtual public Doctor doctor { get; set; }

        

    }
}