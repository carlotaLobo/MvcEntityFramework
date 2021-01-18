using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryDoctor
    {
        HospitalContext context;
        public RepositoryDoctor(HospitalContext context)
        {
            this.context = context;
        }
       public void UpdateEspacialidad(int id, String especialidad )
        {
            this.context.ModificarEspecialidad(id, especialidad);
        }
        public List<Doctor> FinfAll()
        {
            //EN ESTE CASO NO TIENE PARAMETROS, PERO LA CONSULTA ES IGUAL
            String sql = "MOSTRARDOCTORES";
            //LA CONSULTA SE EJECUTA A PARTIT DE UN DBSET DE COLECCION
            //Y AUTOMATICAMENTE MAPEARA LOS CAMPOS DE LOS DATOS
            //QUE DEVUELVA EL PROCEDURE
            List<Doctor> doctores = this.context.Doctores.FromSqlRaw(sql).ToList();
            return doctores;

        }
        public List<String> Especialidades()
        {

            //return ((FinfAll().Select(e => e.Especialidad))).Distinct().ToList();
            // PARA LLAMAS A PROCEDIMIENTOS SELECT QUE NO TENEMOS MAPEADOS BDSET
            //NECESITAMOS HACERLO A LA ANTIGUA, Y MAPEAR NOSOTROS MANUALMENTE LA RESPUESTA.
            //SE UTILIZAN OBJETOS STANDAR DE ADO PERO DE CORE
            //TAMBIEN SE DEBE UTILIZAR LA CONEXION DE LINQ
            using(DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
            {
                String sql = "ESPECIALIDADES";
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = sql;
                com.Connection.Open();
                DbDataReader reader= com.ExecuteReader();
                List<String> espe = new List<string>();
                while (reader.Read())
                {
                    espe.Add(reader["especialidad"].ToString());
                }
                reader.Close();
                com.Connection.Close();

                return espe;
            }
   
        }

        public List<Doctor> DoctoresEspecialidad(String especialidad)
        {
           return (from dato in this.context.Doctores.Where(e => e.Especialidad == especialidad) select dato).ToList();

        }

        public void AumentarSalario(int aumento, String especialidad)
        {          
             this.context.Database.ExecuteSqlRaw(
                   "UPDATESALARIOESPECIALIDAD @AUMENTO, @ESPECIALIDAD", 
                    new SqlParameter("@AUMENTO", aumento),
                    new SqlParameter("@ESPECIALIDAD", especialidad)
                    );      
        }
    }
}
