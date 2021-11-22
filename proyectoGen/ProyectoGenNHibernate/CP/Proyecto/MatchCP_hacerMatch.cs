
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
public void HacerMatch (int p_oid, int p_oid_usuario_emisor, int p_oid_usuario_receptor)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CP.Proyecto_Match_hacerMatch) ENABLED START*/

        IMatchCAD matchCAD = null;
        MatchCEN matchCEN = null;

        UsuarioCAD usuarioCAD = new UsuarioCAD ();



        try
        {
                SessionInitializeTransaction ();
                int oid;
                //Initialized MatchEN
                MatchEN matchEN;
                matchEN = new MatchEN ();
                matchEN.Estado = Enumerated.Proyecto.EstadoMatchEnum.pendiente;

                bool aceptoMatch = false;


                UsuarioEN usuarioEmisorEN = usuarioCAD.ReadOIDDefault (p_oid_usuario_emisor);
                UsuarioEN usuarioReceptorEN = usuarioCAD.ReadOIDDefault (p_oid_usuario_receptor);
                foreach (MatchEN matchEmisor in usuarioEmisorEN.Match_emisor) if (!(aceptoMatch)) {
                                if (matchEmisor.Usuario_receptor == usuarioReceptorEN) {
                                        aceptoMatch = true;
                                }
                        }

                foreach (MatchEN matchReceptor in usuarioReceptorEN.Match_receptor) if (!(aceptoMatch)) {
                                if (matchReceptor.Usuario_emisor == usuarioReceptorEN) {
                                        aceptoMatch = true;
                                }
                        }

                if (!(aceptoMatch)) {
                        throw new Exception ("El match no ha sido aceptado ");
                }
                else{
                        matchEN.Estado = Enumerated.Proyecto.EstadoMatchEnum.aceptado;
                }



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
