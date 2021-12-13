using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProyectoGenNHibernate.CAD.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.CP.Proyecto;
using ProyectoDSM.Models;
using ProyectoDSM.Assembler;

namespace ProyectoDSM.Controllers
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
        public ActionResult VerMensajes(int id)
        {
            SessionInitialize();
            MensajeCAD MensajeCAD = new MensajeCAD(session);
            MensajeCEN MensajeCEN = new MensajeCEN(MensajeCAD);
            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            IList<MensajeEN> listaMensajes = MensajeCEN.DameMensajesEntreEstos2(usuario.Id,id);
            IEnumerable<MensajeViewModel> listViewModel = new MensajeAssembler().ConvertListENToModel(listaMensajes).ToList();
            Session["idRepector"] = id;
            Session["listaMensajes"] = listViewModel;
            SessionClose();
            // return View(listViewModel);
            return RedirectToAction("ChatBase");

        }
        public ActionResult ListaMensajesPartial(int id)
        {
            if (id == 1)
            {
                return PartialView((IEnumerable<MensajeViewModel>)Session["listaMensajes"]);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        // GET: Mensaje/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mensaje/Create
        public ActionResult Create(int id)
        {
            /*UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            MensajeCP mensajeCP = new MensajeCP();*/

            MensajeViewModel art = new MensajeViewModel();
            art.Id = id;
            return View(art);
            /*try
            {
                mensajeCP.New_(mensaje.Contenido, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMensajeEnum.enviado, id, usuario.Id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }*/
            
        }

        // POST: Mensaje/Create
        [HttpPost]
        public ActionResult Create(MensajeViewModel mensaje)
        {
            
            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            MensajeCP mensajeCP = new MensajeCP();
            try
            {
                //mensajeCP.New_(mensaje.Contenido, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMensajeEnum.enviado, , usuario.Id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult CreatePartial(int id)
        {
            /*UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            MensajeCP mensajeCP = new MensajeCP();*/

            MensajeViewModel art = new MensajeViewModel();
            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            art.IdEmisor = usuario.Id;
            art.IdReceptor = id;
            return PartialView(art);
            

        }
        [HttpPost]
        public ActionResult CreatePartial(MensajeViewModel mensaje)
        {

            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            MensajeCP mensajeCP = new MensajeCP();
            try
            {
                mensajeCP.New_(mensaje.Contenido, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMensajeEnum.enviado, usuario.Id, (int)Session["idRepector"]);
                return CreatePartial((int)Session["idRepector"]);
                
            }
            catch (Exception e)
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

        public ActionResult ChatBase()
        {
            SessionInitialize();
            UsuarioCAD cadArt = new UsuarioCAD(session);
            UsuarioCEN cen = new UsuarioCEN(cadArt);
            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            UsuarioCEN usuarioCEN = new UsuarioCEN();

            //IList<UsuarioEN> listaMatchs = usuarioCEN.DameUsuariosMatchPendiente(usuario.Id);
            IList<UsuarioEN> listUsuMatchEm = cen.DameUsuariosMatchEmisor(usuario.Id);
            IList<UsuarioEN> listUsuMatchRe = cen.DameUsuariosMatchReceptor(usuario.Id);
            IEnumerable<UsuarioViewModel> listUsuEm = new UsuarioAssembler().ConvertListENToModel(listUsuMatchEm).ToList();
            IEnumerable<UsuarioViewModel> listUsuRe = new UsuarioAssembler().ConvertListENToModel(listUsuMatchRe).ToList();
            //Como convierto las dos listas en una
            //IEnumerable<UsuarioViewModel> listUsuMatch = ;
            IEnumerable<UsuarioViewModel> listUsus = listUsuEm.Concat(listUsuRe).ToList();

            Session["listaUsuariosMatch"] = listUsus;
            //IEnumerable<UsuarioViewModel> listaMatchsVM = new UsuarioAssembler().ConvertListENToModel(listaMatchs).ToList();
            SessionClose();

            return View(listUsus);
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
