using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProyectoCN
    {
        private static ProyectoDAL obj = new ProyectoDAL();

        public static void Agregar(Proyecto proyecto)
        {
            obj.Agregar(proyecto);
        }
        public static List<Proyecto> ListarProyecto()
        {
            return obj.ListarProyecto();
        }

        public static Proyecto obtenerProyecto(int id)
        {
            return obj.obtenerProyecto(id);
        }

        public static void Editar(Proyecto proyecto)
        {
            obj.Editar(proyecto);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }

    }
}
