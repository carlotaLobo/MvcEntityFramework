using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    public class ProcedimientoEmpleadosVista
    {
        public List<EmpleadosVistaTabla> EmpleadosVistas { get; set; }
        public int Suma { get; set; }
        public int Media { get; set; }

    }
}
