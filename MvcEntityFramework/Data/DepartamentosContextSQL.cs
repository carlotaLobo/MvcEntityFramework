using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MvcEntityFramework.Data
{
    public class DepartamentosContextSQL : IDepartamentosContext
    {
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public DepartamentosContextSQL( String cadena) {

            this.dataTable = new DataTable();
            this.dataAdapter = new SqlDataAdapter("SELECT * FROM DEPT", cadena);
            this.dataAdapter.Fill(this.dataTable);

        }
        public List<Departamento> GetDepartamentos()
        {
            var consulta = from dato in this.dataTable.AsEnumerable()
                           select dato;

            List<Departamento> listado = new List<Departamento>();

            foreach(var dato in consulta)
            {

                listado.Add(
                    new Departamento(
                        dato.Field<int>("dept_no"),
                        dato.Field<String>("dnombre"),
                        dato.Field<String>("loc")
                        )
                    );
            }

            return listado;
        }
    }
}
