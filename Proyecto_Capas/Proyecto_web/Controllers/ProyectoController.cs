using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_web.Controllers
{
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
        public ActionResult Crear(Proyecto proyecto)
        {
            try
            {
                ProyectoCN.Agregar(proyecto);
                return RedirectToAction("Inicio");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "ocurrio un error al agregar un proyecto ");
                return View();
            }
        }
    }
}