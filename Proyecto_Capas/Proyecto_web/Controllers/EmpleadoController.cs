using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult RptEmpleado()
        {
            return View();
        }

        /*
         sin parametro 
        public ActionResult DescargarReporte_empleado()
        {            
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reportes/EmpleadoReporte.rpt");
                rptH.Load();

                // Report connection
                var conInfo = CrystalReportCn.GetConnectionInfo();
                TableLogOnInfo logonInfo = new TableLogOnInfo();
                Tables tables;
                tables = rptH.Database.Tables;
                foreach (Table table in tables)
                {
                    logonInfo = table.LogOnInfo;
                    logonInfo.ConnectionInfo = conInfo;
                    table.ApplyLogOnInfo(logonInfo);
                }

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                Stream stream = rptH.ExportToStream(ExportFormatType.PortableDocFormat);
                rptH.Dispose();
                rptH.Close();
                return new FileStreamResult(stream, "application/pdf");

                //Stream stream = rptH.ExportToStream(ExportFormatType.Excel);
                //stream.Seek(0,SeekOrigin.Begin);
                //return File(stream, "application/vnd.ms-excel","EmpleadoRpt.xls");
            }
            catch (Exception ep)
            {

                throw;
            }
        }  */


            //con parametro
        public ActionResult DescargarReporte_empleado( int Codigo,string algo)
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reportes/EmpleadoReporte.rpt");
                rptH.Load();

                rptH.SetParameterValue("IdDpto", Codigo);
                //rptH.SetParameterValue("Nuevo_Parametro", algo);

                // Report connection
                var conInfo = CrystalReportCn.GetConnectionInfo();
                TableLogOnInfo logonInfo = new TableLogOnInfo();
                Tables tables;
                tables = rptH.Database.Tables;
                foreach (Table table in tables)
                {
                    logonInfo = table.LogOnInfo;
                    logonInfo.ConnectionInfo = conInfo;
                    table.ApplyLogOnInfo(logonInfo);
                }

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                Stream stream = rptH.ExportToStream(ExportFormatType.PortableDocFormat);
                rptH.Dispose();
                rptH.Close();
                return new FileStreamResult(stream, "application/pdf");

                //Stream stream = rptH.ExportToStream(ExportFormatType.Excel);
                //stream.Seek(0,SeekOrigin.Begin);
                //return File(stream, "application/vnd.ms-excel","EmpleadoRpt.xls");
            }
            catch (Exception ep)
            {

                throw;
            }
        }
    }
}