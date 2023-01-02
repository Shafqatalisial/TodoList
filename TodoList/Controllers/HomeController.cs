using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Index(tble_todo tdo)
        {
            todoDbcontext db = new todoDbcontext();
            db.tble_todo.Add(tdo);
                db.SaveChanges();
            
            return View();
        }

        public ActionResult ViewTask(tble_todo td)
        {
            todoDbcontext db = new todoDbcontext();
            var datta=db.tble_todo.ToList(); 
             
            return View(datta);
        }

        public ActionResult Edit(int id)
        {
            todoDbcontext db = new todoDbcontext();
           var recd= db.tble_todo.Find(id);
            return View(recd);
        }
        [HttpPost]
        public ActionResult Edit(tble_todo Chng)
        {
            todoDbcontext db = new todoDbcontext();
            db.Entry(Chng).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            todoDbcontext db = new todoDbcontext();
            var dated = db.tble_todo.Find(id);
            db.tble_todo.Remove(dated);
            db.SaveChanges();
            return RedirectToAction("ViewTask");
        }
    }

}