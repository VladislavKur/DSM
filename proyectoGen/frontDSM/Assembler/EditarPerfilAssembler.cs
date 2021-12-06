using frontDSM.Models;
using ProyectoGenNHibernate.EN.Proyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace frontDSM.Assembler
{
    public class EditarPerfilAssembler
    {

        public EditarPerfilViewModel ConvertENToModelUI(UsuarioEN en)
        {
            EditarPerfilViewModel usu = new EditarPerfilViewModel();
            usu.Id = en.Id;
            usu.Nombre = en.Nombre;
            usu.Nickname = en.Nickname;
            usu.Edad = en.Edad;
            usu.Genero = en.Genero;//si se pilla el valor, se tiene que camibar en el controller a enumerated
            usu.Interes = en.Orientacion_sexual;//si se pilla el valor, se tiene que camibar en el controller a enumerated

            return usu;
        }

        public IList<EditarPerfilViewModel> ConvertListENToModel(IList<UsuarioEN> ens)
        {

            IList<EditarPerfilViewModel> usus = new List<EditarPerfilViewModel>();
            foreach (UsuarioEN en in ens)
            {
                usus.Add(ConvertENToModelUI(en));
            }
            return usus;
        }

    }
}