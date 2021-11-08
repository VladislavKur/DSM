
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.CAD.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;



/*PROTECTED REGION ID(usingProyectoGenNHibernate.CP.Proyecto_Match_hacerMatch) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CP.Proyecto
{
public partial class MatchCP : BasicCP
{
public void HacerMatch (int p_oid, string p_oid_usuario_emisor, string p_oid_usuario_receptor)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CP.Proyecto_Match_hacerMatch) ENABLED START*/

        IMatchCAD matchCAD = null;
        MatchCEN matchCEN = null;



        try
        {
                SessionInitializeTransaction ();
                matchCAD = new MatchCAD (session);
                matchCEN = new  MatchCEN (matchCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method HacerMatch() not yet implemented.");



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
