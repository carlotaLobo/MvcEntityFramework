using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryPlantilla
    {
        HospitalContext context;
        public RepositoryPlantilla(HospitalContext context)
        {
            this.context = context;
        }

        public List<Plantilla> FindAll()
        {

            var consulta = from dato in this.context.Plantilla
                           select dato;

            return consulta.ToList();
        }
        public ResumenPlantilla FindBySalario(int salario)
        {
            var consulta = from dato in this.context.Plantilla
                           select dato;

            ResumenPlantilla resumen = new ResumenPlantilla();
            resumen.plantilla  = consulta.Where(s => s.Salario > salario || s.Salario == salario).ToList();
            resumen.max = consulta.Max(s => s.Salario);
            resumen.min = consulta.Min(s => s.Salario);
            resumen.cantidad = resumen.plantilla.Count();

            if(resumen != null)
            {
                return resumen;
            }

            return null;
        }
    }
}
