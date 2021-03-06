

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
 *      Definition of the class MatchCEN
 *
 */
public partial class MatchCEN
{
private IMatchCAD _IMatchCAD;

public MatchCEN()
{
        this._IMatchCAD = new MatchCAD ();
}

public MatchCEN(IMatchCAD _IMatchCAD)
{
        this._IMatchCAD = _IMatchCAD;
}

public IMatchCAD get_IMatchCAD ()
{
        return this._IMatchCAD;
}

public void Modify (int p_Match_OID, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMatchEnum p_estado)
{
        MatchEN matchEN = null;

        //Initialized MatchEN
        matchEN = new MatchEN ();
        matchEN.Id = p_Match_OID;
        matchEN.Estado = p_estado;
        //Call to MatchCAD

        _IMatchCAD.Modify (matchEN);
}

public void Destroy (int id
                     )
{
        _IMatchCAD.Destroy (id);
}

public MatchEN ReadOID (int id
                        )
{
        MatchEN matchEN = null;

        matchEN = _IMatchCAD.ReadOID (id);
        return matchEN;
}

public System.Collections.Generic.IList<MatchEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MatchEN> list = null;

        list = _IMatchCAD.ReadAll (first, size);
        return list;
}
public void GestionarMatch (int p_Match_OID, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMatchEnum p_estado)
{
        MatchEN matchEN = null;

        //Initialized MatchEN
        matchEN = new MatchEN ();
        matchEN.Id = p_Match_OID;
        matchEN.Estado = p_estado;
        //Call to MatchCAD

        _IMatchCAD.GestionarMatch (matchEN);
}
}
}
