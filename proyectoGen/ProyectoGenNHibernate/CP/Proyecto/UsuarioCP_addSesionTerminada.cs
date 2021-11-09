
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



        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);






                //Call to UsuarioCAD

                // usuarioCAD.AddSesionTerminada (p_Usuario_OID, p_sesion_terminada_OIDs, sesion_a_terminar);
                usuarioCAD.AddSesionTerminada(p_Usuario_OID,  sesion_a_terminar);



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
