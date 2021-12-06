
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
public void HacerMatch (int p_oid_Emisor, int p_oid_usuario_emisor, int p_oid_usuario_receptor, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMatchEnum p_nuevo_estado)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CP.Proyecto_Match_hacerMatch) ENABLED START*/

        IMatchCAD matchCAD = null;
        MatchCEN matchCEN = null;


        ProyectoGenNHibernate.EN.Proyecto.MatchEN result = null;


        try
        {
                SessionInitializeTransaction ();
                int oid;
                //Initialized MatchEN
                UsuarioCAD usuarioCAD = new UsuarioCAD (session);
                matchCAD = new MatchCAD (session);

                MatchEN matchEN = matchCAD.ReadOIDDefault (p_oid_Emisor);
                bool aceptoMatch = false;


                UsuarioEN usuarioEmisorEN = usuarioCAD.ReadOIDDefault (p_oid_usuario_emisor);
                UsuarioEN usuarioReceptorEN = usuarioCAD.ReadOIDDefault (p_oid_usuario_receptor);
                /*
                 * foreach (MatchEN matchEmisor in usuarioEmisorEN.Match_emisor) if (!(aceptoMatch)) {
                 *              if (matchEmisor.Usuario_receptor == usuarioReceptorEN) {
                 *                      aceptoMatch = true;
                 *              }
                 *      }
                 *
                 * foreach (MatchEN matchReceptor in usuarioReceptorEN.Match_receptor) if (!(aceptoMatch)) {
                 *              if (matchReceptor.Usuario_emisor == usuarioReceptorEN) {
                 *                      aceptoMatch = true;
                 *              }
                 *      }*/
                if (p_nuevo_estado == Enumerated.Proyecto.EstadoMatchEnum.rechazado) {
                        matchEN.Estado = Enumerated.Proyecto.EstadoMatchEnum.rechazado;
                }
                else if (p_nuevo_estado == Enumerated.Proyecto.EstadoMatchEnum.aceptado) {
                        matchEN.Estado = Enumerated.Proyecto.EstadoMatchEnum.aceptado;
                }
                /*
                 * if (!(aceptoMatch)) {
                 *      //matchEN.Estado = Enumerated.Proyecto.EstadoMatchEnum.rechazado;
                 * }
                 * else{
                 *      matchEN.Estado = Enumerated.Proyecto.EstadoMatchEnum.aceptado;
                 * }*/


                matchCAD.ModifyDefault (matchEN);


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
