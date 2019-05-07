using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.ViewModels.Alumnos
{
    public class ExamenesViewModel
    {
        public List<Examen> Examenes { get; set; }
        public Alumno Alumno { get; set; }        
        public string Error = "No se encontraron examenes!";
    }
}