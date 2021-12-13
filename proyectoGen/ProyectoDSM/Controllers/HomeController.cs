using ProyectoDSM.Assembler;
using ProyectoDSM.Controllers;
using ProyectoDSM.Models;
using ProyectoGenNHibernate.CAD.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;
using ProyectoGenNHibernate.EN.Proyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoDSM.Controllers
{
    public class HomeController : BasicController
    {
        public ActionResult Index()
        {
            SessionInitialize();


            UsuarioCEN usuarioCE = new UsuarioCEN();
             IList<UsuarioEN> a = usuarioCE.ReadAll(0, -1);
            return View(a);
        }
        public ActionResult Details(int id)
        {
            UsuarioViewModel usu = null;
            SessionInitialize();

            UsuarioEN usuarioEN = new UsuarioCAD(session).ReadOIDDefault(id);
            usu = new UsuarioAssembler().ConvertENToModelUI(usuarioEN);

            SessionClose();
            return View(usu);

        }

        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                
                SessionInitialize();
                UsuarioCAD artCAD = new UsuarioCAD(session);
                UsuarioCEN cen = new UsuarioCEN(artCAD);
                UsuarioEN artEN = cen.ReadOID(id);
                UsuarioViewModel art = new UsuarioAssembler().ConvertENToModelUI(artEN);
               
                SessionClose();

                new UsuarioCEN().Destroy(id);


                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
            /*UsuarioViewModel art = null;
            SessionInitialize();
            UsuarioEN artEN = new UsuarioCAD(session).ReadOIDDefault(id);
            art = new UsuarioAssembler().ConvertENToModelUI(artEN);
            SessionClose();
            return View(art);*/
        }
        [HttpPost]
        public ActionResult Delete(int id, UsuarioViewModel usu)
        {
            try
            {
               
                UsuarioCEN cen = new UsuarioCEN();
                UsuarioEN artEN = cen.ReadOID(id);
                UsuarioViewModel art = new UsuarioAssembler().ConvertENToModelUI(artEN);


                
                //cen = new UsuarioCEN();
                cen.Destroy(id);

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return View();
            }
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
    }
}