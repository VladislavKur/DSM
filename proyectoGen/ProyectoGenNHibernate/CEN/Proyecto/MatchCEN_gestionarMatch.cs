
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProyectoGenNHibernate.Exceptions;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.CAD.Proyecto;


/*PROTECTED REGION ID(usingProyectoGenNHibernate.CEN.Proyecto_Match_gestionarMatch) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CEN.Proyecto
{
public partial class MatchCEN
{
public void GestionarMatch (int p_Match_OID, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMatchEnum p_estado)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CEN.Proyecto_Match_gestionarMatch_customized) START*/

        MatchEN matchEN = null;

        //Initialized MatchEN
        matchEN = new MatchEN ();
        matchEN.Id = p_Match_OID;
        matchEN.Estado = p_estado;
        //Call to MatchCAD

        _IMatchCAD.GestionarMatch (matchEN);

        /*PROTECTED REGION END*/
}
}
}
