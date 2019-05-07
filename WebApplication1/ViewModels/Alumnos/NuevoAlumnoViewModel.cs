using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.ViewModels.Alumnos
{
    public class NuevoAlumnoViewModel
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string LegajoTipo { get; set; }
        public int LegajoNumero { get; set; }

    }
}