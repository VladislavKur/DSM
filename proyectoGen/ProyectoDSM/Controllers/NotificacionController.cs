using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProyectoGenNHibernate.CAD.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoDSM.Models;
using ProyectoDSM.Assembler;

namespace ProyectoDSM.Controllers
{
    public class NotificacionController : BasicController
    {
        // GET: Notificacion
        public ActionResult Index()
        {
            SessionInitialize();
            NotificacionCAD NotificacionCAD = new NotificacionCAD(session);
            NotificacionCEN NotificacionCEN = new NotificacionCEN(NotificacionCAD);

            IList<NotificacionEN> listaNotificacions = NotificacionCEN.ReadAll(0, -1);
            IEnumerable<NotificacionViewModel> listViewModel = new NotificacionAssembler().ConvertListENToModel(listaNotificacions).ToList();
            SessionClose();

            return View(listViewModel);

        }

        // GET: Notificacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Notificacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notificacion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notificacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Notificacion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notificacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Notificacion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
