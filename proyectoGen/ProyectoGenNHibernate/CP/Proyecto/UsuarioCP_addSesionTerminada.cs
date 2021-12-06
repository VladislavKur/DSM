
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



/*PROTECTED REGION ID(usingProyectoGenNHibernate.CP.Proyecto_Usuario_addSesionTerminada) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CP.Proyecto
{
public partial class UsuarioCP : BasicCP
{
public void AddSesionTerminada (int p_Usuario_OID, ProyectoGenNHibernate.EN.Proyecto.SesionEN sesion_a_terminar)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CP.Proyecto_Usuario_addSesionTerminada) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;
        UsuarioEN usuarioEN = new UsuarioEN ();

        ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuarioEN1 = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);

                usuarioEN.Sesion_terminada = (System.Collections.Generic.IList<SesionEN>)session.Load (typeof(SesionEN), sesion_a_terminar);

                usuarioEN.Sesion_terminada.Add (sesion_a_terminar);



                //Call to UsuarioCAD

                // usuarioCAD.AddSesionTerminada (p_Usuario_OID, p_sesion_terminada_OIDs, sesion_a_terminar);
                usuarioCAD.AddSesionTerminada (p_Usuario_OID, sesion_a_terminar);


                session.Update (usuarioEN);
                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error en usuario CAD", ex);
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
