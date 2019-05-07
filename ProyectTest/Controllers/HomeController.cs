﻿using ProyectTest.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AllAlumnos()
        {
            ViewBag.Message = "All Alumnos info shall be here";            

            var model = new AllAlumnosViewModel();
            model.Alumnos = Domain.DataMock.Alumnos.ToList();

            return View(model);
        }
    }
}