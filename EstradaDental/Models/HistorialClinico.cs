using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstradaDental.Models
{
    public class HistorialClinico
    {
        [Key]
        public int historialClinicoID { get; set; }

        public string clienteID { get; set; }
       
        public bool pregunta1 { get; set; }
        public bool pregunta2 { get; set; }
        public bool pregunta3 { get; set; }
        public bool pregunta4 { get; set; }
        public bool pregunta5 { get; set; }
        public bool pregunta6 { get; set; }
        public bool pregunta7 { get; set; }
        public bool pregunta8 { get; set; }
        public bool pregunta9 { get; set; }
        public bool pregunta10 { get; set; }
        public bool pregunta11 { get; set; }
        public bool pregunta12 { get; set; }
        public bool pregunta13 { get; set; }
        public bool pregunta14 { get; set; }
        public bool pregunta15 { get; set; }
        public bool pregunta16 { get; set; }
        public bool pregunta17 { get; set; }
        public bool pregunta18 { get; set; }
        public bool pregunta19 { get; set; }
        public bool pregunta20 { get; set; }
        public bool pregunta21 { get; set; }
        public bool pregunta22 { get; set; }
        public bool pregunta23 { get; set; }
        public bool pregunta24 { get; set; }
        public bool pregunta25 { get; set; }
        public bool pregunta26 { get; set; }
        public bool pregunta27 { get; set; }
        public bool pregunta28 { get; set; }
        public bool pregunta29 { get; set; }

        public string observaciones { get; set; }

        public string antecedenteClinico { get; set; }


        virtual public Cliente clientes { get; set; }
    }
}