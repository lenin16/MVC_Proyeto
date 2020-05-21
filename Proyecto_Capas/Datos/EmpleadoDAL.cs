using Entidad;
using System;
using System.Collections.Generic;
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
        public List<Empleado> ListarEmpleado()
        {
            using (var db = new BD_ProyectoEntities())
            {
                return db.Empleado.ToList();
            }
        }

        public Empleado obtenerEmpleado(int id)
        {
            using (var db = new BD_ProyectoEntities())
            {
                //return db.Empleado.Where(p => p.IdEmpleado == id).FirstOrDefault();
                return db.Empleado.Find(id);
            }
        }

        public void Editar(Empleado empleado)
        {
            using (var db = new BD_ProyectoEntities())
            {
                var datos = db.Empleado.Find(empleado.IdEmpleado);
                datos.Nombres = empleado.Nombres;
                datos.Apellidos = empleado.Apellidos;
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
