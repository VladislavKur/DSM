using frontDSM.Models;
using ProyectoGenNHibernate.EN.Proyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace frontDSM.Assembler
{
    public class SesionAssembler
    {
        public SesionViewModel ConvertENToModelUI(SesionEN en)
        {
            SesionViewModel usu = new SesionViewModel();
            usu.Id = en.Id;
            usu.Hora_inicio = (DateTime)en.Hora_inicio;
            usu.Hora_fin = (DateTime)en.Hora_fin;


            return usu;
        }

        public IList<SesionViewModel> ConvertListENToModel(IList<SesionEN> ens)
        {

            IList<SesionViewModel> usus = new List<SesionViewModel>();
            foreach (SesionEN en in ens)
            {
                usus.Add(ConvertENToModelUI(en));
            }
            return usus;
        }

    }
}