﻿using frontDSM.Controllers;
using ProyectoGenNHibernate.CAD.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.Enumerated.Proyecto;

using frontDSM.Models;
using frontDSM.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace frontDSM.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: Usuario
        public ActionResult Index()
        {
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);

            IList<UsuarioEN> listaUsuarios = usuarioCEN.ReadAll(0, -1);
            IEnumerable<UsuarioViewModel> listViewModel = new UsuarioAssembler().ConvertListENToModel(listaUsuarios).ToList();
            SessionClose();

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
                             

               // IList<UsuarioEN> listArtEn = cen.FiltroBusqueda(busquedaViewModel.Orientacion_sexual, busquedaViewModel.Genero, busquedaViewModel.Edad_min, busquedaViewModel.Edad_max);
                //IEnumerable<UsuarioViewModel> listArt = new UsuarioAssembler().ConvertListENToModel(listArtEn).ToList();
               // Session["listaUsuarios"] = listArt;
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
        public ActionResult Create(UsuarioViewModel usu)
        {
            try
            {
                // TODO: Add insert logic here
                UsuarioCEN usuCEN = new UsuarioCEN();

                //int id = usuCEN.New_(usu.Pass, usu.Email, usu.Nickname, usu.Nombre, usu.Apellidos, usu.Fecha_nacimiento,
               //             usu.Orientacion_sexual, usu.Genero, usu.Fecha_registro, usu.Like_counter, usu.foto);
              //  usuCEN.CalcularEdad(id);

                return RedirectToAction("index");
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
            UsuarioViewModel usu = null;

            SessionInitialize();


            UsuarioEN usuarioEN = new UsuarioCAD(session).ReadOIDDefault(id);

            usu = new UsuarioAssembler().ConvertENToModelUI(usuarioEN);
            SessionClose();

            return View(usu);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UsuarioViewModel usu)
        {
            try
            {
                // TODO: Add update logic here
                UsuarioCEN usuarioCEN = new UsuarioCEN();

              //  usuarioCEN.Modify(usu.Id, usu.Pass, usu.Email, usu.Nickname, usu.Nombre, usu.Apellidos, usu.Fecha_nacimiento,
               //                     usu.Orientacion_sexual, usu.Genero, usu.Fecha_registro, usu.Like_counter, usu.EsPremium);


                return RedirectToAction("Index");
            }
            catch
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
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                usuarioCEN.Destroy(id);

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
