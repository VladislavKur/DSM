
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



/*PROTECTED REGION ID(usingProyectoGenNHibernate.CP.Proyecto_Match_new2) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CP.Proyecto
{
public partial class MatchCP : BasicCP
{
public ProyectoGenNHibernate.EN.Proyecto.MatchEN New2 (int p_usuario_emisor, int p_usuario_receptor)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CP.Proyecto_Match_new2) ENABLED START*/

        IMatchCAD matchCAD = null;
        MatchCEN matchCEN = null;

        ProyectoGenNHibernate.EN.Proyecto.MatchEN result = null;


        try
        {
                SessionInitializeTransaction ();
                matchCAD = new MatchCAD (session);
                matchCEN = new  MatchCEN (matchCAD);
                UsuarioCAD usuarioCAD = new UsuarioCAD (session);



                int oid;
                //Initialized MatchEN
                MatchEN matchEN;
                matchEN = new MatchEN ();
                matchEN.Estado = Enumerated.Proyecto.EstadoMatchEnum.pendiente;



                if (p_usuario_emisor != -1) {
                        matchEN.Usuario_emisor = new ProyectoGenNHibernate.EN.Proyecto.UsuarioEN ();
                        matchEN.Usuario_emisor.Id = p_usuario_emisor;
                }


                if (p_usuario_receptor != -1) {
                        matchEN.Usuario_receptor = new ProyectoGenNHibernate.EN.Proyecto.UsuarioEN ();
                        matchEN.Usuario_receptor.Id = p_usuario_receptor;
                }

                //Codigo nuestro

                bool aceptoMatch = false;

                UsuarioEN usuarioEmisorEN = usuarioCAD.ReadOIDDefault (p_usuario_emisor);
                UsuarioEN usuarioReceptorEN = usuarioCAD.ReadOIDDefault (p_usuario_receptor);

                IList<MatchEN> listaTodosMatch = matchCEN.ReadAll (0, -1);
                foreach (MatchEN match in listaTodosMatch) {
                        if ((match.Usuario_emisor == usuarioEmisorEN && match.Usuario_receptor == usuarioReceptorEN) ||
                            (match.Usuario_emisor == usuarioReceptorEN && match.Usuario_receptor == usuarioEmisorEN)) {
                                aceptoMatch = true;
                        }
                }
                if (aceptoMatch) {
                        throw new Exception ("No se ha podido crear el match porque ya tienen un Match anterior");
                }
                //Call to MatchCAD

                oid = matchCAD.New2 (matchEN);
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
