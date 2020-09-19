using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD_DiplomadoUASD_AJAX.Models;

namespace MVC_CRUD_DiplomadoUASD_AJAX.Controllers
{
    public class HomeController : Controller
    {
        EmpleadoDB empDB = new EmpleadoDB();
        SessionData session = new SessionData();

        public ActionResult Index()
        {
            return View(empDB.ListAll());
        }

        public JsonResult List()
        {
            return Json(empDB.ListAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(Empleado emp)
        {
            return Json(empDB.Add(emp), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID(int ID)
        {
            var empleado = empDB.ListAll().Find(x => x.EmpleadoID.Equals(ID));
            return Json(empleado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Empleado emp)
        {
            return Json(empDB.Update(emp), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int ID)
        {
            return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Usuarios(UserLogin datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.login() == true)
                {
                    session.setSession("userName", datos.Username);
                    ViewBag.User = session.getSession("userName");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Error";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [AllowAnonymous]
        public async Task<ActionResult> SinIn()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> SinIn(SignIn datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.Signin() == false)
                {
                    ViewBag.Message = "El usuario o Email ya esta registrado";
                    return View("SignIn", datos);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View("SignIn");
            }
        }

    }

}