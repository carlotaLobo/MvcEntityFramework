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
        public List<Genero> Sexos()
        {
            var consulta = (from datos in this.context.Enfermo
                            select datos.Sexo).Distinct();

            List<Genero> sexos = new List<Genero>();
            foreach (var dato in consulta)
            {
                Genero genero = new Genero();
                genero.Value = dato;
                if (dato.ToLower() == "f")
                {
                    genero.Text = "Femenino";
                }
                else
                {
                    genero.Text = "Masculino";
                }
                sexos.Add(genero);
            }
            return sexos;
        }
        public List<Enfermo> FindEnfermoBySexo(String sexo)
        {
            var consulta = from datos in this.context.Enfermo
                           where datos.Sexo == sexo
                           select datos;
            return consulta.ToList();
        }
        public void Delete(int inscripcion)
        {
            // primero buscamos la entidad a eliminar
            Enfermo enfermo = this.FindByInscription(inscripcion);
            this.context.Enfermo.Remove(enfermo);
            this.context.SaveChanges();
        }
        public void Insert(Enfermo enfermo)
        {
            this.context.Add(enfermo);
            this.context.SaveChanges();
        }
        public void Update(Enfermo enfermo)
        {
            // solo con esto lo estaría guardando con los cambios
            //si no recibimos el objeto, primero buscamos el enfermo
            this.context.Enfermo.Update(enfermo);
            this.context.SaveChanges();
        }
        }

    }

