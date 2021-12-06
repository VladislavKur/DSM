using ProyectoDSM.Models;
using ProyectoGenNHibernate.EN.Proyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProyectoDSM.Assembler
{
    public class MatchAssembler
    {
        public MatchViewModel ConvertENToModelUI(MatchEN en)
        {
            MatchViewModel usu = new MatchViewModel();
            usu.Id = en.Id;
            usu.Estado = en.Estado;


            return usu;
        }

        public IList<MatchViewModel> ConvertListENToModel(IList<MatchEN> ens)
        {

            IList<MatchViewModel> usus = new List<MatchViewModel>();
            foreach (MatchEN en in ens)
            {
                usus.Add(ConvertENToModelUI(en));
            }
            return usus;
        }
    }
}