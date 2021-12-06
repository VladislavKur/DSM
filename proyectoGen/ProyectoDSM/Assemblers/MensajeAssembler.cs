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