
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using DSMGenNHibernate.Exceptions;
using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.CAD.DSM;
using DSMGenNHibernate.CEN.DSM;



namespace DSMGenNHibernate.CP.DSM
{
public partial class UsuarioCP : BasicCP
{
public UsuarioCP() : base ()
{
}

public UsuarioCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
