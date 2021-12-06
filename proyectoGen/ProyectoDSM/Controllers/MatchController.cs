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
using ProyectoGenNHibernate.CP.Proyecto;

namespace ProyectoDSM.Controllers
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
            MatchViewModel usu = null;
            SessionInitialize();

            MatchEN usuarioEN = new MatchCAD(session).ReadOIDDefault(id);
            usu = new MatchAssembler().ConvertENToModelUI(usuarioEN);

            SessionClose();
            return View(usu);
        }

        public ActionResult ListaMensajesPartial(int id)
        {
            if (id == 1)
            {
                return View((IEnumerable<MensajeViewModel>)Session["listaUsuariosMatch"]);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        //GET: Match
        //Lista de notificaciones de match recibidos
        public ActionResult MatchsRecibidos()
        {
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];

            IList<UsuarioEN> listaMatchs = usuarioCEN.DameUsuariosMatchPendiente(usuario.Id);
            foreach (UsuarioEN matchs in listaMatchs)   //incrementamos los likes al numero de matchs que tengas pendientes
            {
                if(usuario.Like_counter < listaMatchs.Count)
                {
                    usuarioCEN.IncrementaLikes(usuario.Id);
                }
                
            }
            IEnumerable<UsuarioViewModel> listViewModel = new UsuarioAssembler().ConvertListENToModel(listaMatchs).ToList();
            SessionClose();

            return View(listViewModel);
        }
        public ActionResult AceptarMatch(int id)
        {
            MatchViewModel matchViewModel = new MatchViewModel();
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            MatchCAD matchCAD = new MatchCAD(session);
            MatchCEN matchCEN = new MatchCEN(matchCAD);
           

            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            //IList<UsuarioEN> listaMatchsEmitidos = usuarioCEN.DameUsuariosMatchEmisor(id);
            IList<MatchEN> listaTodosMatch = matchCEN.ReadAll(0, -1);

            UsuarioEN usuarioEmisorEN = usuarioCEN.ReadOID(id);             //el que has cogido
            UsuarioEN usuarioReceptorEN = usuarioCEN.ReadOID(usuario.Id);   //el que esta logueado
            bool cambioEstado = false;
            int idMatch = -1;

            MatchEN matchEN = null;

            foreach (MatchEN match in listaTodosMatch) if(!cambioEstado)
            {
                if (match.Usuario_emisor == usuarioEmisorEN && match.Usuario_receptor == usuarioReceptorEN)
                {
                    matchEN = matchCAD.ReadOIDDefault (match.Id);
                    idMatch = match.Id;
                    cambioEstado = true;

                }
            }

            if (cambioEstado && idMatch!=-1 && matchEN != null){
                matchCEN.Modify(idMatch, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMatchEnum.aceptado);
                matchViewModel = new MatchAssembler().ConvertENToModelUI(matchEN);
                //matchEN = matchCEN.ReadOID(idMatch);
            }

            SessionClose();
            //return View(matchViewModel);
            return RedirectToAction("ChatBase","Mensaje");
        }
        /*
        public ActionResult AceptarMatch(int id, MatchViewModel matchViewModel)
        {
            
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            MatchCAD matchCAD = new MatchCAD(session);
            MatchCEN matchCEN = new MatchCEN(matchCAD);


            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            MatchEN matchEN = matchCAD.ReadOIDDefault(matchViewModel.Id);

            matchCEN.GestionarMatch(matchViewModel.Id, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMatchEnum.aceptado);
           

            SessionClose();
            return RedirectToAction("ChatBase", "Mensaje");
        }
        */
        public ActionResult RechazarMatch(int id)
        {
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            MatchCAD matchCAD = new MatchCAD(session);
            MatchCEN matchCEN = new MatchCEN(matchCAD);


            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            //IList<UsuarioEN> listaMatchsEmitidos = usuarioCEN.DameUsuariosMatchEmisor(id);
            IList<MatchEN> listaTodosMatch = matchCEN.ReadAll(0, -1);

            UsuarioEN usuarioEmisorEN = usuarioCEN.ReadOID(id);             //el que has cogido
            UsuarioEN usuarioReceptorEN = usuarioCEN.ReadOID(usuario.Id);   //es decir el que esta logueado
            bool cambioEstado = false;
            int idMatch = -1;

            MatchEN matchEN = null;

            foreach (MatchEN match in listaTodosMatch) if (!cambioEstado)
                {
                    if (match.Usuario_emisor == usuarioEmisorEN && match.Usuario_receptor == usuarioReceptorEN)
                    {
                        matchEN = matchCAD.ReadOIDDefault(match.Id);
                        idMatch = match.Id;
                        cambioEstado = true;

                    }
                }

            if (cambioEstado && idMatch != -1)
            {
                matchCEN.GestionarMatch(idMatch, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMatchEnum.rechazado);
                matchEN = matchCEN.ReadOID(idMatch);
            }

            SessionClose();
            return RedirectToAction("Index");
        }


        //GET: Match/VerMatchs
        /*
        public ActionResult VerMatchs(int id)
        {
            try
            {
                // TODO: Add insert logic here
                SessionInitialize();
                UsuarioCAD cadArt = new UsuarioCAD(session);
                UsuarioCEN cen = new UsuarioCEN(cadArt);


                //IList<MensajeEN> listArtEn = cen.DameMensajes();

                IList<UsuarioEN> listUsuMatchEm = cen.DameUsuariosMatchEmisor(id);
                IList<UsuarioEN> listUsuMatchRe = cen.DameUsuariosMatchReceptor(id);
                IEnumerable<UsuarioViewModel> listUsuEm = new UsuarioAssembler().ConvertListENToModel(listUsuMatchEm).ToList();
                IEnumerable<UsuarioViewModel> listUsuRe = new UsuarioAssembler().ConvertListENToModel(listUsuMatchRe).ToList();
                //Como convierto las dos listas en una
                //IEnumerable<UsuarioViewModel> listUsuMatch = ;
                IEnumerable<UsuarioViewModel> listUsus = listUsuEm.Concat(listUsuRe).ToList();

                Session["listaUsuariosMatch"] = listUsus;

                SessionClose();

                return RedirectToAction("ChatBase");
            }
            catch
            {
                return View();
            }
        }*/


        
        // GET: Match/Create
        public ActionResult Create(int id)
        {
            /*UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            MatchCP matchCP = new MatchCP();
            try
            {
                matchCP.New2(usuario.Id, id);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }*/
            /*MatchViewModel art = new MatchViewModel();
            //como paso el id de este al otro?
            Session["MatchId"] = id;*/
            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            MatchCP matchCP = new MatchCP();
           
            try
            {
                matchCP.New2(usuario.Id, id);
                return RedirectToAction("Notificacion","Notificacion");
            }
            catch
            {
                return View();
            }
            //return View(art);

        }

        // POST: Match/Create
        
        [HttpPost]
        public ActionResult Create(MatchViewModel match)
        {
            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            MatchCP matchCP = new MatchCP();
            int id = (int)Session["MatchId"];
            try
            {
                //matchCP.New2(usuario.Id, id);
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
            MatchViewModel usu = null;

            SessionInitialize();


            MatchEN usuarioEN = new MatchCAD(session).ReadOIDDefault(id);

            usu = new MatchAssembler().ConvertENToModelUI(usuarioEN);
            SessionClose();

            return View(usu);
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
