using frontDSM.Controllers;
using ProyectoGenNHibernate.CEN.Proyecto;
using ProyectoGenNHibernate.EN.Proyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace frontDSM.Controllers
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