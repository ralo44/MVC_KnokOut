﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace otorino.Models
{
    public class ServicioDto
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
namespace otorino.Models
{
    public class ServicioDetailDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        // public  string Imagen { get; set; }
    }
}

