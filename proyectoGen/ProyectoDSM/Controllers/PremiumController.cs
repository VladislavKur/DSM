using ProyectoDSM.Controllers;
using ProyectoGenNHibernate.CAD.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoDSM.Models;

using ProyectoDSM.Assembler;
using ProyectoGenNHibernate.Enumerated.Proyecto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProyectoDSM.Controllers
{
    public class PremiumController : BasicController
    {
        // GET: Premium
        public ActionResult Index(int pagina=-1)
        {
            SessionInitialize();
            PremiumCAD premiumCAD = new PremiumCAD(session);
            PremiumCEN premiumCEN = new PremiumCEN(premiumCAD);

            //IList<PremiumEN> listaPremiums = premiumCEN.ReadAll(0, -1);
            if (pagina == -1)
                pagina = 0;
            IList<PremiumEN> listaPremiums = premiumCEN.ReadAll(((pagina) * 10), ((pagina)*10)+10 );
            IEnumerable<PremiumViewModel> listViewModel = new PremiumAssembler().ConvertListENToModel(listaPremiums).ToList();
            SessionClose();
            ViewData["pagina"] = pagina;
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
            PremiumViewModel art = new PremiumViewModel();
            //art.IdCategoria = id;
            return View(art);
            
        }

        // POST: Premium/Create
        [HttpPost]
        public ActionResult Create(PremiumViewModel prem )
        {
            try
            {
                //Como hago todas las fases de la compra?
                // TODO: Add insert logic here
                UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                PremiumCEN premiumCEN = new PremiumCEN();
                int idPremium = premiumCEN.New_(prem.Precio,prem.EstadoCompra);
                //usuarioCEN.AsignarPremium(usuario.Id, idPremium);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CrearPremium()
        {
            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            PremiumCEN premiumCEN = new PremiumCEN();

            try
            {
                int idPremium = premiumCEN.New_(9.99, EstadoCompraEnum.pendiente);
                Session["idPremium"] = idPremium;
                return RedirectToAction("ListaDetalles", new { id = idPremium });
            }
            catch
            {
                return View();
            }

        }

        // POST: Premium/Create
        [HttpPost]
        public ActionResult CrearPremium(PremiumViewModel prem)
        {
            try
            {
                //Como hago todas las fases de la compra?
                // TODO: Add insert logic here
                UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                PremiumCEN premiumCEN = new PremiumCEN();
                int idPremium = premiumCEN.New_(prem.Precio, prem.EstadoCompra);
                //usuarioCEN.AsignarPremium(usuario.Id, idPremium);

                return RedirectToAction("CrearPremium");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ListaDetalles(int id)
        {
            PremiumViewModel prem = null;
            SessionInitialize();

            PremiumEN premiumEN = new PremiumCAD(session).ReadOIDDefault(id);
            prem = new PremiumAssembler().ConvertENToModelUI(premiumEN);

            SessionClose();
            return View(prem);

        }

        public ActionResult Inicial()
        {
            ViewBag.Message = "La pagina inicial de Compra del Premium";

            return View();
        }

        public ActionResult Aceptar(int id)
        {
            SessionInitialize();
            PremiumCEN premiumCEN = new PremiumCEN();
            UsuarioCAD usuarioCAD = new UsuarioCAD();
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            int idPremium = (int)Session["idPremium"];
            usuarioCEN.AsignarPremium(usuario.Id, idPremium);
            SessionClose();
            premiumCEN.ModificaPremium(idPremium,  EstadoCompraEnum.realizado);
            
            return RedirectToAction("Realizado");

        }

        public ActionResult Rechazar(int id)
        {

            PremiumCEN premiumCEN = new PremiumCEN();
            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            int idPremium = (int)Session["idPremium"];

            premiumCEN.ModificaPremium(idPremium, EstadoCompraEnum.cancelado);

            return RedirectToAction("Rechazado");

        }
        public ActionResult Realizado()
        {
            ViewBag.Message = "La compra se ha realizado";

            return View();
        }
        public ActionResult Rechazado()
        {
            ViewBag.Message = "La compra se ha cancelado";

            return View();
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
                premiumCEN.ModificaPremium(prem.Id, prem.EstadoCompra);

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
