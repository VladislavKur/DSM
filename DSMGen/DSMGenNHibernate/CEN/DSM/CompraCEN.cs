

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGenNHibernate.Exceptions;

using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.CAD.DSM;


namespace DSMGenNHibernate.CEN.DSM
{
/*
 *      Definition of the class CompraCEN
 *
 */
public partial class CompraCEN
{
private ICompraCAD _ICompraCAD;

public CompraCEN()
{
        this._ICompraCAD = new CompraCAD ();
}

public CompraCEN(ICompraCAD _ICompraCAD)
{
        this._ICompraCAD = _ICompraCAD;
}

public ICompraCAD get_ICompraCAD ()
{
        return this._ICompraCAD;
}

public CompraEN ReadOID (int id
                         )
{
        CompraEN compraEN = null;

        compraEN = _ICompraCAD.ReadOID (id);
        return compraEN;
}

public System.Collections.Generic.IList<CompraEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CompraEN> list = null;

        list = _ICompraCAD.ReadAll (first, size);
        return list;
}
public int New_ (int p_precio, DSMGenNHibernate.Enumerated.DSM.EstadoCompraEnum p_estadoCompra)
{
        CompraEN compraEN = null;
        int oid;

        //Initialized CompraEN
        compraEN = new CompraEN ();
        compraEN.Precio = p_precio;

        compraEN.EstadoCompra = p_estadoCompra;

        //Call to CompraCAD

        oid = _ICompraCAD.New_ (compraEN);
        return oid;
}

public void Modify (int p_Compra_OID, int p_precio, DSMGenNHibernate.Enumerated.DSM.EstadoCompraEnum p_estadoCompra)
{
        CompraEN compraEN = null;

        //Initialized CompraEN
        compraEN = new CompraEN ();
        compraEN.Id = p_Compra_OID;
        compraEN.Precio = p_precio;
        compraEN.EstadoCompra = p_estadoCompra;
        //Call to CompraCAD

        _ICompraCAD.Modify (compraEN);
}

public void Destroy (int id
                     )
{
        _ICompraCAD.Destroy (id);
}
}
}
