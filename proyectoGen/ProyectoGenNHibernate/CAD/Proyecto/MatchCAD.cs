
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
 * Clase Match:
 *
 */

namespace ProyectoGenNHibernate.CAD.Proyecto
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
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
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
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
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
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
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
                        match.Usuario_emisor = (ProyectoGenNHibernate.EN.Proyecto.UsuarioEN)session.Load (typeof(ProyectoGenNHibernate.EN.Proyecto.UsuarioEN), match.Usuario_emisor.Id);

                        match.Usuario_emisor.Match_emisor
                        .Add (match);
                }
                if (match.Usuario_receptor != null) {
                        // Argumento OID y no colección.
                        match.Usuario_receptor = (ProyectoGenNHibernate.EN.Proyecto.UsuarioEN)session.Load (typeof(ProyectoGenNHibernate.EN.Proyecto.UsuarioEN), match.Usuario_receptor.Id);

                        match.Usuario_receptor.Match_receptor
                        .Add (match);
                }

                session.Save (match);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
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
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
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
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: MatchEN
public MatchEN ReadOID (int id
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
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return matchEN;
}

public System.Collections.Generic.IList<MatchEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MatchEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MatchEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<MatchEN>();
                else
                        result = session.CreateCriteria (typeof(MatchEN)).List<MatchEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
