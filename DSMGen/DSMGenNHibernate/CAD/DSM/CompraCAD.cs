
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
 * Clase Compra:
 *
 */

namespace DSMGenNHibernate.CAD.DSM
{
public partial class CompraCAD : BasicCAD, ICompraCAD
{
public CompraCAD() : base ()
{
}

public CompraCAD(ISession sessionAux) : base (sessionAux)
{
}



public CompraEN ReadOIDDefault (int id
                                )
{
        CompraEN compraEN = null;

        try
        {
                SessionInitializeTransaction ();
                compraEN = (CompraEN)session.Get (typeof(CompraEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return compraEN;
}

public System.Collections.Generic.IList<CompraEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CompraEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CompraEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CompraEN>();
                        else
                                result = session.CreateCriteria (typeof(CompraEN)).List<CompraEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CompraEN compra)
{
        try
        {
                SessionInitializeTransaction ();
                CompraEN compraEN = (CompraEN)session.Load (typeof(CompraEN), compra.Id);


                compraEN.Precio = compra.Precio;


                compraEN.EstadoCompra = compra.EstadoCompra;

                session.Update (compraEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


//Sin e: ReadOID
//Con e: CompraEN
public CompraEN ReadOID (int id
                         )
{
        CompraEN compraEN = null;

        try
        {
                SessionInitializeTransaction ();
                compraEN = (CompraEN)session.Get (typeof(CompraEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return compraEN;
}

public System.Collections.Generic.IList<CompraEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CompraEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CompraEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CompraEN>();
                else
                        result = session.CreateCriteria (typeof(CompraEN)).List<CompraEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int New_ (CompraEN compra)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (compra);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return compra.Id;
}

public void Modify (CompraEN compra)
{
        try
        {
                SessionInitializeTransaction ();
                CompraEN compraEN = (CompraEN)session.Load (typeof(CompraEN), compra.Id);

                compraEN.Precio = compra.Precio;


                compraEN.EstadoCompra = compra.EstadoCompra;

                session.Update (compraEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
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
                CompraEN compraEN = (CompraEN)session.Load (typeof(CompraEN), id);
                session.Delete (compraEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in CompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
