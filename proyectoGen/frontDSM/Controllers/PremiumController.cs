using frontDSM.Controllers;
using ProyectoGenNHibernate.CAD.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;
using ProyectoGenNHibernate.EN.Proyecto;
using frontDSM.Models;

using frontDSM.Assembler;
using ProyectoGenNHibernate.Enumerated.Proyecto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace frontDSM.Controllers
{
    public class PremiumController : BasicController
    {
        // GET: Premium
        public ActionResult Index()
        {
            SessionInitialize();
            PremiumCAD premiumCAD = new PremiumCAD(session);
            PremiumCEN premiumCEN = new PremiumCEN(premiumCAD);

            IList<PremiumEN> listaPremiums = premiumCEN.ReadAll(0, -1);
            IEnumerable<PremiumViewModel> listViewModel = new PremiumAssembler().ConvertListENToModel(listaPremiums).ToList();
            SessionClose();

            return View(listViewModel);
        }


        // GET: Premium/Details/5
        public ActionResult Details(int id)
        {
            PremiumViewModel prem = null;
            SessionInitialize();

            PremiumEN premiumEN = new PremiumCAD(session).ReadOIDDefault(id);
            prem = new PremiumAssembler().ConvertENToModelUI(premiumEN);

            SessionClose();
            return View(prem);

        }

        // GET: Premium/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Premium/Create
        [HttpPost]
        public ActionResult Create(PremiumViewModel prem )
        {
            try
            {
                // TODO: Add insert logic here
                PremiumCEN premiumCEN = new PremiumCEN();
                premiumCEN.New_(prem.Precio,prem.EstadoCompra,prem.Fecha_compra);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Premium/Edit/5
        public ActionResult Edit(int id)
        {
         
            return View();
        }

        // POST: Premium/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PremiumViewModel prem)
        {
            try
            {
                // TODO: Add update logic here
                PremiumCEN premiumCEN = new PremiumCEN();
                premiumCEN.Modify(prem.Id, prem.Precio, prem.EstadoCompra, prem.Fecha_compra);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Premium/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                PremiumCEN premiumCEN = new PremiumCEN();
                premiumCEN.Destroy(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Premium/Delete/5
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
