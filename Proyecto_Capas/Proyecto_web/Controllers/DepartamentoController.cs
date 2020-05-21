using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_web.Controllers
{

    [Authorize(Roles = "Admin")]
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult InicioDepartamento()
        {
            var dpto = DepartamentoCN.ListarDepartamentos();
            return View(dpto);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Departamento dpto)
        {
            try
            {
                if (dpto.NombreDepartamento == null)
                {
                    ModelState.AddModelError("", "Debe ingresar nombre de departamento");
                    return View(dpto);
                }
                DepartamentoCN.Agregar(dpto);
                return RedirectToAction("InicioDepartamento");
            }
            catch (Exception ep)
            {

                ModelState.AddModelError("","ocurrio un error al agregar departamento ");
                return View(dpto);
            }                   
        }

        public ActionResult GetDepartamento(int id)
        {
            var dpto = DepartamentoCN.GetDepartamento(id);
            return View(dpto);
        }

        public JsonResult GetDepartamentos()
        {
            var lista = DepartamentoCN.ListarDepartamentos();
            return Json(new { data=lista},JsonRequestBehavior.AllowGet);
        }

        public ActionResult Editar(int id)
        {
            var dpto = DepartamentoCN.GetDepartamento(id);
            return View(dpto);
        }

        [HttpPost]
        public ActionResult Editar(Departamento dpto)
        {
            try
            {
                if (dpto.NombreDepartamento == null)
                {
                    ModelState.AddModelError("", "Debe ingresar nombre de departamento");
                    return View(dpto);
                }
                DepartamentoCN.Editar(dpto);
                return RedirectToAction("InicioDepartamento");
            }
            catch (Exception ep)
            {

                ModelState.AddModelError("", "ocurrio un error al editar departamento ");
                return View(dpto);
            }
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var dpto = DepartamentoCN.GetDepartamento(id.Value);
            return View(dpto);
        }


        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                DepartamentoCN.Eliminar(id);
                return RedirectToAction("InicioDepartamento");
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "ocurrio un error al eliminar departamento ");
                return View();
            }
        }


    }
}