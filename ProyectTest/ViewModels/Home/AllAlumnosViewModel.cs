using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace ProyectTest.ViewModels.Home
{
    public class AllAlumnosViewModel
    {
        public List<Alumno> Alumnos { get; set; }
        public string Error = "No se encontraron alumnos!";
        public string ok = "No se encontraron alumnos!";
    }
}