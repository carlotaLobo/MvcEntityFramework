using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    
    public class EmpleadoRepository
    {
        private EmpleadoContext context;

        public EmpleadoRepository(EmpleadoContext context)
        {
            this.context = context;
        }
        public List<String> FindAllOficios()
        {
            var consulta = (from dato in this.context.Empleados
                           select dato.Oficio).Distinct();
            return consulta.ToList();
        }
        public List<Empleado> FindEmpleadoByOficio(String oficio)
        {
            var consulta = from dato in this.context.Empleados
                           where dato.Oficio == oficio select dato;

            return consulta.ToList();
        }
        public List<Empleado> FindAll()
        {
            var consulta = from dato in this.context.Empleados
                           select dato;  
            return  consulta.ToList();
        }
        public void IncrementSalarioByOficio(String Oficio, int incremento)
        {
            var consulta = from dato in this.context.Empleados
                           where dato.Oficio == Oficio
                           select dato;
           
            foreach (Empleado dato in consulta)
            {
                dato.Salario = dato.Salario + incremento;
   
            } 
               this.context.SaveChanges();   

        }
    }
}
