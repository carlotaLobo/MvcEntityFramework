using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryEmpleadosHospital 
    {
        HospitalContext context;
        public RepositoryEmpleadosHospital(HospitalContext context)
        {
            this.context = context;
        }
        public List<EmpleadoHospital> GetEmpleadoHospital()
        {
            var sql = from datos in this.context.EmpleadoHospital
                      select datos;
            return sql.ToList();
        }
        public ProcedimientoEmpleadoHospital GetEmpleadosHospital(int hospitalcod)
        {
            String sql = "PROCEDUREEMPLEADOSHOSPITAL @HOSPITALCOD, @suma out, @media out";
            // OUT porque son parametros de salida, no hay que decirselos, si no que los devuelve
            SqlParameter cod = new SqlParameter("@HOSPITALCOD", hospitalcod);
            // los parametros OUT tienen que tener un valor por defecto para que funcione
            SqlParameter pamsuma = new SqlParameter("@suma", -1);
            // hay que indicar que es un imput, su direccion
            pamsuma.Direction = System.Data.ParameterDirection.Output;
            SqlParameter pammedia = new SqlParameter("@media", -1);
            pammedia.Direction = System.Data.ParameterDirection.Output;
            List<EmpleadoHospital> empleados = this.context.EmpleadoHospital
                .FromSqlRaw(sql, cod, pamsuma, pammedia)
                .ToList();

            ProcedimientoEmpleadoHospital salida = new ProcedimientoEmpleadoHospital();
            salida.Empleados = empleados;
            salida.SumaSalarial = Convert.ToInt32(pamsuma.Value);
            salida.MediaSalarial = Convert.ToInt32(pammedia.Value);

            return salida;
        }
    }
}
