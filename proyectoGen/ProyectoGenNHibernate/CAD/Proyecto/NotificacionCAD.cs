
using System;
using System.Text;
using ProyectoGenNHibernate.CEN.Proyecto;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.Exceptions;


/*
 * Clase Notificacion:
 *
 */

namespace ProyectoGenNHibernate.CAD.Proyecto
{
public partial class NotificacionCAD : BasicCAD, INotificacionCAD
{
public NotificacionCAD() : base ()
{
}

public NotificacionCAD(ISession sessionAux) : base (sessionAux)
{
}



public NotificacionEN ReadOIDDefault (int id
                                      )
{
        NotificacionEN notificacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Get (typeof(NotificacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificacionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificacionEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificacionEN)).List<NotificacionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificacionEN notificacion)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionEN notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), notificacion.Id);

                notificacionEN.Tipo = notificacion.Tipo;


                notificacionEN.Contenido = notificacion.Contenido;


                notificacionEN.Id_tipo = notificacion.Id_tipo;


                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NotificacionEN notificacion)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (notificacion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacion.Id;
}

public void Modify (NotificacionEN notificacion)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionEN notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), notificacion.Id);

                notificacionEN.Contenido = notificacion.Contenido;

                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionEN notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), id);
                session.Delete (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: NotificacionEN
public NotificacionEN ReadOID (int id
                               )
{
        NotificacionEN notificacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Get (typeof(NotificacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NotificacionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<NotificacionEN>();
                else
                        result = session.CreateCriteria (typeof(NotificacionEN)).List<NotificacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AsignarSesion (int p_Notificacion_OID, int p_sesion_OID)
{
        ProyectoGenNHibernate.EN.Proyecto.NotificacionEN notificacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), p_Notificacion_OID);
                notificacionEN.Sesion = (ProyectoGenNHibernate.EN.Proyecto.SesionEN)session.Load (typeof(ProyectoGenNHibernate.EN.Proyecto.SesionEN), p_sesion_OID);

                notificacionEN.Sesion.Notificacion.Add (notificacionEN);



                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
