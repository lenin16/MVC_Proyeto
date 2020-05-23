using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_web.Controllers
{

    [Authorize(Roles ="Admin")]
    public class ProyectoController : Controller
    {
        // GET: Proyecto
        public ActionResult Inicio()
        {

            var proyecto = ProyectoCN.ListarProyecto();
            return View(proyecto);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Proyecto proyecto)
        {
            try
            {
                if (proyecto.NombreProyecto==null)
                    return Json(new { ok = false,msg="Debe ingresar el nombre del proyecto" }, JsonRequestBehavior.AllowGet);

               /* System.Threading.Thread.Sleep(2000);  suspende por dos segundos la carga del formulario para hacer prueba*/

                ProyectoCN.Agregar(proyecto);
                return Json(new { ok=true,toRedirect= Url.Action("Inicio") },JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Inicio");
            }
            catch (Exception ep)
            {
                return Json(new { ok = false,msg=ep.Message }, JsonRequestBehavior.AllowGet);
                //ModelState.AddModelError("", "ocurrio un error al agregar un proyecto ");
                //return View();
            }
        }

        public ActionResult Detalles(int id)
        {
            var proyecto = ProyectoCN.obtenerProyecto(id);
            return View(proyecto);
        }

        public ActionResult Editar(int id)
        {
            var proyecto = ProyectoCN.obtenerProyecto(id);
            return View(proyecto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Proyecto proyecto)
        {
            try
            {
                ProyectoCN.Editar(proyecto);
                return Json(new { ok=true,toRedirect=Url.Action("Inicio")},JsonRequestBehavior.AllowGet);
            }
            catch (Exception ep)
            {
                return Json(new { ok = false, msg = ep.Message }, JsonRequestBehavior.AllowGet);
            }
            
        }


        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                ProyectoCN.Eliminar(id);
                return Json(new { ok = true, toRedirect = Url.Action("Inicio") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ep)
            {

                return Json(new { ok = false, msg = ep.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ListarProyecto()
        {
            try
            {
                var lista = ProyectoCN.ListarProyecto();
                return Json(new { data=lista},JsonRequestBehavior.AllowGet);
            }
            catch (Exception ep)
            {

                return Json(new { ok = false, msg = ep.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AsignarProyecto()
        {
            return View(ProyectoCN.ListarAsignaciones());
        }

        [HttpPost]
        public ActionResult AsignarProyecto(int idproyecto, int idempleado)
        {
            try
            {
                if (ProyectoCN.ExisteAsignacion(idproyecto, idempleado))
                    return Json(new { ok=false,msg="ya exite este proyecto con este empleado"});

                if(!ProyectoCN.EsProyectoActivo(idproyecto))
                    return Json(new { ok = false, msg = "El proyecto ya no se encuentra activo" });

                ProyectoCN.AsignarProyecto(idproyecto, idempleado);
                return Json(new { ok = true, toRedirect=Url.Action("AsignarProyecto") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ep)
            {

                return Json(new { ok = false, msg = ep.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Eliminar_asignacion(int idproyecto, int idempleado)
        {
            try
            {
                ProyectoCN.Eliminar_asignacion(idproyecto, idempleado);
                return Json(new { ok = true, toRedirect = Url.Action("AsignarProyecto") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ep)
            {

                return Json(new { ok = false, msg = ep.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}