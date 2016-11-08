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

        public string nombre { get; set; }

        public string apellidoP { get; set; }

        public string apellidoM { get; set; }
        
        public string direccion { get; set; }

        public int telefono { get; set; }
        
        //public Image imagen { get; set; }+

        //Un cliente tiene muchas Citas
        virtual public ICollection<Cita> cita { get; set; }

        //Un cliente tiene muchos historiales
        virtual public ICollection<Historial> historiales { get; set; }

    }
}