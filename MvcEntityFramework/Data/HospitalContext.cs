using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Data
{
    public class HospitalContext: DbContext
    {
        //tendra un constructor obligatorio con option para el context

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options){} // sobreescribimos las options de la clase heredada
        //debemos mapear con Dbset cada propiedad para que sea accesible
        public DbSet<Hospital> Hospitals { get; set; }
    }
}
