using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Data
{
    public class EnfermoContext:DbContext
    {
        public EnfermoContext(DbContextOptions<EnfermoContext> options) : base(options) { }
        public DbSet<Enfermo> Enfermo { get; set; }
    }
}
