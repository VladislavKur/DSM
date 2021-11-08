

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProyectoGenNHibernate.Exceptions;

using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.CAD.Proyecto;


namespace ProyectoGenNHibernate.CEN.Proyecto
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public string Login (string p_Usuario_OID, string p_pass)
{
        string result = null;
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (p_Usuario_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Email);

        return result;
}

public void Modify (string p_Usuario_OID, String p_pass, string p_nickname, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento, ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum p_orientacion_sexual, ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum p_genero, Nullable<DateTime> p_fecha_registro, int p_like_counter, bool p_esPremium)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_Usuario_OID;
        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        usuarioEN.Nickname = p_nickname;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Apellidos = p_apellidos;
        usuarioEN.Fecha_nacimiento = p_fecha_nacimiento;
        usuarioEN.Orientacion_sexual = p_orientacion_sexual;
        usuarioEN.Genero = p_genero;
        usuarioEN.Fecha_registro = p_fecha_registro;
        usuarioEN.Like_counter = p_like_counter;
        usuarioEN.EsPremium = p_esPremium;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (string email
                     )
{
        _IUsuarioCAD.Destroy (email);
}

public UsuarioEN ReadOID (string email
                          )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.ReadOID (email);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> FiltroDefecto ()
{
        return _IUsuarioCAD.FiltroDefecto ();
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> FiltroBusqueda ()
{
        return _IUsuarioCAD.FiltroBusqueda ();
}
public void DesasignarPremium (string p_Usuario_OID, int p_premium_OID)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.DesasignarPremium (p_Usuario_OID, p_premium_OID);
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> FiltroMatch ()
{
        return _IUsuarioCAD.FiltroMatch ();
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DameUsuariosPremium ()
{
        return _IUsuarioCAD.DameUsuariosPremium ();
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DamePorOrientacion (ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum ? p_orientacion)
{
        return _IUsuarioCAD.DamePorOrientacion (p_orientacion);
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DamePorEdad (int? p_edad_min, int ? p_edad_max)
{
        return _IUsuarioCAD.DamePorEdad (p_edad_min, p_edad_max);
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DamePorGenero (ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum ? p_genero)
{
        return _IUsuarioCAD.DamePorGenero (p_genero);
}



private string Encode (string email)
{
        var payload = new Dictionary<string, object>(){
                { "email", email }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (string email)
{
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (email);
        string token = Encode (en.Email);

        return token;
}
public string CheckToken (string token)
{
        string result = null;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                string id = (string)ObtenerEMAIL (decodedToken);

                UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (id);

                if (en != null && ((string)en.Email).Equals (ObtenerEMAIL (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception e)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public string ObtenerEMAIL (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                string email = (string)results ["email"];
                return email;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
