using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace otorino.Models
{
    public class ClienteDto
    {

            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Telefono { get; set; }
            public string Email { get; set; }
            public string Otros { get; set; }
            public string NombreServicio { get; set; }
        
    }
}