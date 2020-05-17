using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DepartamentoCN
    {
        private static DepartamentoDAL obj = new DepartamentoDAL();
        public static void Agregar(Departamento dpto)
        {
            obj.Agregar(dpto);
        }
        public static List<Departamento> ListarDepartamentos()
        {
            return obj.ListarDepartamentos();  
        }

        public static Departamento GetDepartamento(int id)
        {
            return obj.GetDepartamento(id);
        }

        public static void Editar(Departamento dpto)
        {
            obj.Editar(dpto);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}
