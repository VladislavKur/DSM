using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProyectoGenNHibernate.CAD.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;
using ProyectoGenNHibernate.EN.Proyecto;
using frontDSM.Models;
using frontDSM.Assembler;

namespace frontDSM.Controllers
{
    public class MensajeController : BasicController
    {
        // GET: Mensaje
        public ActionResult Index()
        {
            SessionInitialize();
            MensajeCAD MensajeCAD = new MensajeCAD(session);
            MensajeCEN MensajeCEN = new MensajeCEN(MensajeCAD);

            IList<MensajeEN> listaMensajes = MensajeCEN.ReadAll(0, -1);
            IEnumerable<MensajeViewModel> listViewModel = new MensajeAssembler().ConvertListENToModel(listaMensajes).ToList();
            SessionClose();

            return View(listViewModel);

        }

        // GET: Mensaje/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mensaje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mensaje/Create
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

        // GET: Mensaje/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mensaje/Edit/5
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

        // GET: Mensaje/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mensaje/Delete/5
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
