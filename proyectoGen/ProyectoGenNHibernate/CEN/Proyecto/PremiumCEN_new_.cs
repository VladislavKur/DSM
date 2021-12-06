
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
public int New_ (double p_precio, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoCompraEnum p_estadoCompra, Nullable<DateTime> p_fecha_compra)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CEN.Proyecto_Premium_new__customized) START*/

        PremiumEN premiumEN = null;

        int oid;

        //Initialized PremiumEN
        premiumEN = new PremiumEN ();
        premiumEN.Precio = p_precio;

        premiumEN.EstadoCompra = p_estadoCompra;

        premiumEN.Fecha_compra = p_fecha_compra;

        //Call to PremiumCAD

        oid = _IPremiumCAD.New_ (premiumEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
