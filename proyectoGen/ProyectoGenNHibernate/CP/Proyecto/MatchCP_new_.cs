
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
using ProyectoGenNHibernate.Enumerated.Proyecto;




/*PROTECTED REGION ID(usingProyectoGenNHibernate.CP.Proyecto_Match_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CP.Proyecto
{
public partial class MatchCP : BasicCP
{
public ProyectoGenNHibernate.EN.Proyecto.MatchEN New_ (ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMatchEnum p_estado, int p_usuario_emisor, int p_usuario_receptor)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CP.Proyecto_Match_new_) ENABLED START*/

        IMatchCAD matchCAD = null;
        MatchCEN matchCEN = null;

        ProyectoGenNHibernate.EN.Proyecto.MatchEN result = null;


        try
        {
                SessionInitializeTransaction ();
                matchCAD = new MatchCAD (session);
                matchCEN = new  MatchCEN (matchCAD);

                //UsuarioCAD usuarioCAD = new UsuarioCAD (session);



                int oid;
                //Initialized MatchEN
                MatchEN matchEN;
                matchEN = new MatchEN ();
                matchEN.Estado = p_estado;
                //matchEN.Estado = EstadoMatchEnum.pendiente;


                //UsuarioEN usuarioEN = usuarioCAD.ReadOIDDefault (p_usuario_emisor);

                if (p_usuario_emisor != null) {
                        matchEN.Usuario_emisor = new ProyectoGenNHibernate.EN.Proyecto.UsuarioEN ();
                        matchEN.Usuario_emisor.Id = p_usuario_emisor;
                }


                if (p_usuario_receptor != null) {
                        matchEN.Usuario_receptor = new ProyectoGenNHibernate.EN.Proyecto.UsuarioEN ();
                        matchEN.Usuario_receptor.Id = p_usuario_receptor;
                }

                //Call to MatchCAD

                oid = matchCAD.New_ (matchEN);
                result = matchCAD.ReadOIDDefault (oid);



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
        return result;


        /*PROTECTED REGION END*/
}
}
}
