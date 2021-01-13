using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Models;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class HospitalController : Controller
    {
        private RepositoryHospital repository;
        public HospitalController(RepositoryHospital repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            List<Hospital> hospitales = this.repository.findAll();
            return View(hospitales);
        }
    }
}
