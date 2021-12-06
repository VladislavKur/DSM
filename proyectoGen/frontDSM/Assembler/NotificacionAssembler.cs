using frontDSM.Models;
using ProyectoGenNHibernate.EN.Proyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace frontDSM.Assembler
{
    public class NotificacionAssembler
    {
        public NotificacionViewModel ConvertENToModelUI(NotificacionEN en)
        {
            NotificacionViewModel usu = new NotificacionViewModel();
            usu.Id = en.Id;
            usu.Tipo = en.Tipo;
            usu.Contenido = en.Contenido;
            usu.Id_tipo = en.Id_tipo;


            return usu;
        }

        public IList<NotificacionViewModel> ConvertListENToModel(IList<NotificacionEN> ens)
        {

            IList<NotificacionViewModel> usus = new List<NotificacionViewModel>();
            foreach (NotificacionEN en in ens)
            {
                usus.Add(ConvertENToModelUI(en));
            }
            return usus;
        }
    }
}