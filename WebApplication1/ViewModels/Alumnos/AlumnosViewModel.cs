using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.ViewModels.Alumnos
{
    public class AlumnosViewModel
    {
        public List<Alumno> Alumnos { get; set; }
        public string Error = "No se encontraron alumnos!";
        public string ok = "Datos encontrados de los alumnos!";
        public string Message = "Hola, soy un mensaje en Alumnos!";
    }
}