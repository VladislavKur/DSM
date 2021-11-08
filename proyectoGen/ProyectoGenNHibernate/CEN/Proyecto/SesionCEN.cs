

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
 *      Definition of the class SesionCEN
 *
 */
public partial class SesionCEN
{
private ISesionCAD _ISesionCAD;

public SesionCEN()
{
        this._ISesionCAD = new SesionCAD ();
}

public SesionCEN(ISesionCAD _ISesionCAD)
{
        this._ISesionCAD = _ISesionCAD;
}

public ISesionCAD get_ISesionCAD ()
{
        return this._ISesionCAD;
}

public int New_ (Nullable<DateTime> p_hora_inicio, string p_usuario, string p_usuario_0)
{
        SesionEN sesionEN = null;
        int oid;

        //Initialized SesionEN
        sesionEN = new SesionEN ();
        sesionEN.Hora_inicio = p_hora_inicio;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                sesionEN.Usuario = new ProyectoGenNHibernate.EN.Proyecto.UsuarioEN ();
                sesionEN.Usuario.Email = p_usuario;
        }


        if (p_usuario_0 != null) {
                // El argumento p_usuario_0 -> Property usuario_0 es oid = false
                // Lista de oids id
                sesionEN.Usuario_0 = new ProyectoGenNHibernate.EN.Proyecto.UsuarioEN ();
                sesionEN.Usuario_0.Email = p_usuario_0;
        }

        //Call to SesionCAD

        oid = _ISesionCAD.New_ (sesionEN);
        return oid;
}

public void Modify (int p_Sesion_OID, Nullable<DateTime> p_hora_inicio)
{
        SesionEN sesionEN = null;

        //Initialized SesionEN
        sesionEN = new SesionEN ();
        sesionEN.Id = p_Sesion_OID;
        sesionEN.Hora_inicio = p_hora_inicio;
        //Call to SesionCAD

        _ISesionCAD.Modify (sesionEN);
}

public void Destroy (int id
                     )
{
        _ISesionCAD.Destroy (id);
}

public SesionEN ReadOID (int id
                         )
{
        SesionEN sesionEN = null;

        sesionEN = _ISesionCAD.ReadOID (id);
        return sesionEN;
}

public System.Collections.Generic.IList<SesionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SesionEN> list = null;

        list = _ISesionCAD.ReadAll (first, size);
        return list;
}
}
}
