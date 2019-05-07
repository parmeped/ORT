using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace WebTest.ViewModels.Profesores
{
    public class ProfesoresViewModel
    {
        public List<Profesor> Profesores { get; set; }
        public string Error = "No se encontraron profesores!";
        public string Message = "Hola, soy un mensaje en profesores!";
    }
}