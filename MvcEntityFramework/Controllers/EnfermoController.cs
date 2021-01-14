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
        public IActionResult EnfermosGenero(String? genero)
        {
            List<Genero> generos = this.context.Sexos();
            ViewBag.sexos = generos;

            if(genero != null)
            {
                List<Enfermo> enfermos = this.context.FindEnfermoBySexo(genero);

                return View(enfermos);
            }

            return View();
        }
        public IActionResult Eliminar(int id)
        {
            this.context.Delete(id);

            return RedirectToAction("Index");
        }
        public IActionResult Insert()
        {
           List<Genero> generos= this.context.Sexos();
            return View(generos);
        }
        [HttpPost]
        public IActionResult Insert(Enfermo enfermo)
        {
            this.context.Insert(enfermo);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Enfermo enfermo= this.context.FindByInscription(id);
            List<Genero> generos = this.context.Sexos();
            ViewBag.generos = generos;
            return View(enfermo);
        }
        [HttpPost]
        public IActionResult Update(Enfermo enfermo)
        {
            this.context.Update(enfermo);
            return RedirectToAction("index");
        }
    }
}
