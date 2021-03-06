
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



/*PROTECTED REGION ID(usingProyectoGenNHibernate.CP.Proyecto_Sesion_cerrarSesion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CP.Proyecto
{
public partial class SesionCP : BasicCP
{
public void CerrarSesion (int p_Sesion_OID, int p_usuario_0_OID)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CP.Proyecto_Sesion_cerrarSesion) ENABLED START*/

        ISesionCAD sesionCAD = null;
        SesionCEN sesionCEN = null;
        UsuarioCAD usuarioCAD = new UsuarioCAD ();
        UsuarioEN usuarioEN = new UsuarioEN ();



        try
        {
                SessionInitializeTransaction ();
                sesionCAD = new SesionCAD (session);
                sesionCEN = new  SesionCEN (sesionCAD);

                DateTime tiempo_actual = DateTime.Now;

                SesionEN sesionEN = new SesionEN ();

                sesionEN.Hora_fin = tiempo_actual;

                SesionEN sesionEN1 = sesionCAD.ReadOIDDefault (p_Sesion_OID);
                sesionEN1.Hora_fin = tiempo_actual;
                UsuarioCEN usuarioCEN = new UsuarioCEN ();

                Console.WriteLine ("Hora fin: " + tiempo_actual);
                // anhado la sesion terminada a la lista

                if (sesionEN.Hora_fin != null) usuarioCEN.AddSesionTerminada (p_usuario_0_OID);

                //Call to SesionCAD



                sesionCAD.ModifyDefault (sesionEN1);
                sesionCAD.CerrarSesion (p_Sesion_OID, p_usuario_0_OID);



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
