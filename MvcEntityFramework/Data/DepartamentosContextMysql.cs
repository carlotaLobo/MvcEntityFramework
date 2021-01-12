using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace MvcEntityFramework.Data
{
    public class DepartamentosContextMysql : IDepartamentosContext
    {
        private MySqlDataAdapter adapter;
        private DataTable table;

        public DepartamentosContextMysql(String cadena)
        {
            this.adapter = new MySqlDataAdapter("SELECT * FROM DEPT", cadena);
            this.table = new DataTable();
            this.adapter.Fill(this.table);

        }
        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.table.AsEnumerable()
                           select datos;
            List<Departamento> departamentos = new List<Departamento>();

            foreach (var dato in consulta)
            {
                departamentos.Add(
                    new Departamento(
                        dato.Field<int>("dept_no"),
                        dato.Field<String>("dnombre"),
                        dato.Field<String>("loc")
                        )
                    );
            }
            return departamentos;
        }
    }
}
