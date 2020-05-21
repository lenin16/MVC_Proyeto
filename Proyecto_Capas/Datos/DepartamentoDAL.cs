using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DepartamentoDAL
    {
        public void Agregar(Departamento dpto)
        {
            using (var db = new BD_ProyectoEntities())
            {
                db.Departamento.Add(dpto);
                db.SaveChanges();
            }
        }
        public List<Departamento> ListarDepartamentos()
        {
            using (var db = new BD_ProyectoEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Departamento.ToList();
            }
        }

        public Departamento GetDepartamento(int id)
        {
            using (var db = new BD_ProyectoEntities())
            {
                //return db.Departamento.Find(id);
                return db.Departamento.Where(d => d.IdDepartamento == id).FirstOrDefault();
            }
        }

        public void Editar(Departamento dpto)
        {
            using (var db = new BD_ProyectoEntities())
            {
                var d = db.Departamento.Find(dpto.IdDepartamento);
                d.NombreDepartamento = dpto.NombreDepartamento;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new BD_ProyectoEntities())
            {
                var dpto = db.Departamento.Find(id);
                db.Departamento.Remove(dpto);
                db.SaveChanges();
            }
        }
    }
}
