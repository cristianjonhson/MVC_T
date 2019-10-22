using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeestMvc.Models;
namespace TeestMvc.Controllers
{
    public class LibroController : Controller
    {
        //
        // GET: /Libro/
        public ActionResult Index()
        {
            return View();



        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Libro l)
        {
            if (ModelState.IsValid)
            {
                Libro b = new Libro();
                b.codigo = l.codigo;
                b.nombre = l.nombre;
                b.precio = l.precio;
                b.grabar();
                //return Content(l.nombre + "Grabado Ok");
                return RedirectToAction("lista");
                
            
            }
            else
                return View();
        }


        public ActionResult lista()
        {
            var lis =new List<Libro>();
            lis=Libro.Catologo();
            return View(lis);

        }
        public ActionResult editar(int id)
        {
            Libro l =new Libro();
            l.codigo=id;
            l.leer();

            return View(l);
        }
        [HttpPost]
        public ActionResult editar(Libro l)
        {
            if (ModelState.IsValid)
            {
                Libro b = new Libro();
                b.codigo = l.codigo;
                b.nombre = l.nombre;
                b.precio = l.precio;
                b.actualizar();
                //return Content(l.nombre + "Grabado Ok");
                return RedirectToAction("lista");


            }
            else
                return View();
        }

        
        public ActionResult eliminar(int id)
        {
            Libro b = new Libro();
            b.codigo = id;
            b.leer();
                        //return Content(l.nombre + "Grabado Ok");
            return View();
 
        }
        [HttpPost,ActionName("eliminar")]
         public ActionResult eliminarConfirmado(int id)
         {
             Libro l = new Libro();
             l.codigo = id;
             l.eliminar();
             return RedirectToAction("lista");
         }
        public ActionResult printRpt(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reportes"), "report.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return Content("No encuentra el reporte");
            }
            //List<StateArea> cm = new List<StateArea>();
            //using (PopulationEntities dc = new PopulationEntities())
            //{
            //    cm = dc.StateAreas.ToList();
            //}
    
            List<Libro> cm = new List<Libro>();
            cm = Libro.Catologo();
            ReportDataSource rd = new ReportDataSource("DataSet1", cm);
            
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);


            return File(renderedBytes, mimeType);
        }
    
    }
}