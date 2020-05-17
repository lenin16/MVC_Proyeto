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
    }
}
