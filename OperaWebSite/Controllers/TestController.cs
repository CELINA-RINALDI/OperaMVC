using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperaWebSite.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Login(string name, string role)
        {
            // ViewBag lo usamos para pasar datos del controlador a la vista
            ViewBag.Name = name;      // name y rol como propiedades no existen , se estan creando ahora
            ViewBag.Role = role;
            return View();
        }

        public ActionResult SearchByTitle(string title)
        {
            ViewBag.Title = title;
            return View();
        }
    }
}