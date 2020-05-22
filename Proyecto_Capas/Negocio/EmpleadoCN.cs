using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmpleadoCN
    {

        private static EmpleadoDAL obj = new EmpleadoDAL();

        public static void Agregar(Empleado empleado)
        {
            obj.Agregar(empleado);
        }
        public static List<EmpleadoCE> ListarEmpleado()
        {
            return obj.ListarEmpleado();
        }

        public static EmpleadoCE obtenerEmpleado(int id)
        {
            return obj.obtenerEmpleado(id);
        }

        public static void Editar(Empleado empleado)
        {
            obj.Editar(empleado);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}
