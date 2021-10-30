
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
 * Clase Sesion:
 *
 */

namespace DSMGenNHibernate.CAD.DSM
{
public partial class SesionCAD : BasicCAD, ISesionCAD
{
public SesionCAD() : base ()
{
}

public SesionCAD(ISession sessionAux) : base (sessionAux)
{
}



public SesionEN ReadOIDDefault (int id
                                )
{
        SesionEN sesionEN = null;

        try
        {
                SessionInitializeTransaction ();
                sesionEN = (SesionEN)session.Get (typeof(SesionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sesionEN;
}

public System.Collections.Generic.IList<SesionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SesionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SesionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<SesionEN>();
                        else
                                result = session.CreateCriteria (typeof(SesionEN)).List<SesionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (SesionEN sesion)
{
        try
        {
                SessionInitializeTransaction ();
                SesionEN sesionEN = (SesionEN)session.Load (typeof(SesionEN), sesion.Id);



                sesionEN.Hora_inicio = sesion.Hora_inicio;


                sesionEN.Hora_fin = sesion.Hora_fin;


                session.Update (sesionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (SesionEN sesion)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (sesion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sesion.Id;
}

public void Modify (SesionEN sesion)
{
        try
        {
                SessionInitializeTransaction ();
                SesionEN sesionEN = (SesionEN)session.Load (typeof(SesionEN), sesion.Id);

                sesionEN.Hora_inicio = sesion.Hora_inicio;

                session.Update (sesionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
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
                SesionEN sesionEN = (SesionEN)session.Load (typeof(SesionEN), id);
                session.Delete (sesionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: SesionEN
public SesionEN ReadOID (int id
                         )
{
        SesionEN sesionEN = null;

        try
        {
                SessionInitializeTransaction ();
                sesionEN = (SesionEN)session.Get (typeof(SesionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sesionEN;
}

public System.Collections.Generic.IList<SesionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SesionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SesionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<SesionEN>();
                else
                        result = session.CreateCriteria (typeof(SesionEN)).List<SesionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in SesionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
