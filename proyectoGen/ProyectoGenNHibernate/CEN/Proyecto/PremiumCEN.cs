

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProyectoGenNHibernate.Exceptions;

using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.CAD.Proyecto;


namespace ProyectoGenNHibernate.CEN.Proyecto
{
/*
 *      Definition of the class PremiumCEN
 *
 */
public partial class PremiumCEN
{
private IPremiumCAD _IPremiumCAD;

public PremiumCEN()
{
        this._IPremiumCAD = new PremiumCAD ();
}

public PremiumCEN(IPremiumCAD _IPremiumCAD)
{
        this._IPremiumCAD = _IPremiumCAD;
}

public IPremiumCAD get_IPremiumCAD ()
{
        return this._IPremiumCAD;
}

public void Modify (int p_Premium_OID, double p_precio, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoCompraEnum p_estadoCompra, Nullable<DateTime> p_fecha_compra)
{
        PremiumEN premiumEN = null;

        //Initialized PremiumEN
        premiumEN = new PremiumEN ();
        premiumEN.Id = p_Premium_OID;
        premiumEN.Precio = p_precio;
        premiumEN.EstadoCompra = p_estadoCompra;
        premiumEN.Fecha_compra = p_fecha_compra;
        //Call to PremiumCAD

        _IPremiumCAD.Modify (premiumEN);
}

public void Destroy (int id
                     )
{
        _IPremiumCAD.Destroy (id);
}

public PremiumEN ReadOID (int id
                          )
{
        PremiumEN premiumEN = null;

        premiumEN = _IPremiumCAD.ReadOID (id);
        return premiumEN;
}

public System.Collections.Generic.IList<PremiumEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PremiumEN> list = null;

        list = _IPremiumCAD.ReadAll (first, size);
        return list;
}
}
}
