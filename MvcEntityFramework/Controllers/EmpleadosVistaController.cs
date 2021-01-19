using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class EmpleadosVistaController : Controller
    {
        RepositoryEmpleadosVista repo;
        public EmpleadosVistaController(RepositoryEmpleadosVista repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {

            return View(this.repo.GetDepartamentosVista());
        }
        [HttpPost]
        public IActionResult Index(int hospitalcod)
        {

            return View(this.repo.GetResumenEmpleadosVista(hospitalcod));
        }
    }
}
