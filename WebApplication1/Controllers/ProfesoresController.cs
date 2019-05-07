using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using WebTest.ViewModels.Profesores;

namespace WebTest.Controllers
{
    public class ProfesoresController : Controller
    {
        // GET: Profesores
        [HttpGet]
        [Route(Name = "Profesores_All")]
        public ActionResult All()
        {
            ViewBag.Message = "Profesores List";

            var model = new ProfesoresViewModel();
            model.Profesores = Domain.DataMock.Profesores.ToList();

            return View("Profesores", model);
        }


        // GET: Materias
        [HttpGet]
        [Route("Materias/{dni}", Name = "Materias_Profesor")]
        public ActionResult Materias(int dni)
        {
            var profesor = DataMock.Profesores.FirstOrDefault(x => x.Dni == dni);  
            var materias = profesor.Materias.ToList();

            var model = new MateriasViewModel(materias, profesor); // en la vista se valida si Examenes está vacio!             
            
            return View("Materias", model);
        }

        // POST: Examenes
        [HttpGet]
        [Route("GenerarExamen/{profesorDni}{materiaCodigo}", Name = "GenerarExamen")]
        public ActionResult GenerarExamen(int profesorDni, int materiaCodigo)
        {
            var profesor = DataMock.Profesores.FirstOrDefault(x => x.Dni == profesorDni);
            var materia = profesor.Materias.FirstOrDefault(x => x.Codigo == materiaCodigo);

            DataMock.GenerarExamen(profesor, materia); // Esto funciona en teoria pero no se updatea la view de los alumnos con las notas.... (?)

            //MateriasViewModel model = new MateriasViewModel(profesor.Materias, profesor);

            //return View("Materias", model);

            var model = new ProfesoresViewModel();
            model.Profesores = Domain.DataMock.Profesores.ToList();

            return View("Profesores", model);
        }

    }
}