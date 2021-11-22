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
    public class MatchController : BasicController
    {
        // GET: Match
        public ActionResult Index()
        {
            SessionInitialize();
            MatchCAD MatchCAD = new MatchCAD(session);
            MatchCEN MatchCEN = new MatchCEN(MatchCAD);

            IList<MatchEN> listaMatchs = MatchCEN.ReadAll(0, -1);
            IEnumerable<MatchViewModel> listViewModel = new MatchAssembler().ConvertListENToModel(listaMatchs).ToList();
            SessionClose();

            return View(listViewModel);
        }

        // GET: Match/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Match/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Match/Create
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

        // GET: Match/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Match/Edit/5
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

        // GET: Match/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Match/Delete/5
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
