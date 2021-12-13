using ProyectoDSM.Controllers;
using ProyectoGenNHibernate.CAD.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.Enumerated.Proyecto;

using ProyectoDSM.Models;
using ProyectoDSM.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace ProyectoDSM.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: Usuario
        /*public ActionResult Index()
        {
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);

            IList<UsuarioEN> listaUsuarios = usuarioCEN.ReadAll(0, -1);
            IEnumerable<UsuarioViewModel> listViewModel = new UsuarioAssembler().ConvertListENToModel(listaUsuarios).ToList();
            SessionClose();

            return View(listViewModel);
        }
        */
        [Authorize]
        public ActionResult Index(int pagina = -1)
        {
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
            
            if (pagina == -1)
                pagina = 0;


            IList<UsuarioEN> listaUsuarios = null;
            IList<UsuarioEN> listaUsuarios2 = null;
            IList<UsuarioEN> listaUsuariosPrem = null;
            IList<UsuarioEN> listaUsuarios2Prem = null;

            IList<UsuarioEN> listaUsuarios3 = null;
            IList<UsuarioEN> listaUsuarios4 = null;
            IList<UsuarioEN> listaUsuarios3Prem = null;
            IList<UsuarioEN> listaUsuarios4Prem = null;
            if (usuario.Orientacion_sexual == OrientacionSexualEnum.heterosexual)
            {
                if(usuario.Genero == GeneroUsuarioEnum.hombre)
                {
                    listaUsuarios = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.heterosexual,GeneroUsuarioEnum.mujer, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios2 = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuariosPrem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.heterosexual, GeneroUsuarioEnum.mujer, false, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios2Prem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, false, ((pagina) * 10), ((pagina) * 10) + 10);
                }
                if(usuario.Genero == GeneroUsuarioEnum.mujer)
                {
                    listaUsuarios = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.heterosexual, GeneroUsuarioEnum.hombre, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios2 = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.hombre, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuariosPrem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.heterosexual, GeneroUsuarioEnum.hombre, false, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios2Prem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.hombre, false, ((pagina) * 10), ((pagina) * 10) + 10);
                }
            }else if (usuario.Orientacion_sexual == OrientacionSexualEnum.homosexual)
            {
                if (usuario.Genero == GeneroUsuarioEnum.mujer)
                {
                    listaUsuarios = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.homosexual, GeneroUsuarioEnum.mujer, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios2 = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuariosPrem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.homosexual, GeneroUsuarioEnum.mujer, false, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios2Prem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, false, ((pagina) * 10), ((pagina) * 10) + 10);
                }
                if (usuario.Genero == GeneroUsuarioEnum.hombre)
                {
                    listaUsuarios = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.homosexual, GeneroUsuarioEnum.hombre, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios2 = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.hombre, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuariosPrem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.homosexual, GeneroUsuarioEnum.hombre, false, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios2Prem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.hombre, false, ((pagina) * 10), ((pagina) * 10) + 10);
                }
            }else if (usuario.Orientacion_sexual == OrientacionSexualEnum.bisexual)
            {
                if (usuario.Genero == GeneroUsuarioEnum.mujer)
                {
                    listaUsuarios = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.homosexual, GeneroUsuarioEnum.mujer, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios2 = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuariosPrem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.homosexual, GeneroUsuarioEnum.mujer, false, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios2Prem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, false, ((pagina) * 10), ((pagina) * 10) + 10);

                    listaUsuarios3 = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.heterosexual, GeneroUsuarioEnum.hombre, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios4 = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.hombre, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios3Prem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.homosexual, GeneroUsuarioEnum.hombre, false, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios4Prem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.hombre, false, ((pagina) * 10), ((pagina) * 10) + 10);
                }
                if (usuario.Genero == GeneroUsuarioEnum.hombre)
                {
                    listaUsuarios = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.homosexual, GeneroUsuarioEnum.hombre, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios2 = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.hombre, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuariosPrem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.homosexual, GeneroUsuarioEnum.hombre, false, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios2Prem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.hombre, false, ((pagina) * 10), ((pagina) * 10) + 10);

                    listaUsuarios3 = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.heterosexual, GeneroUsuarioEnum.mujer, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios4 = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, true, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios3Prem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.homosexual, GeneroUsuarioEnum.mujer, false, ((pagina) * 10), ((pagina) * 10) + 10);
                    listaUsuarios4Prem = usuarioCEN.FiltroDefecto(OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, false, ((pagina) * 10), ((pagina) * 10) + 10);
                }
            }
            IList<UsuarioEN> listUsus = null;

            if (usuario.Orientacion_sexual != OrientacionSexualEnum.bisexual)
            {
                listUsus = listaUsuarios.Concat(listaUsuarios2).Concat(listaUsuariosPrem).Concat(listaUsuarios2Prem).ToList();
            }
            else
            {
                listUsus = listaUsuarios.Concat(listaUsuarios2).Concat(listaUsuarios3).Concat(listaUsuarios4).Concat(listaUsuariosPrem).Concat(listaUsuarios2Prem).Concat(listaUsuarios3Prem).Concat(listaUsuarios4Prem).ToList();
                
            }

            //Quitamos con los que hayamos hecho match
            //si el emisor soy yo o el otro
            IList<UsuarioEN> listUsuMatchEm = usuarioCEN.DameUsuariosMatchEmisor(usuario.Id);
            IList<UsuarioEN> listUsuMatchRe = usuarioCEN.DameUsuariosMatchReceptor(usuario.Id);
            IList<UsuarioEN> listUsuMatchReP = usuarioCEN.DameUsuariomatchPendienteEmisor(usuario.Id);
            IList<UsuarioEN> listUsuMatchReP2 = usuarioCEN.DameUsuariosMatchRechazadoReceptor(usuario.Id);
            IList<UsuarioEN> listUsusMatch = listUsuMatchEm.Concat(listUsuMatchRe).Concat(listUsuMatchReP).Concat(listUsuMatchReP2).ToList();
            //los usuarios que no sean match
            IList<UsuarioEN> listDif = listUsus.Except(listUsusMatch).ToList();

            

            IEnumerable<UsuarioViewModel> listViewModel = new UsuarioAssembler().ConvertListENToModel(listDif).ToList();
            SessionClose();
            if (listDif.Count >= 10)    //para que no deje pasar de pagina si hay menos de 10 resultados
            {
                ViewData["pagina"] = pagina;

            }
            return View(listViewModel);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            UsuarioViewModel usu = null;
            SessionInitialize();

            UsuarioEN usuarioEN = new UsuarioCAD(session).ReadOIDDefault(id);
            usu = new UsuarioAssembler().ConvertENToModelUI(usuarioEN);

            SessionClose();
            return View(usu);
        }
        public ActionResult MiPerfil()
        {
            UsuarioViewModel usu = null;
            SessionInitialize();
            UsuarioEN usuario = (UsuarioEN)Session["Usuario"];

            UsuarioEN usuarioEN = new UsuarioCAD(session).ReadOIDDefault(usuario.Id);
            usu = new UsuarioAssembler().ConvertENToModelUI(usuarioEN);

            SessionClose();
            return View(usu);
        }
        // GET: /ArticuloViewModels/Categoria/5

        public ActionResult PorPremium()
        {
            SessionInitialize();
            UsuarioCAD cadArt = new UsuarioCAD(session);
            UsuarioCEN cen = new UsuarioCEN(cadArt);
            IList<UsuarioEN> listArtEn = cen.DameUsuariosPremium();
            IEnumerable<UsuarioViewModel> listArt = new UsuarioAssembler().ConvertListENToModel(listArtEn).ToList();

            SessionClose();
            return View(listArt);
        }


        public ActionResult PorOrientacion()
        {
            SessionInitialize();
            UsuarioCAD cadArt = new UsuarioCAD(session);
            UsuarioCEN cen = new UsuarioCEN(cadArt);
            IList<UsuarioEN> listArtEn = cen.DameUsuariosPremium();
            IEnumerable<UsuarioViewModel> listArt = new UsuarioAssembler().ConvertListENToModel(listArtEn).ToList();

            SessionClose();
            return View(listArt);
        }

        //GET Usuario/Busqueda
        /*public ActionResult Busqueda()
        {
            SessionInitialize();
            UsuarioCAD cadArt = new UsuarioCAD(session);
            UsuarioCEN cen = new UsuarioCEN(cadArt);

            int? edadmin = null;
            int? edadmax = null;

           
            if (busquedaViewModel.Edad_min < 18)
            {
                edadmin = 18;
            }
            if (busquedaViewModel.Edad_max > 60)
            {
                edadmax = 60;
            }
            
            IList<UsuarioEN> listArtEn = cen.FiltroBusqueda(busquedaViewModel.Orientacion_sexual, busquedaViewModel.Genero, edadmin, edadmax);
            IEnumerable<UsuarioViewModel> listArt = new UsuarioAssembler().ConvertListENToModel(listArtEn).ToList();

            SessionClose();
            return View(listArt);
        }*/

        public ActionResult ListaUsuariosPartial(int id) {
            if (id == 1)
            {
                return View((IEnumerable<UsuarioViewModel>)Session["listaUsuarios"]);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Buscar()
        {
            BusquedaViewModel buscarvm = new BusquedaViewModel();
            return View(buscarvm);
        }
        //POST: Usuario/Busqueda
        [HttpPost]
        public ActionResult Busqueda(BusquedaViewModel busquedaViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                SessionInitialize();
                UsuarioCAD cadArt = new UsuarioCAD(session);
                UsuarioCEN cen = new UsuarioCEN(cadArt);
                             

                IList<UsuarioEN> listArtEnPrem = cen.FiltroBusqueda(busquedaViewModel.Orientacion_sexual, busquedaViewModel.Genero, busquedaViewModel.Edad_min, busquedaViewModel.Edad_max,true);
                IList<UsuarioEN> listArtEnNoPrem = cen.FiltroBusqueda(busquedaViewModel.Orientacion_sexual, busquedaViewModel.Genero, busquedaViewModel.Edad_min, busquedaViewModel.Edad_max, false);
                //uno las dos listas para que salgan primero los premium
                IList<UsuarioEN> listUsus = listArtEnPrem.Concat(listArtEnNoPrem).ToList();
                //Ahora comparamos con los que ya tengamos match y si ya lo hemos hecho lo quitamos
                UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
                //si el emisor soy yo o el otro
                IList<UsuarioEN> listUsuMatchEm = cen.DameUsuariosMatchEmisor(usuario.Id);
                IList<UsuarioEN> listUsuMatchRe = cen.DameUsuariosMatchReceptor(usuario.Id);
                IList<UsuarioEN> listUsuMatchReP = cen.DameUsuariomatchPendienteEmisor(usuario.Id);
                IList<UsuarioEN> listUsuMatchReP2 = cen.DameUsuariosMatchRechazadoReceptor(usuario.Id);
                IList<UsuarioEN> listUsusMatch = listUsuMatchEm.Concat(listUsuMatchRe).Concat(listUsuMatchReP).Concat(listUsuMatchReP2).ToList();
                //los usuarios que no sean match
                IList<UsuarioEN> listDif = listUsus.Except(listUsusMatch).ToList();

                IEnumerable<UsuarioViewModel> listArt = new UsuarioAssembler().ConvertListENToModel(listDif).ToList();
                Session["listaUsuarios"] = listArt;
                SessionClose();

                return RedirectToAction("Buscar");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioViewModel usu/*, HttpPostedFileBase file*/)
        {
            /*string fileName = "", path = "";
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                path = Path.Combine(Server.MapPath("~/Images/Uploads"), fileName);
                //string pathDef = path.Replace(@"\\", @"\");
                file.SaveAs(path);
            }*/

            
            try
            {
                //fileName = "/Images/Uploads/" + fileName;
                // TODO: Add insert logic here
                UsuarioCEN usuCEN = new UsuarioCEN();

                //int id = usuCEN.New_(usu.Password, usu.Email, usu.Nickname, usu.Nombre, usu.Apellidos, usu.Fecha_nacimiento,
                //            usu.Orientacion_sexual, usu.Genero, usu.Fecha_registro, usu.Like_counter, fileName);
                int id = usuCEN.New_(usu.Password, usu.Email, usu.Nickname, usu.Nombre, usu.Apellidos, usu.Fecha_nacimiento,
                            usu.Orientacion_sexual, usu.Genero, usu.Fecha_registro, usu.Like_counter,usu.Imagen);
                usuCEN.CalcularEdad(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            //no se si es este en las diapositivas solo pone Articulo

            SessionInitialize();

            UsuarioEN usuarioEN = new UsuarioCAD(session).ReadOIDDefault(id);

            UsuarioViewModel usu = new UsuarioAssembler().ConvertENToModelUI(usuarioEN);
            SessionClose();

            return View(usu);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usu)
        {
            try
            {
                // TODO: Add update logic here
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                UsuarioEN usuario = (UsuarioEN)Session["Usuario"];
                //usuarioCEN.Modify(id, usu.Password, usu.Email, usu.Nickname, usu.Nombre, usu.Apellidos, usu.Fecha_nacimiento,
                //                    usu.Orientacion_sexual, usu.Genero, usu.Fecha_registro, usu.Like_counter, usu.EsPremium, usu.Foto);
                //usuarioCEN.EditarPerfil(usu.Id, usu.Password, usu.Email, usu.Nickname, usu.Nombre, usu.Apellidos, usu.Fecha_nacimiento,
                //                    usu.Orientacion_sexual, usu.Genero, usu.Fecha_registro, usu.Like_counter, usu.EsPremium);
                usuarioCEN.EditarPerfil(usu.Id, usu.Nickname, usu.Nombre, usu.Apellidos,usuario.Fecha_nacimiento, usu.Orientacion_sexual, usu.Genero);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            
            try
            {
                // TODO: Add delete logic here
                

                SessionInitialize();
                
                UsuarioCAD usuarioCAD = new UsuarioCAD();
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
                UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);
                UsuarioViewModel usu = new UsuarioAssembler().ConvertENToModelUI(usuarioEN);

                SessionClose();

                new UsuarioCEN().Destroy(id);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Usuario/Delete/5
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
