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

    }
}
