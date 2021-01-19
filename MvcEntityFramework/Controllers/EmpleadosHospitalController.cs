using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class EmpleadosHospitalController : Controller
    {
        RepositoryEmpleadosHospital repo;
        public EmpleadosHospitalController(RepositoryEmpleadosHospital repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View(this.repo.GetEmpleadoHospital());
        }
        
        public IActionResult ProcedimientoEmpleado()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProcedimientoEmpleado(int hospitalcod)
        {
            return View(this.repo.GetEmpleadosHospital(hospitalcod));
        }
    }
}
