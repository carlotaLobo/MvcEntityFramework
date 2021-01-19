using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    [Table("EMPLEADOSVIEW")]
    public class EmpleadosVistaTabla
    {
       [Key]
       [Column("CODIGOEMPLEADO")]
        public int CodigoEmpleado { get; set; }
        [Column("Apellido")]
        public String Apellido { get; set; }
        [Column("Trabajo")]
        public String Trabajo { get; set; }
        [Column("Salario")]
        public int Salario { get; set; }
        [Column("Codigo")]
        public int Codigo { get; set; }
        [Column("Departamento")]
        public String Departamento { get; set; }

    }
}
