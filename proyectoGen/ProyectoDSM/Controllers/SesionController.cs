using ProyectoDSM.Assembler;
using ProyectoDSM.Models;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;
using ProyectoGenNHibernate.CAD.Proyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoDSM.Controllers
{
    public class SesionController : BasicController
    {
        // GET: Sesion
        public ActionResult Index()
        {
            SessionInitialize();
            SesionCAD SesionCAD = new SesionCAD(session);
            SesionCEN SesionCEN = new SesionCEN(SesionCAD);

            IList<SesionEN> listaSesions = SesionCEN.ReadAll(0, -1);
            IEnumerable<SesionViewModel> listViewModel = new SesionAssembler().ConvertListENToModel(listaSesions).ToList();
            SessionClose();

            return View(listViewModel);
        }

        // GET: Sesion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sesion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sesion/Create
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

        // GET: Sesion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sesion/Edit/5
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

        // GET: Sesion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sesion/Delete/5
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
