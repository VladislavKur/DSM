

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
 *      Definition of the class UsuariosVistosCEN
 *
 */
public partial class UsuariosVistosCEN
{
private IUsuariosVistosCAD _IUsuariosVistosCAD;

public UsuariosVistosCEN()
{
        this._IUsuariosVistosCAD = new UsuariosVistosCAD ();
}

public UsuariosVistosCEN(IUsuariosVistosCAD _IUsuariosVistosCAD)
{
        this._IUsuariosVistosCAD = _IUsuariosVistosCAD;
}

public IUsuariosVistosCAD get_IUsuariosVistosCAD ()
{
        return this._IUsuariosVistosCAD;
}

public int New_ ()
{
        UsuariosVistosEN usuariosVistosEN = null;
        int oid;

        //Initialized UsuariosVistosEN
        usuariosVistosEN = new UsuariosVistosEN ();
        //Call to UsuariosVistosCAD

        oid = _IUsuariosVistosCAD.New_ (usuariosVistosEN);
        return oid;
}

public void Modify (int p_UsuariosVistos_OID)
{
        UsuariosVistosEN usuariosVistosEN = null;

        //Initialized UsuariosVistosEN
        usuariosVistosEN = new UsuariosVistosEN ();
        usuariosVistosEN.Id = p_UsuariosVistos_OID;
        //Call to UsuariosVistosCAD

        _IUsuariosVistosCAD.Modify (usuariosVistosEN);
}

public void Destroy (int id
                     )
{
        _IUsuariosVistosCAD.Destroy (id);
}

public UsuariosVistosEN ReadOID (int id
                                 )
{
        UsuariosVistosEN usuariosVistosEN = null;

        usuariosVistosEN = _IUsuariosVistosCAD.ReadOID (id);
        return usuariosVistosEN;
}

public System.Collections.Generic.IList<UsuariosVistosEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuariosVistosEN> list = null;

        list = _IUsuariosVistosCAD.ReadAll (first, size);
        return list;
}
}
}
