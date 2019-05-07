using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.ViewModels.Alumnos;
using Domain; 

namespace WebTest.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        [Route(Name = "Alumnos_All")]
        public ActionResult All()
        {
            ViewBag.Message = "Alumnos List";

            var model = new AlumnosViewModel();
            model.Alumnos = Domain.DataMock.Alumnos.ToList();

            return View("Alumnos", model);
        }

        // GET: Examenes
        [Route("Examenes/{dni}", Name = "Examenes_Alumno")]
        public ActionResult Examenes(int dni)
        {
            var alumno = DataMock.Alumnos.FirstOrDefault(x => x.Dni == dni);  // alumnos no debería estar vacio ya que se selecciona de una lista de alumnos existentes. 
            var examenes = alumno.Examenes.ToList();
            
            var model = new ExamenesViewModel()
            {
                Alumno = alumno,
                Examenes = examenes // en la vista se valida si Examenes está vacio! 
            };

            return View("Examenes", model);
        }

        // Nuevo Alumno redirect
        [HttpGet]
        [Route("NuevoAlumno", Name = "NuevoAlumno")]
        public ActionResult NuevoAlumno()
        {
            return View("NuevoAlumno", new NuevoAlumnoViewModel());
        }

        [HttpPost]
        [Route("NuevoAlumno_Post", Name = "NuevoAlumno_Post")]
        public ActionResult NuevoAlumno(NuevoAlumnoViewModel model)
        {
            if (model.Dni == 0)
                ModelState.AddModelError("Dni", "Debe ingresar un DNI");

            if (string.IsNullOrWhiteSpace(model.Nombre))
                ModelState.AddModelError("Nombre", "Debe ingresar un nombre");

            if (string.IsNullOrWhiteSpace(model.Apellido))
                ModelState.AddModelError("Apellido", "Debe ingresar un apellido");

            if (string.IsNullOrWhiteSpace(model.LegajoTipo))
                ModelState.AddModelError("TipoLegajo", "Debe ingresar un tipo de Legajo");
            if (model.LegajoNumero == 0)
                ModelState.AddModelError("NumeroLegajo", "Debe ingresar un numero de Legajo");


            try
            {
                if (ModelState.IsValid)
                {
                    var legajo = new Legajo(model.LegajoTipo, model.LegajoNumero);
                    var alumno = new Alumno(model.Nombre, model.Apellido, legajo, model.Dni);
                    DataMock.Alumnos.Add(alumno);

                    return RedirectToAction("All");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }
    }    
}