using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD_DiplomadoUASD_AJAX.Models;

namespace MVC_CRUD_DiplomadoUASD_AJAX.Controllers
{
    public class RegistroController : Controller
    {
        UsersDataDataContext user = new UsersDataDataContext();

        // GET: Registros
        public ActionResult Index()
        {
            return View(user.Users.ToList());
        }

        // GET: Registros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var usuario = from u in user.Users where u.IdUser == id select u;

            if (usuario == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                foreach (var item in usuario)
                {
                    return View(item);
                }
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Registros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var usuario = from u in user.Users where u.IdUser == id select u;

            if (usuario == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                foreach (var item in usuario)
                {
                    return View(item);
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: Registros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUser, Name, LastName, UserName, Password, Email")] User userData)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    UserUtil.EditarUser(userData);

                    return RedirectToAction("Index");
                }

                return View(userData);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        // GET: Registros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var usuario = from u in user.Users where u.IdUser == id select u;

            if (usuario == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                foreach (var item in usuario)
                {
                    return View(item);
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int Id)
        {
            try
            {
                var DelUs = from u in user.Users where u.IdUser == Id select u;

                if (ModelState.IsValid)
                {
                    foreach (var item in DelUs)
                    {
                        UserUtil.DelUser(item.IdUser);
                    }

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
