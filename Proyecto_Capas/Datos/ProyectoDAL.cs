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
    }
}
