
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
                UsuarioCAD usuarioCAD = new UsuarioCAD (session);
                matchCAD = new MatchCAD (session);
                matchCEN = new  MatchCEN (matchCAD);

                int oid;
                //Initialized MatchEN
                MatchEN matchEN;
                matchEN = new MatchEN ();
                matchEN.Estado = Enumerated.Proyecto.EstadoMatchEnum.pendiente;

                //UsuarioEN usuarioEN = usuarioCAD.ReadOIDDefault (p_usuario_emisor);
                bool aceptoMatch = false;


                UsuarioEN usuarioEmisorEN = usuarioCAD.ReadOIDDefault (p_usuario_emisor);
                UsuarioEN usuarioReceptorEN = usuarioCAD.ReadOIDDefault (p_usuario_receptor);


                //recorremos en los que yo soy el receptor
                //aceptamos crear el match si se lo envio a alguien que no me haya enviado

                /*
                 * foreach (MatchEN matchEmisor in usuarioEmisorEN.Match_emisor) if (!(aceptoMatch)) {
                 *  if (matchEmisor.Usuario_receptor == usuarioReceptorEN) {
                 *          aceptoMatch = true;
                 *
                 *  }
                 * }*/


                /*
                 * foreach (MatchEN matchReceptor in usuarioReceptorEN.Match_emisor) if (!(aceptoMatch)) {
                 *  if (matchReceptor.Usuario_receptor == usuarioReceptorEN) {
                 *          aceptoMatch = false;
                 *  }
                 * }*/

                //todos los match en los que yo soy el receptor si el usuario emisor es el que recibe este
                /*foreach (MatchEN matchEmisor in usuarioReceptorEN.Match_receptor) if (!aceptoMatch)
                 *  {
                 *      if (matchEmisor.Usuario_emisor == usuarioReceptorEN)
                 *      {
                 *          aceptoMatch = true;
                 *      }
                 *  }*/


                /*
                 * foreach (MatchEN matchEmisor in usuarioEmisorEN.Match_emisor) if (!(aceptoMatch))
                 * {
                 *  if (matchEmisor.Usuario_receptor == usuarioReceptorEN)
                 *  {
                 *      aceptoMatch = true;
                 *  }
                 * }*/
                /*
                 * foreach (MatchEN matchEmisor in usuarioEmisorEN.Match_emisor) if (!(aceptoMatch)) {
                 *              if (matchEmisor.Usuario_receptor == usuarioReceptorEN) {
                 *                      aceptoMatch = true;
                 *              }
                 *      }
                 *
                 * foreach (MatchEN matchReceptor in usuarioReceptorEN.Match_receptor) if (!(aceptoMatch)) {
                 *      if (matchReceptor.Usuario_emisor == usuarioReceptorEN) {
                 *              aceptoMatch = true;
                 *      }
                 * }*/
                IList<MatchEN> listaTodosMatch = matchCAD.ReadAllDefault (0, -1);
                foreach (MatchEN match in listaTodosMatch) {
                        if ((match.Usuario_emisor == usuarioEmisorEN && match.Usuario_receptor == usuarioReceptorEN) ||
                            (match.Usuario_emisor == usuarioReceptorEN && match.Usuario_receptor == usuarioEmisorEN)) {
                                aceptoMatch = true;
                        }
                }


                if (aceptoMatch) {
                        throw new Exception ("No se ha podido crear el match porque ya tienen un Match anterior");
                }




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
