using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Models;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class PlantillaController : Controller
    {
       private RepositoryPlantilla repo;

        public PlantillaController(RepositoryPlantilla repository)
        {
            this.repo = repository;
        }
        public IActionResult Index()
        {
            ResumenPlantilla resumen = new ResumenPlantilla();
            resumen.plantilla=this.repo.FindAll();

            return View(resumen);
        }
        [HttpPost]
        public IActionResult Index(int salario)
        {
          ResumenPlantilla resumen=  this.repo.FindBySalario(salario);
            
            return View(resumen);
        }
    }
}
