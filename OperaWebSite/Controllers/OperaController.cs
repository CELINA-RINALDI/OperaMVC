using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OperaWebSite.Models;
using OperaWebSite.Data;
using System.Data.Entity;
using System.Diagnostics;
using OperaWebSite.Filters; 

namespace OperaWebSite.Controllers
{
    [MyFilterAction]
    public class OperaController : Controller
    {
        // crear una instancia del dbcontext
       private OperaDbContext context = new OperaDbContext();
        // GET: Opera
        public ActionResult Index()
        {
            ViewBag.Fecha = DateTime.Now.ToShortDateString();
            // traer todas las operas usando EF
            var operas = context.Operas.ToList();

            // el controller retorna una vista "index" con la lista de operas
            return View("Index", operas);
        }

        //Creamos dos metodos para la insercion de la opera en la db
        
        // primer create por GET para retornar la vista de registro

        [HttpGet] // el get es implicito, pero se puede especificar
        public ActionResult Create()
        {
            // creamos la instancia vacia
            Opera opera = new Opera();

            // retornamos la vista "create" que le pedira al usuario llenar la instancia creada
            return View("Create", opera);
        }

        // segundo create es por post para insertar la nueva opera en la base
        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            if(ModelState.IsValid)
            {
                context.Operas.Add(opera);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", opera);
        }


        // GET
        //Opera/Detail/id
        public ActionResult Detail(int id)
        {
            Opera opera = context.Operas.Find(id); 
            if(opera != null)
            {
                return View("Detail", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Delete(int id)
        {
            Opera opera = context.Operas.Find(id);
            if (opera != null)
            {
                return View("Delete", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }


        //Opera/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Opera opera = context.Operas.Find(id);
            context.Operas.Remove(opera);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Opera opera = context.Operas.Find(id); 
            if(opera != null)
            {
                return View("Edit", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }



        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Opera opera)
        {
            if(ModelState.IsValid)
            {
                context.Entry(opera).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", opera); 
        }
        public ActionResult SearchByYear(int year)
        {
            if (year == 0)
            {
                return RedirectToAction("Index");
            }
            List<Opera> operasYear = (from o in context.Operas
                                      where o.Year == year
                                      select o).ToList();
            return View("Index", operasYear);
        }


     /*   // FITLRO DE ACCION - ANTES 
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            Debug.WriteLine("controller: " + controller + "action: " + action + " Paso por OnActionExecuting");
        }

        // FILTRO DE AACION - DESPUES
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            Debug.WriteLine("controller: " + controller + "action: " + action + " Paso por OnActionExecuted");
        }   */

    }
}