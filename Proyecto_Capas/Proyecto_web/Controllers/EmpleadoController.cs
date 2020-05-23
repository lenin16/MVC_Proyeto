using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_web.Controllers
{

    [Authorize(Roles = "Admin")]
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Inicio()
        {

            var empleado = EmpleadoCN.ListarEmpleado();
            return View(empleado);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Empleado empleado)
        {
            try
            {
                if (empleado.Nombres == null && empleado.Apellidos == null && empleado.Email == null)
                    return Json(new { ok = false, msg = "Debe ingresar el nombre del empleado" }, JsonRequestBehavior.AllowGet);

                /* System.Threading.Thread.Sleep(2000);  suspende por dos segundos la carga del formulario para hacer prueba*/

                EmpleadoCN.Agregar(empleado);
                return Json(new { ok = true, toRedirect = Url.Action("Inicio") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Inicio");
            }
            catch (Exception ep)
            {
                return Json(new { ok = false, msg = ep.Message }, JsonRequestBehavior.AllowGet);
                //ModelState.AddModelError("", "ocurrio un error al agregar un proyecto ");
                //return View();
            }
        }

        public ActionResult Detalles(int id)
        {
            var empleado = EmpleadoCN.obtenerEmpleado(id);
            return View(empleado);
        }

        public ActionResult Editar(int id)
        {
            var empleado = EmpleadoCN.obtenerEmpleado(id);
            return View(empleado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Empleado empleado)
        {
            try
            {
                EmpleadoCN.Editar(empleado);
                return Json(new { ok = true, toRedirect = Url.Action("Inicio") }, JsonRequestBehavior.AllowGet);
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
                EmpleadoCN.Eliminar(id);
                return Json(new { ok = true, toRedirect = Url.Action("Inicio") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ep)
            {

                return Json(new { ok = false, msg = ep.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ListarEmpleados()
        {
            try
            {
                var lista = EmpleadoCN.ListarEmpleado();
                return Json(new { data=lista},JsonRequestBehavior.AllowGet);
            }
            catch (Exception ep)
            {

                return Json(new { ok = false, msg = ep.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}