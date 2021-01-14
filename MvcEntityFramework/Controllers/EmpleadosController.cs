using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Models;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class EmpleadosController : Controller
    {
        private EmpleadoRepository repository;
        public EmpleadosController(EmpleadoRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            List<Empleado>empleados=  this.repository.FindAll();
            List<String> oficios= this.repository.FindAllOficios();
            ViewBag.oficios = oficios;
            return View(empleados);
        }
        [HttpPost]
        public IActionResult Index(String oficio, int incremento)
        {
            List<String> oficios = this.repository.FindAllOficios();
            ViewBag.oficios = oficios;
             this.repository.IncrementSalarioByOficio(oficio, incremento);
            List<Empleado> empleados = this.repository.FindEmpleadoByOficio(oficio);
            return View(empleados);
        }
    }
}
