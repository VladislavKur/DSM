
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
 * Clase UsuarioVIP:
 *
 */

namespace ProyectoGenNHibernate.CAD.Proyecto
{
public partial class UsuarioVIPCAD : BasicCAD, IUsuarioVIPCAD
{
public UsuarioVIPCAD() : base ()
{
}

public UsuarioVIPCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioVIPEN ReadOIDDefault (string email
                                    )
{
        UsuarioVIPEN usuarioVIPEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioVIPEN = (UsuarioVIPEN)session.Get (typeof(UsuarioVIPEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioVIPCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioVIPEN;
}

public System.Collections.Generic.IList<UsuarioVIPEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioVIPEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioVIPEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioVIPEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioVIPEN)).List<UsuarioVIPEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioVIPCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioVIPEN usuarioVIP)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioVIPEN usuarioVIPEN = (UsuarioVIPEN)session.Load (typeof(UsuarioVIPEN), usuarioVIP.Email);

                usuarioVIPEN.NumSocio = usuarioVIP.NumSocio;

                session.Update (usuarioVIPEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioVIPCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (UsuarioVIPEN usuarioVIP)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (usuarioVIP);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioVIPCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioVIP.Email;
}

public void Modify (UsuarioVIPEN usuarioVIP)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioVIPEN usuarioVIPEN = (UsuarioVIPEN)session.Load (typeof(UsuarioVIPEN), usuarioVIP.Email);

                usuarioVIPEN.Pass = usuarioVIP.Pass;


                usuarioVIPEN.Nickname = usuarioVIP.Nickname;


                usuarioVIPEN.Nombre = usuarioVIP.Nombre;


                usuarioVIPEN.Apellidos = usuarioVIP.Apellidos;


                usuarioVIPEN.Fecha_nacimiento = usuarioVIP.Fecha_nacimiento;


                usuarioVIPEN.Orientacion_sexual = usuarioVIP.Orientacion_sexual;


                usuarioVIPEN.Genero = usuarioVIP.Genero;


                usuarioVIPEN.Fecha_registro = usuarioVIP.Fecha_registro;


                usuarioVIPEN.Like_counter = usuarioVIP.Like_counter;


                usuarioVIPEN.EsPremium = usuarioVIP.EsPremium;


                usuarioVIPEN.NumSocio = usuarioVIP.NumSocio;

                session.Update (usuarioVIPEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioVIPCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string email
                     )
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioVIPEN usuarioVIPEN = (UsuarioVIPEN)session.Load (typeof(UsuarioVIPEN), email);
                session.Delete (usuarioVIPEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioVIPCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: UsuarioVIPEN
public UsuarioVIPEN ReadOID (string email
                             )
{
        UsuarioVIPEN usuarioVIPEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioVIPEN = (UsuarioVIPEN)session.Get (typeof(UsuarioVIPEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioVIPCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioVIPEN;
}

public System.Collections.Generic.IList<UsuarioVIPEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioVIPEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioVIPEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioVIPEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioVIPEN)).List<UsuarioVIPEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioVIPCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
