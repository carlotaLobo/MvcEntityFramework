using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryHospital
    {
        //clase encargada de realizar las consultas, por lo que necesita la conexion (context)
        private HospitalContext context;
        //inyectamos el contexto de hospital para poder acceder a la bbdd
        public RepositoryHospital(HospitalContext context) {

            this.context = context ;
        }

        public List<Hospital> findAll()
        {
            var consulta = from datos in this.context.Hospitals
                           select datos;
            return consulta.ToList();
        }
    }
}
