

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
