
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
 * Clase Usuario:
 *
 */

namespace ProyectoGenNHibernate.CAD.Proyecto
{
public partial class UsuarioCAD : BasicCAD, IUsuarioCAD
{
public UsuarioCAD() : base ()
{
}

public UsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioEN ReadOIDDefault (int id
                                 )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Id);

                usuarioEN.Pass = usuario.Pass;


                usuarioEN.Email = usuario.Email;


                usuarioEN.Nickname = usuario.Nickname;


                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Apellidos = usuario.Apellidos;


                usuarioEN.Fecha_nacimiento = usuario.Fecha_nacimiento;


                usuarioEN.Orientacion_sexual = usuario.Orientacion_sexual;


                usuarioEN.Genero = usuario.Genero;


                usuarioEN.Fecha_registro = usuario.Fecha_registro;


                usuarioEN.Like_counter = usuario.Like_counter;









                usuarioEN.Edad = usuario.Edad;


                usuarioEN.EsPremium = usuario.EsPremium;


                usuarioEN.Foto = usuario.Foto;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (usuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario.Id;
}

public void Modify (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Id);

                usuarioEN.Pass = usuario.Pass;


                usuarioEN.Email = usuario.Email;


                usuarioEN.Nickname = usuario.Nickname;


                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Apellidos = usuario.Apellidos;


                usuarioEN.Fecha_nacimiento = usuario.Fecha_nacimiento;


                usuarioEN.Orientacion_sexual = usuario.Orientacion_sexual;


                usuarioEN.Genero = usuario.Genero;


                usuarioEN.Fecha_registro = usuario.Fecha_registro;


                usuarioEN.Like_counter = usuario.Like_counter;


                usuarioEN.EsPremium = usuario.EsPremium;


                usuarioEN.Foto = usuario.Foto;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
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
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), id);
                session.Delete (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: UsuarioEN
public UsuarioEN ReadOID (int id
                          )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> FiltroDefecto (ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum? p_orientacion_sexual, ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum? p_genero, bool? p_premium, int first, int size)
{
        System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN  as usu WHERE usu.Orientacion_sexual = :p_orientacion_sexual and usu.Genero = :p_genero AND usu.EsPremium = :p_premium";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENfiltroDefectoHQL");
                query.SetParameter ("p_orientacion_sexual", p_orientacion_sexual);
                query.SetParameter ("p_genero", p_genero);
                query.SetParameter ("p_premium", p_premium);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> FiltroBusqueda (ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum? p_orientacion, ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum? p_genero, int? p_edad_min, int? p_edad_max, bool ? p_premium)
{
        System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN as usu WHERE (:p_orientacion is not null AND usu.Orientacion_sexual = :p_orientacion) OR (:p_genero is not null AND usu.Genero = :p_genero) OR ((:p_edad_min is not null AND :p_edad_max is not null) AND (usu.Edad >= :p_edad_min AND usu.Edad <= :p_edad_max)) AND usu.EsPremium = :p_premium";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENfiltroBusquedaHQL");
                query.SetParameter ("p_orientacion", p_orientacion);
                query.SetParameter ("p_genero", p_genero);
                query.SetParameter ("p_edad_min", p_edad_min);
                query.SetParameter ("p_edad_max", p_edad_max);
                query.SetParameter ("p_premium", p_premium);

                result = query.List<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AsignarPremium (int p_Usuario_OID, int p_premium_OID)
{
        ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                usuarioEN.Premium = (ProyectoGenNHibernate.EN.Proyecto.PremiumEN)session.Load (typeof(ProyectoGenNHibernate.EN.Proyecto.PremiumEN), p_premium_OID);

                usuarioEN.Premium.Usuario = usuarioEN;




                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesasignarPremium (int p_Usuario_OID, int p_premium_OID)
{
        try
        {
                SessionInitializeTransaction ();
                ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                if (usuarioEN.Premium.Id == p_premium_OID) {
                        usuarioEN.Premium = null;
                        ProyectoGenNHibernate.EN.Proyecto.PremiumEN premiumEN = (ProyectoGenNHibernate.EN.Proyecto.PremiumEN)session.Load (typeof(ProyectoGenNHibernate.EN.Proyecto.PremiumEN), p_premium_OID);
                        premiumEN.Usuario = null;
                }
                else
                        throw new ModelException ("The identifier " + p_premium_OID + " in p_premium_OID you are trying to unrelationer, doesn't exist in UsuarioEN");

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EditarPerfil2 (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Id);

                usuarioEN.Pass = usuario.Pass;


                usuarioEN.Nickname = usuario.Nickname;


                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Apellidos = usuario.Apellidos;


                usuarioEN.Fecha_nacimiento = usuario.Fecha_nacimiento;


                usuarioEN.Orientacion_sexual = usuario.Orientacion_sexual;


                usuarioEN.Genero = usuario.Genero;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DameUsuariosPremium ()
{
        System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN WHERE EsPremium = True";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuariosPremiumHQL");

                result = query.List<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DameUsuariosMatchReceptor (int p_id)
{
        System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where select usu FROM UsuarioEN as usu inner join usu.Match_receptor as matchRep where matchRep.Usuario_emisor.Id = :p_id AND matchRep.Estado = 2";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuariosMatchReceptorHQL");
                query.SetParameter ("p_id", p_id);

                result = query.List<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DameUsuariosMatchEmisor (int p_id)
{
        System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where select usu FROM UsuarioEN as usu inner join usu.Match_emisor as matchEm where matchEm.Usuario_receptor.Id = :p_id AND matchEm.Estado = 2";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuariosMatchEmisorHQL");
                query.SetParameter ("p_id", p_id);

                result = query.List<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DameUsuarioPorEmail (string p_email)
{
        System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN as usu where usu.Email = :p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorEmailHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DameUsuariosMatchPendiente (int p_id)
{
        System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where select usu FROM UsuarioEN as usu inner join usu.Match_emisor as matchEm where matchEm.Usuario_receptor.Id = :p_id AND matchEm.Estado = 1";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuariosMatchPendienteHQL");
                query.SetParameter ("p_id", p_id);

                result = query.List<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DameUsuariomatchPendienteEmisor (int p_id)
{
        System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where select usu FROM UsuarioEN as usu inner join usu.Match_receptor as matchEm where matchEm.Usuario_emisor.Id = :p_id AND (matchEm.Estado = 1 OR matchEm.Estado = 3)";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuariomatchPendienteEmisorHQL");
                query.SetParameter ("p_id", p_id);

                result = query.List<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DameUsuariosMatchRechazadoReceptor (int p_id)
{
        System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where select usu FROM UsuarioEN as usu inner join usu.Match_receptor as matchRep where matchRep.Usuario_emisor.Id = :p_id AND matchRep.Estado = 3";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuariosMatchRechazadoReceptorHQL");
                query.SetParameter ("p_id", p_id);

                result = query.List<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProyectoGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProyectoGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
