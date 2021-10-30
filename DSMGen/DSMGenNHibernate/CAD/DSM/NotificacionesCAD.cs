
using System;
using System.Text;
using DSMGenNHibernate.CEN.DSM;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.Exceptions;


/*
 * Clase Notificaciones:
 *
 */

namespace DSMGenNHibernate.CAD.DSM
{
public partial class NotificacionesCAD : BasicCAD, INotificacionesCAD
{
public NotificacionesCAD() : base ()
{
}

public NotificacionesCAD(ISession sessionAux) : base (sessionAux)
{
}



public NotificacionesEN ReadOIDDefault (int id
                                        )
{
        NotificacionesEN notificacionesEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionesEN = (NotificacionesEN)session.Get (typeof(NotificacionesEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionesEN;
}

public System.Collections.Generic.IList<NotificacionesEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificacionesEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificacionesEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificacionesEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificacionesEN)).List<NotificacionesEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionesCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificacionesEN notificaciones)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionesEN notificacionesEN = (NotificacionesEN)session.Load (typeof(NotificacionesEN), notificaciones.Id);


                notificacionesEN.TipoNotificacion = notificaciones.TipoNotificacion;


                notificacionesEN.Contenido = notificaciones.Contenido;


                notificacionesEN.Id_tipo = notificaciones.Id_tipo;

                session.Update (notificacionesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NotificacionesEN notificaciones)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (notificaciones);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificaciones.Id;
}

public void Modify (NotificacionesEN notificaciones)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionesEN notificacionesEN = (NotificacionesEN)session.Load (typeof(NotificacionesEN), notificaciones.Id);

                notificacionesEN.TipoNotificacion = notificaciones.TipoNotificacion;


                notificacionesEN.Contenido = notificaciones.Contenido;


                notificacionesEN.Id_tipo = notificaciones.Id_tipo;

                session.Update (notificacionesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionesCAD.", ex);
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
                NotificacionesEN notificacionesEN = (NotificacionesEN)session.Load (typeof(NotificacionesEN), id);
                session.Delete (notificacionesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: NotificacionesEN
public NotificacionesEN ReadOID (int id
                                 )
{
        NotificacionesEN notificacionesEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionesEN = (NotificacionesEN)session.Get (typeof(NotificacionesEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionesEN;
}

public System.Collections.Generic.IList<NotificacionesEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionesEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NotificacionesEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<NotificacionesEN>();
                else
                        result = session.CreateCriteria (typeof(NotificacionesEN)).List<NotificacionesEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
