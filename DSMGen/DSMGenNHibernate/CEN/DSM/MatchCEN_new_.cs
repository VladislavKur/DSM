
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


/*PROTECTED REGION ID(usingDSMGenNHibernate.CEN.DSM_Match_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGenNHibernate.CEN.DSM
{
public partial class MatchCEN
{
public int New_ (string p_usuario_emisor, string p_usuario_receptor)
{
        /*PROTECTED REGION ID(DSMGenNHibernate.CEN.DSM_Match_new__customized) START*/

        MatchEN matchEN = null;

        int oid;

        //Initialized MatchEN
        matchEN = new MatchEN ();

        if (p_usuario_emisor != null) {
                matchEN.Usuario_emisor = new DSMGenNHibernate.EN.DSM.UsuarioEN ();
                matchEN.Usuario_emisor.Email = p_usuario_emisor;
        }


        if (p_usuario_receptor != null) {
                matchEN.Usuario_receptor = new DSMGenNHibernate.EN.DSM.UsuarioEN ();
                matchEN.Usuario_receptor.Email = p_usuario_receptor;
        }

        //Call to MatchCAD

        oid = _IMatchCAD.New_ (matchEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
