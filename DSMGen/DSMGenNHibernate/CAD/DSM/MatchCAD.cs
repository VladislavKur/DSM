
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
 * Clase Match:
 *
 */

namespace DSMGenNHibernate.CAD.DSM
{
public partial class MatchCAD : BasicCAD, IMatchCAD
{
public MatchCAD() : base ()
{
}

public MatchCAD(ISession sessionAux) : base (sessionAux)
{
}



public MatchEN ReadOIDDefault (int id
                               )
{
        MatchEN matchEN = null;

        try
        {
                SessionInitializeTransaction ();
                matchEN = (MatchEN)session.Get (typeof(MatchEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return matchEN;
}

public System.Collections.Generic.IList<MatchEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MatchEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MatchEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<MatchEN>();
                        else
                                result = session.CreateCriteria (typeof(MatchEN)).List<MatchEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MatchEN match)
{
        try
        {
                SessionInitializeTransaction ();
                MatchEN matchEN = (MatchEN)session.Load (typeof(MatchEN), match.Id);

                matchEN.Estado = match.Estado;



                session.Update (matchEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (MatchEN match)
{
        try
        {
                SessionInitializeTransaction ();
                if (match.Usuario_emisor != null) {
                        // Argumento OID y no colección.
                        match.Usuario_emisor = (DSMGenNHibernate.EN.DSM.UsuarioEN)session.Load (typeof(DSMGenNHibernate.EN.DSM.UsuarioEN), match.Usuario_emisor.Email);

                        match.Usuario_emisor.Match_receptor
                        .Add (match);
                }
                if (match.Usuario_receptor != null) {
                        // Argumento OID y no colección.
                        match.Usuario_receptor = (DSMGenNHibernate.EN.DSM.UsuarioEN)session.Load (typeof(DSMGenNHibernate.EN.DSM.UsuarioEN), match.Usuario_receptor.Email);

                        match.Usuario_receptor.Match_emisor
                                = match;
                }

                session.Save (match);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return match.Id;
}

public void Modify (MatchEN match)
{
        try
        {
                SessionInitializeTransaction ();
                MatchEN matchEN = (MatchEN)session.Load (typeof(MatchEN), match.Id);

                matchEN.Estado = match.Estado;

                session.Update (matchEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
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
                MatchEN matchEN = (MatchEN)session.Load (typeof(MatchEN), id);
                session.Delete (matchEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
