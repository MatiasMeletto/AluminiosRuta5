using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluminiosRuta5.Objects
{
    public class Remito
    {
        public int RemitoId { get; set; }
        public string Fecha { get; set; }
        public string TotalPesos { get; set; }
        public string TotalKilos { get; set; }
        public int NroRemito { get; set; }
        public string TotalKilosBlancoB { get; set; }
        public string TotalKilosBlancoA { get; set; }
        public string TotalKilosNatural { get; set; }
        public string TotalKilosNegroSemiMate { get; set; }
        public string TotalKilosReciclado { get; set; }
        public string TotalPesosBlancoB { get; set; }
        public string TotalPesosBlancoA { get; set; }
        public string TotalPesosNatural { get; set; }
        public string TotalPesosNegroSemiMate { get; set; }
        public string TotalPesosReciclado { get; set; }
    }
}
