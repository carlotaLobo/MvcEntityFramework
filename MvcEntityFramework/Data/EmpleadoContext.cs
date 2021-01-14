using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Data
{
    public class EmpleadoContext : DbContext
    {

        public EmpleadoContext(DbContextOptions <EmpleadoContext> options):base(options){}
        public DbSet<Empleado> Empleados { get; set; }
    }
}
