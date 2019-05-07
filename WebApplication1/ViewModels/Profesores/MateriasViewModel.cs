using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace WebTest.ViewModels.Profesores
{
    public class MateriasViewModel
    {
        public List<Materia> Materias { get; set; }
        public Profesor Profesor { get; set; }
        public string Error = "No se encontraron profesores!";

        public MateriasViewModel(List<Materia> materias, Profesor profesor)
        {
            Materias = materias;
            Profesor = profesor;
        }
    }
}