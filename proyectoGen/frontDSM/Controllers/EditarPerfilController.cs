using frontDSM.Assembler;
using frontDSM.Models;
using ProyectoGenNHibernate.CAD.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;
using ProyectoGenNHibernate.EN.Proyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace frontDSM.Controllers
{
    public class EditarPerfilController : BasicController
    {
        // GET: EditarPerfil
        public ActionResult Index()
        {
            SessionInitialize();

            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);

            IList<UsuarioEN> listaUsuarios = usuCEN.ReadAll(0, -1);
            IEnumerable<EditarPerfilViewModel> listViewModel = new EditarPerfilAssembler().ConvertListENToModel(listaUsuarios).ToList();

            SessionClose();

            return View(listViewModel);
        }

        // GET: EditarPerfil/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EditarPerfil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditarPerfil/Create
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

        // GET: EditarPerfil/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EditarPerfil/Edit/5
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

        // GET: EditarPerfil/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EditarPerfil/Delete/5
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
