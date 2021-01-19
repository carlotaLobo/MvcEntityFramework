using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryEmpleadosVista
    {
        HospitalContext context;
        public RepositoryEmpleadosVista(HospitalContext context)
        {
            this.context = context;
        }

        public ProcedimientoEmpleadosVista GetDepartamentosVista()
        {
            List<EmpleadosVistaTabla> EmpleadosVista = new List<EmpleadosVistaTabla>();
            ProcedimientoEmpleadosVista procedimientoEmpleadosVista = new ProcedimientoEmpleadosVista();

            var sql = "DEPARTAMENTOSHOSPITAL";

            using (DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
            {
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = sql;
                com.Connection.Open();
                DbDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    EmpleadosVistaTabla vistaTabla = new EmpleadosVistaTabla();
                    vistaTabla.Departamento = reader["departamento"].ToString();
                    vistaTabla.Codigo =Convert.ToInt32( reader["codigo"]);
                    EmpleadosVista.Add(vistaTabla);
                    procedimientoEmpleadosVista.EmpleadosVistas = EmpleadosVista;
                }
                return procedimientoEmpleadosVista;
            }

                
        }

        public ProcedimientoEmpleadosVista GetResumenEmpleadosVista(int hospitalcod)
        {
            var sql = "EMPLEADOSDEPARTAMENTOHOSPITAL @codigo, @suma out, @media out";
            SqlParameter codigo = new SqlParameter("@codigo", hospitalcod);
            SqlParameter sum = new SqlParameter("@suma", -1);
            SqlParameter media = new SqlParameter("@media", -1);

            ProcedimientoEmpleadosVista procedimientoEmpleadosVista = new ProcedimientoEmpleadosVista();
            sum.Direction = System.Data.ParameterDirection.Output;
            media.Direction = System.Data.ParameterDirection.Output;
            procedimientoEmpleadosVista.EmpleadosVistas = this.context.EmpleadosVistas.FromSqlRaw(sql, codigo, sum, media).ToList();
            procedimientoEmpleadosVista.Suma = Convert.ToInt32(sum.Value);
            procedimientoEmpleadosVista.Media = Convert.ToInt32(media.Value);

            return procedimientoEmpleadosVista;
        }
    }
}
