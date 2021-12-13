using ProyectoDSM.Models;
using ProyectoGenNHibernate.EN.Proyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoDSM.Assembler
{
    public class MensajeAssembler
    {
        public MensajeViewModel ConvertENToModelUI(MensajeEN en)
        {

            MensajeViewModel usu = new MensajeViewModel();
            usu.Id = en.Id;
            usu.Contenido = en.Contenido;
            usu.Estado = en.Estado;
            usu.IdReceptor = en.Usuario_receptor.Id;
            usu.IdEmisor = en.Usuario_emisor.Id;
            usu.NombreReceptor = en.Usuario_receptor.Nickname;
            usu.NombreEmisor = en.Usuario_emisor.Nickname;

            return usu;
        }

        public IList<MensajeViewModel> ConvertListENToModel(IList<MensajeEN> ens)
        {

            IList<MensajeViewModel> usus = new List<MensajeViewModel>();
            foreach (MensajeEN en in ens)
            {
                usus.Add(ConvertENToModelUI(en));
            }
            return usus;
        }

    }
}