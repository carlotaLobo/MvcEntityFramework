using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryEnfermo
    {   
        private EnfermoContext context;

        public RepositoryEnfermo(EnfermoContext context)
        {
            this.context = context;

        }

        public List<Enfermo> FindAll()
        {
            var consulta = from dato in this.context.Enfermo
                           select dato;
            return consulta.ToList();
        }
        public Enfermo FindByInscription(int i)
        {
            var consulta = from datos in this.context.Enfermo
                           where datos.Inscripcion == i
                           select datos;
         
                if(consulta.Count() == 0){
                    return null;
                }
                    Enfermo enfermo = consulta.First();
                    return enfermo;
            }
         

        }

    }

