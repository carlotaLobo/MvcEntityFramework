using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcEntityFramework.Models
{
    [Table("HOSPITAL")]
    public class Hospital
    {
        [Key]
        [Column("HOSPITAL_COD")]
        public int Idhospital { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("DIRECCION")]
        public String Direccion { get; set; }
        [Column("TELEFONO")]
        public String Telefono { get; set; }
        [Column("NUM_CAMA")]
        public int NumeroCamas { get; set; }
    }
}
