using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

#region PROCEDIMIENTOS
//CREATE PROCEDURE MOSTRARDOCTORES
//AS
//SELECT * FROM DOCTOR
//GO

//CREATE PROCEDURE CAMBIARESPECIALIDAD
//(@IDDOCTOR INT, @ESPECIALIDAD NVARCHAR(50))
//AS
//UPDATE DOCTOR SET ESPECIALIDAD=@ESPECIALIDAD WHERE DOCTOR_NO=@IDDOCTOR
//GO
//ALTER PROCEDURE DOCTORESESPECIALIDAD
//(@ESPECIALIDAD NVARCHAR(50))
//AS
//SELECT  * FROM DOCTOR WHERE ESPECIALIDAD = @ESPECIALIDAD
//GO

//CREATE PROCEDURE ESPECIALIDADES
//AS
//SELECT DISTINCT ESPECIALIDAD FROM DOCTOR
//GO

//CREATE PROCEDURE UPDATESALARIOESPECIALIDAD
//(@AUMENTO INT, @ESPECIALIDAD NVARCHAR(50))
//AS
//UPDATE DOCTOR SET SALARIO = SALARIO + @AUMENTO WHERE ESPECIALIDAD = @ESPECIALIDAD
//GO


//ALTER VIEW EMPLEADOSHOSPITAL
//AS
//	SELECT ISNULL(EMPLEADO_NO, 0) AS IDEMPLEADO
//    , APELLIDO, FUNCION, SALARIO, HOSPITAL_COD 
//	FROM PLANTILLA
//	UNION
//	SELECT DOCTOR_NO, APELLIDO, ESPECIALIDAD, SALARIO, HOSPITAL_COD 
//	FROM DOCTOR
//GO

//CREATE PROCEDURE PROCEDUREEMPLEADOSHOSPITAL
//(@HOSPITALCOD INT, @SUMA INT OUT, @MEDIA INT OUT)
//AS
//SELECT * FROM EMPLEADOSHOSPITAL WHERE HOSPITAL_COD = @HOSPITALCOD
//SELECT @SUMA=SUM(SALARIO), @MEDIA = AVG(SALARIO)
//FROM EMPLEADOSHOSPITAL WHERE HOSPITAL_COD = @HOSPITALCOD
//GO
#endregion
namespace MvcEntityFramework.Data
{
    public class HospitalContext: DbContext
    {
        //tendra un constructor obligatorio con option para el context

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options){} // sobreescribimos las options de la clase heredada
        //debemos mapear con Dbset cada propiedad para que sea accesible
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Plantilla> Plantilla { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<EmpleadoHospital> EmpleadoHospital { get; set; }
        public DbSet<EmpleadosVistaTabla> EmpleadosVistas { get; set; }

        //CREAMOS EL PRIMER PROCEDIMIENTO DE ACCION
        public void ModificarEspecialidad(int iddoctor, String especialidad)
        {
            String sql = "CAMBIARESPECIALIDAD @IDDOCTOR, @ESPECIALIDAD";
            //NECESITAMOS PARAM PARA ENVIAR LOS DATOS AL PROCEDIMIENTO
            SqlParameter id = new SqlParameter("@IDDOCTOR", iddoctor);
            SqlParameter espe = new SqlParameter("@ESPECIALIDAD", especialidad);
            //el objeto context contiene una propiedad database
            //que se encarga de ejecutar las consultas de accion sobre la bbdd
            this.Database.ExecuteSqlRaw(sql, id, espe);

        }

    }
}
