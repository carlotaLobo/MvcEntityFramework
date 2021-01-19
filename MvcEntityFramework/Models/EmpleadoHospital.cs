using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    //vamos a acceder a una vista, pero lo mapeamos igua,
    //como no tiene primary key lo simulamos. En la bbdd hemos puesto ISNULL por lo mismo, en IDEMPLEADO
    [Table("EMPLEADOSHOSPITAL")]
    public class EmpleadoHospital
    {
        [Key]
        [Column("idempleado")]
        public int IdEmpleado { get; set; }
        [Column("apellido")]
        public String Apellido { get; set; }
        [Column("funcion")]
        public String Funcion { get; set; }

        [Column("salario")]
        public int Salario { get; set; }

        [Column("hospital_cod")]
        public int HospitalCod { get; set; }


    }
}
