using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    [Table("plantilla")]
    public class Plantilla
    {
        [Key]
        [Column("hospital_cod")]
        public int Hospitalcod { get; set; }
        [Column("empleado_no")]
        public int Empleadono { get; set; }
        [Column("apellido")]
        public int Apellido { get; set; }
        [Column("salario")]
        public int Salario { get; set; }
        [Column("funcion")]
        public int Funcion { get; set; }

    }
}
