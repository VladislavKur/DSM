using ProyectoDSM.Models;
using ProyectoGenNHibernate.EN.Proyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoDSM.Assembler
{
    public class PremiumAssembler
    {
        public PremiumViewModel ConvertENToModelUI(PremiumEN en)
        {
            PremiumViewModel prem = new PremiumViewModel();
            prem.Precio = en.Precio;
            prem.EstadoCompra = en.EstadoCompra;
            prem.Fecha_compra = (DateTime)en.Fecha_compra;
            prem.Fecha_caduca = (DateTime)en.Fecha_caduca;

            return prem;
        }

        public IList<PremiumViewModel> ConvertListENToModel(IList<PremiumEN> ens)
        {

            IList<PremiumViewModel> prems = new List<PremiumViewModel>();
            foreach (PremiumEN en in ens)
            {
                prems.Add(ConvertENToModelUI(en));
            }
            return prems;
        }

    }
}