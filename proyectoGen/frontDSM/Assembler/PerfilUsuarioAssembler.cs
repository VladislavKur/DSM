using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using frontDSM.Models;
using ProyectoGenNHibernate.EN.Proyecto;

namespace frontDSM.Assembler
{
    public class PerfilUsuarioAssembler
    {

        public PerfilUsuarioViewModel ConvertENToModelUI(UsuarioEN en)
        {
            PerfilUsuarioViewModel usu = new PerfilUsuarioViewModel();
            usu.Id = en.Id;
            usu.Nombre = en.Nombre;
            usu.Nickname = en.Nickname;

            return usu;
        }

        public IList<PerfilUsuarioViewModel> ConvertListENToModel(IList<UsuarioEN> ens)
        {

            IList<PerfilUsuarioViewModel> usus = new List<PerfilUsuarioViewModel>();
            foreach (UsuarioEN en in ens)
            {
                usus.Add(ConvertENToModelUI(en));
                /*if (Session["Usuario"].) {
                    
                }*/
            }
            return usus;
        }

    }
}