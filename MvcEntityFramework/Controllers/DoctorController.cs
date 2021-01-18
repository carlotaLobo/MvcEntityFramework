using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{

    public class DoctorController : Controller
    {
        RepositoryDoctor repo;
        public DoctorController(RepositoryDoctor repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View(this.repo.FinfAll());
        }
 
        [HttpPost]
        public IActionResult Index(int id, String especialidad)
        {
            this.repo.UpdateEspacialidad(id, especialidad);

            return RedirectToAction("index");
        }
        public IActionResult AumentarSalario()
        {
            ViewBag.especialidades = new List<String>(this.repo.Especialidades().ToList());
            
            return View(this.repo.FinfAll());
        }
        [HttpPost]
        public IActionResult AumentarSalario(int aumento, String especialidad)
        {

            this.repo.AumentarSalario(aumento, especialidad);
            ViewBag.especialidades = new List<String>(this.repo.Especialidades().ToList());

            return View(this.repo.DoctoresEspecialidad(especialidad));
        }
    }
}
