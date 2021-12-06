
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
 * Clase UsuariosVistos:
 *
 */

namespace ProyectoGenNHibernate.CAD.Proyecto
{
public partial class UsuariosVistosCAD : BasicCAD, IUsuariosVistosCAD
{
public UsuariosVistosCAD() : base ()
{
}

public UsuariosVistosCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuariosVistosEN ReadOIDDefault (int id
                                        )
{
        UsuariosVistosEN usuariosVistosEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuariosVistosEN = (UsuariosVistosEN)session.Get (typeof(UsuariosVistosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuariosVistosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuariosVistosEN;
}

public System.Collections.Generic.IList<UsuariosVistosEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuariosVistosEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuariosVistosEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuariosVistosEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuariosVistosEN)).List<UsuariosVistosEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuariosVistosCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuariosVistosEN usuariosVistos)
{
        try
        {
                SessionInitializeTransaction ();
                UsuariosVistosEN usuariosVistosEN = (UsuariosVistosEN)session.Load (typeof(UsuariosVistosEN), usuariosVistos.Id);
                session.Update (usuariosVistosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuariosVistosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (UsuariosVistosEN usuariosVistos)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (usuariosVistos);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuariosVistosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuariosVistos.Id;
}

public void Modify (UsuariosVistosEN usuariosVistos)
{
        try
        {
                SessionInitializeTransaction ();
                UsuariosVistosEN usuariosVistosEN = (UsuariosVistosEN)session.Load (typeof(UsuariosVistosEN), usuariosVistos.Id);
                session.Update (usuariosVistosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuariosVistosCAD.", ex);
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
                UsuariosVistosEN usuariosVistosEN = (UsuariosVistosEN)session.Load (typeof(UsuariosVistosEN), id);
                session.Delete (usuariosVistosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuariosVistosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: UsuariosVistosEN
public UsuariosVistosEN ReadOID (int id
                                 )
{
        UsuariosVistosEN usuariosVistosEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuariosVistosEN = (UsuariosVistosEN)session.Get (typeof(UsuariosVistosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuariosVistosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuariosVistosEN;
}

public System.Collections.Generic.IList<UsuariosVistosEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuariosVistosEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuariosVistosEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuariosVistosEN>();
                else
                        result = session.CreateCriteria (typeof(UsuariosVistosEN)).List<UsuariosVistosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuariosVistosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
