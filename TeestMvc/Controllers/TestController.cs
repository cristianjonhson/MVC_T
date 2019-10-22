using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeestMvc.Models;

namespace TeestMvc.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        public ActionResult Index()
        {
            return View();
        }
        public string mensaje()
        {
            return "Ejemplo de mensaje simple";

        }


        public ActionResult mensaje2()
        {
            return Content("Mensaje 2");

        }

        public ActionResult mensaje3()
        {

            return View();
        }

        public ActionResult libro1()
        {
            Libro book = new Libro();
            book.codigo = 10;
            book.nombre = "asp mvc";
            book.precio = 1000;
            ViewData["miLibro"] = book;
            return View();

        }

        public ActionResult libro2()
        {
            Libro book = new Libro();
            book.codigo = 20;
            book.nombre = "asp mvc";
            book.precio = 2000;
            
            return View(book);

        }
        public ActionResult agregar()
        {
            return View("View2");
        }



	}
}