using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EmpleadoDAL
    {

        public void Agregar(Empleado empleado)
        {
            using (var db = new BD_ProyectoEntities())
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
            }
        }
        public List<EmpleadoCE> ListarEmpleado()
        {
            string sql = @"select IdEmpleado, Nombres, Apellidos, Email, Direccion, Celular, 
	                           e.IdDepartamento,d.NombreDepartamento
                        from Empleado e inner join Departamento d
                        on e.IdDepartamento=d.IdDepartamento ";

            using (var db = new BD_ProyectoEntities())
            {
                
                return db.Database.SqlQuery<EmpleadoCE>(sql).ToList();
            }

           /* using (var db = new BD_ProyectoEntities())
            {
                //return db.Empleado.ToList();

                var data = from e in db.Empleado
                           join d in db.Departamento
                           on e.IdDepartamento equals d.IdDepartamento
                           select new EmpleadoCE()
                           {
                               IdEmpleado = e.IdEmpleado,
                               Nombres = e.Nombres,
                               Apellidos = e.Apellidos,
                               Email=e.Email,
                               Direccion=e.Direccion,
                               Celular=e.Celular,
                               IdDepartamento=e.IdDepartamento,
                               NombreDepartamento=d.NombreDepartamento
                           };

                return data.ToList();
            }*/
        }

        public EmpleadoCE obtenerEmpleado(int id)
        {
            string sql = @"select IdEmpleado, Nombres, Apellidos, Email, Direccion, Celular, 
	                           e.IdDepartamento,d.NombreDepartamento
                        from Empleado e inner join Departamento d
                        on e.IdDepartamento=d.IdDepartamento     
                        where IdEmpleado=@IdEmpleado";

            using (var db = new BD_ProyectoEntities())
            {
                //return db.Empleado.Where(p => p.IdEmpleado == id).FirstOrDefault();
                //return db.Empleado.Find(id);

                return db.Database.SqlQuery<EmpleadoCE>(sql, new SqlParameter("@IdEmpleado", id)).FirstOrDefault();
            }
        }
        /*
        public Empleado obtenerEmpleado2(int id)
        {
            using (var db = new BD_ProyectoEntities())
            {
                return db.Empleado.Find(id);
            }
        }*/
        
        public void Editar(Empleado empleado)
        {
            using (var db = new BD_ProyectoEntities())
            {
                var datos = db.Empleado.Find(empleado.IdEmpleado);
                datos.Nombres = empleado.Nombres;
                datos.Apellidos = empleado.Apellidos;
                datos.Email = empleado.Email;
                datos.Direccion = empleado.Direccion;
                datos.Celular = empleado.Celular;
                datos.IdDepartamento = empleado.IdDepartamento;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new BD_ProyectoEntities())
            {
                var empleado = db.Empleado.Find(id);
                db.Empleado.Remove(empleado);
                db.SaveChanges();
            }
        }
    }
}
