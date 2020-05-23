using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProyectoDAL
    {

        public void Agregar(Proyecto proyecto)
        {
            using (var db =new BD_ProyectoEntities())
            {
                db.Proyecto.Add(proyecto);
                db.SaveChanges();
            }
        }
        public List<Proyecto> ListarProyecto()
        {
            using (var db = new BD_ProyectoEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                //var toDay = DateTime.Now.Date;
                //return db.Proyecto.Where(p=>p.FechaFin> toDay).ToList();
                return db.Proyecto.ToList();
            }
        }

        public Proyecto obtenerProyecto(int id)
        {
            using (var db =new BD_ProyectoEntities())
            {
                //return db.Proyecto.Where(p => p.IdProyecto == id).FirstOrDefault();
                return db.Proyecto.Find(id);
            }
        }

        public void Editar(Proyecto proyecto)
        {
            using (var db =  new BD_ProyectoEntities())
            {
                var datos = db.Proyecto.Find(proyecto.IdProyecto);
                datos.NombreProyecto = proyecto.NombreProyecto;
                datos.FechaInicio = proyecto.FechaInicio;
                datos.FechaFin = proyecto.FechaFin;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db=new BD_ProyectoEntities())
            {
                var proyecto = db.Proyecto.Find(id);
                db.Proyecto.Remove(proyecto);
                db.SaveChanges();
            }
        }

        public bool ExisteAsignacion(int idproyecto, int idempleado)
        {
            using (var db = new BD_ProyectoEntities())
            {
                var existeAsignacion = db.ProyectoEmpleado.Any(p=>p.IdProyecto== idproyecto && p.IdEmpleado== idempleado);  // determina si contiene elementos y devuelve true si tiene y no sino tiene elementos
                return existeAsignacion;
            }
        }

        public bool EsProyectoActivo(int idproyecto)
        {
            using (var db = new BD_ProyectoEntities())
            {
                var toDay = DateTime.Now.Date;
                var proyectoActive = db.Proyecto.Any(p => p.IdProyecto == idproyecto && p.FechaFin > toDay);  // determina si contiene elementos y devuelve true si tiene y no sino tiene elementos
                return proyectoActive;
            }
        }
        public void AsignarProyecto(int idproyecto, int idempleado)
        {
            var proyectoEmp = new ProyectoEmpleado
            {
                IdProyecto = idproyecto,
                IdEmpleado = idempleado,
                FechaAlta = DateTime.Now
            };

            using (var db = new BD_ProyectoEntities())
            {
                db.ProyectoEmpleado.Add(proyectoEmp);
                db.SaveChanges();
            }
        }

        public List<ProyectoEmpleadoCE> ListarAsignaciones()
        {
            string sql = @"select pe.IdProyecto,p.NombreProyecto, pe.IdEmpleado,e.Apellidos,e.Nombres, pe.FechaAlta
                            from ProyectoEmpleado pe inner join Proyecto p
                            on pe.IdProyecto=p.IdProyecto inner join Empleado e
                            on pe.IdEmpleado=e.IdEmpleado";
            using (var db = new BD_ProyectoEntities())
            {
                return db.Database.SqlQuery<ProyectoEmpleadoCE>(sql).ToList();
            }
        }
    }
}








