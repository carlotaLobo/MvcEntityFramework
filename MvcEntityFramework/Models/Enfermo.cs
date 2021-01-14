﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    [Table("ENFERMO")]
    public class Enfermo
    {
        [Key]
        [Column("INSCRIPCION")]
        // siempre que haya PK en la bbdd hay qu eponerlo
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Inscripcion { get; set; }
        [Column("APELLIDO")]
        public String Apellido { get; set; }
        [Column("DIRECCION")]
        public String Direccion { get; set; }
        [Column("FECHA_NAC")]
        public DateTime Fechanac { get; set; }
        [Column("S")]
        public String Sexo { get; set; }
        [Column("NSS")]
        public String SeguridadSocial { get; set; }
    }
}
