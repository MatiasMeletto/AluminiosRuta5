﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluminiosRuta5.Objects
{
    public class Perfil
    {
        public int PerfilId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string KgXPaquete { get; set; }
        public string KgXTira { get; set; }
        public int CantidadTiras { get; set; }
        public string Import { get; set; }

        public int CategoriaId { get; set; }

        //KgXMts int
        //MtsPorTira double
        // KgxTira x2 
    }
}
