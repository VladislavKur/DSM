
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



/*PROTECTED REGION ID(usingProyectoGenNHibernate.CP.Proyecto_Match_filtrarPorNombre) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CP.Proyecto
{
public partial class MatchCP : BasicCP
{
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> FiltrarPorNombre (string p_nombre)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CP.Proyecto_Match_filtrarPorNombre) ENABLED START*/

        IMatchCAD matchCAD = null;
        MatchCEN matchCEN = null;

        System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MatchEN>  result = null;


        try
        {
                SessionInitializeTransaction ();
                matchCAD = new MatchCAD (session);
                matchCEN = new  MatchCEN (matchCAD);




                return matchCAD.FiltrarPorNombre (p_nombre);


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
        return (IList<UsuarioEN>)result;


        /*PROTECTED REGION END*/
}
}
}
