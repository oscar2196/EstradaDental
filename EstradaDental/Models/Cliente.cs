using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstradaDental.Models
{
    public class Cliente : ApplicationUser
    {
        public Cliente(){ }

        public Cliente(RegisterViewModel cliente):base(cliente)
        {
            this.ciudad = cliente.ciudad;
        }

        public string ciudad { get; set; }
        //Un cliente tiene muchas Citas
        virtual public ICollection<Cita> cita { get; set; }

        //Un cliente tiene muchos historiales
        virtual public ICollection<Historial> historiales { get; set; }
        virtual public ICollection<HistorialClinico> historialClinico { get; set; }

        virtual public ICollection<Archivo> archivos { get; set; }
    }
}