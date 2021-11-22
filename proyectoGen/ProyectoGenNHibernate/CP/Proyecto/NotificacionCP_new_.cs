
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



/*PROTECTED REGION ID(usingProyectoGenNHibernate.CP.Proyecto_Notificacion_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CP.Proyecto
{
public partial class NotificacionCP : BasicCP
{
public ProyectoGenNHibernate.EN.Proyecto.NotificacionEN New_ (string p_contenido)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CP.Proyecto_Notificacion_new_) ENABLED START*/

        INotificacionCAD notificacionCAD = null;
        NotificacionCEN notificacionCEN = null;

        ProyectoGenNHibernate.EN.Proyecto.NotificacionEN result = null;


        try
        {
                SessionInitializeTransaction ();
                notificacionCAD = new NotificacionCAD (session);
                notificacionCEN = new  NotificacionCEN (notificacionCAD);




                int oid;
                //Initialized NotificacionEN
                NotificacionEN notificacionEN;
                notificacionEN = new NotificacionEN ();
                notificacionEN.Contenido = p_contenido;

                //Call to NotificacionCAD

                oid = notificacionCAD.New_ (notificacionEN);
                result = notificacionCAD.ReadOIDDefault (oid);



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
