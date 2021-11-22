
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



/*PROTECTED REGION ID(usingProyectoGenNHibernate.CP.Proyecto_Mensaje_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CP.Proyecto
{
public partial class MensajeCP : BasicCP
{
public ProyectoGenNHibernate.EN.Proyecto.MensajeEN New_ (string p_contenido, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMensajeEnum p_estado, int p_usuario_emisor, int p_usuario_receptor)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CP.Proyecto_Mensaje_new_) ENABLED START*/

        IMensajeCAD mensajeCAD = null;
        MensajeCEN mensajeCEN = null;

        ProyectoGenNHibernate.EN.Proyecto.MensajeEN result = null;


        try
        {
                SessionInitializeTransaction ();
                mensajeCAD = new MensajeCAD (session);
                mensajeCEN = new  MensajeCEN (mensajeCAD);

                UsuarioCAD usuarioCAD = new UsuarioCAD (session);



                int oid;
                //Initialized MensajeEN
                MensajeEN mensajeEN;
                mensajeEN = new MensajeEN ();
                mensajeEN.Contenido = p_contenido;

                mensajeEN.Estado = p_estado;
                bool aceptoMensaje = false;


                UsuarioEN usuarioEmisorEN = usuarioCAD.ReadOIDDefault (p_usuario_emisor);
                UsuarioEN usuarioReceptorEN = usuarioCAD.ReadOIDDefault (p_usuario_receptor);
                foreach (MatchEN matchEmisor in usuarioEmisorEN.Match_emisor) if (!(aceptoMensaje)) {
                                if (matchEmisor.Usuario_receptor == usuarioReceptorEN) {
                                        aceptoMensaje = true;
                                }
                        }

                foreach (MatchEN matchReceptor in usuarioReceptorEN.Match_receptor) if (!(aceptoMensaje)) {
                                if (matchReceptor.Usuario_emisor == usuarioReceptorEN) {
                                        aceptoMensaje = true;
                                }
                        }

                if (!(aceptoMensaje)) {
                        throw new Exception ("No se puede enviar un mensaje si no hay match");
                }

                if (p_usuario_emisor != null) {
                        mensajeEN.Usuario_emisor = new ProyectoGenNHibernate.EN.Proyecto.UsuarioEN ();
                        mensajeEN.Usuario_emisor.Id = p_usuario_emisor;
                }


                if (p_usuario_receptor != null) {
                        mensajeEN.Usuario_receptor = new ProyectoGenNHibernate.EN.Proyecto.UsuarioEN ();
                        mensajeEN.Usuario_receptor.Id = p_usuario_receptor;
                }

                //Call to MensajeCAD

                oid = mensajeCAD.New_ (mensajeEN);
                result = mensajeCAD.ReadOIDDefault (oid);



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
