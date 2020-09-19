using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD_DiplomadoUASD_AJAX.Models;

namespace MVC_CRUD_DiplomadoUASD_AJAX.Controllers
{
    public class UserController : Controller
    {
        SessionData session = new SessionData();

        UsersDataDataContext user = new UsersDataDataContext();

        // GET: User
        public ActionResult Users()
        {
            ViewBag.User = session.getSession("userName");
            if (ViewBag.User == "")
            {
                return RedirectToAction("Usuarios", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Registros()
        {
            return View(user.Users.ToList());
        }

        public ActionResult Close()
        {
            session.destroySession();
            return RedirectToAction("Usuarios", "Home");
        }
    }
}