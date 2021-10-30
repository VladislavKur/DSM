

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

public void Modify (int p_Match_OID, DSMGenNHibernate.Enumerated.DSM.EstadoMatchEnum p_estado)
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
}
}
