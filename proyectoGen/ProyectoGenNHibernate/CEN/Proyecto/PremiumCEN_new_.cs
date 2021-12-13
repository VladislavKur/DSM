
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProyectoGenNHibernate.Exceptions;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.CAD.Proyecto;


/*PROTECTED REGION ID(usingProyectoGenNHibernate.CEN.Proyecto_Premium_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CEN.Proyecto
{
public partial class PremiumCEN
{
public int New_ (double p_precio, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoCompraEnum p_estadoCompra)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CEN.Proyecto_Premium_new__customized) ENABLED START*/

        PremiumEN premiumEN = null;

        int oid;

        //Initialized PremiumEN
        premiumEN = new PremiumEN ();
        premiumEN.Precio = p_precio;

        premiumEN.EstadoCompra = p_estadoCompra;

        DateTime dateTime = DateTime.Now;
        premiumEN.Fecha_compra = dateTime;

        dateTime = dateTime.AddDays (30);
        premiumEN.Fecha_caduca = dateTime;
        //Call to PremiumCAD

        oid = _IPremiumCAD.New_ (premiumEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
