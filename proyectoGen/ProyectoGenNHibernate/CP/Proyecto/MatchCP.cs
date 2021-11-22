
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using ProyectoGenNHibernate.Exceptions;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.CAD.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;



namespace ProyectoGenNHibernate.CP.Proyecto
{
public partial class MatchCP : BasicCP
{
public MatchCP() : base ()
{
}

public MatchCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
