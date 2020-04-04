using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace otorino.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        //public string Servicio { get; set; }
        public string Otros { get; set; }
        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }
    }
}
