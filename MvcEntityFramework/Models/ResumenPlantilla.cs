using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    public class ResumenPlantilla
    {
        public List<Plantilla> plantilla { get; set; }
        public int max { get; set; }
        public int min { get; set; }
        public int cantidad { get; set; }
    }
}
