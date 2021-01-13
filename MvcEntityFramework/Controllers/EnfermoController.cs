using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Models;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class EnfermoController : Controller
    {
       private RepositoryEnfermo context;

        public EnfermoController(RepositoryEnfermo context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Enfermo> enfermos = this.context.FindAll();
            return View(enfermos);
        }
        public IActionResult Detalle(int id)
        {
            Enfermo enfermo=  this.context.FindByInscription(id);

            return View(enfermo);
        }
    }
}
