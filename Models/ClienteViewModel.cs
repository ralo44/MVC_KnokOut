using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace otorino.Models
{
    public class ClienteViewModel
    {
        public IEnumerable<Servicio> NombreServicio { get; set; }
        public Cliente cliente { get; set; }
    }
}