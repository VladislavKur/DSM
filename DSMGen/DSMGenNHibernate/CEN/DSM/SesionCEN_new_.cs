
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGenNHibernate.Exceptions;
using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.CAD.DSM;


/*PROTECTED REGION ID(usingDSMGenNHibernate.CEN.DSM_Sesion_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGenNHibernate.CEN.DSM
{
public partial class SesionCEN
{
public int New_ ()
{
        /*PROTECTED REGION ID(DSMGenNHibernate.CEN.DSM_Sesion_new__customized) START*/

        SesionEN sesionEN = null;

        int oid;

        //Initialized SesionEN
        sesionEN = new SesionEN ();
        //Call to SesionCAD

        oid = _ISesionCAD.New_ (sesionEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
