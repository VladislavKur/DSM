

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
 *      Definition of the class UsuarioVIPCEN
 *
 */
public partial class UsuarioVIPCEN
{
private IUsuarioVIPCAD _IUsuarioVIPCAD;

public UsuarioVIPCEN()
{
        this._IUsuarioVIPCAD = new UsuarioVIPCAD ();
}

public UsuarioVIPCEN(IUsuarioVIPCAD _IUsuarioVIPCAD)
{
        this._IUsuarioVIPCAD = _IUsuarioVIPCAD;
}

public IUsuarioVIPCAD get_IUsuarioVIPCAD ()
{
        return this._IUsuarioVIPCAD;
}

public string New_ (String p_pass, string p_email, string p_nickname, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento, ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum p_orientacion_sexual, ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum p_genero, Nullable<DateTime> p_fecha_registro, int p_like_counter, bool p_esPremium, int p_numSocio)
{
        UsuarioVIPEN usuarioVIPEN = null;
        string oid;

        //Initialized UsuarioVIPEN
        usuarioVIPEN = new UsuarioVIPEN ();
        usuarioVIPEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        usuarioVIPEN.Email = p_email;

        usuarioVIPEN.Nickname = p_nickname;

        usuarioVIPEN.Nombre = p_nombre;

        usuarioVIPEN.Apellidos = p_apellidos;

        usuarioVIPEN.Fecha_nacimiento = p_fecha_nacimiento;

        usuarioVIPEN.Orientacion_sexual = p_orientacion_sexual;

        usuarioVIPEN.Genero = p_genero;

        usuarioVIPEN.Fecha_registro = p_fecha_registro;

        usuarioVIPEN.Like_counter = p_like_counter;

        usuarioVIPEN.EsPremium = p_esPremium;

        usuarioVIPEN.NumSocio = p_numSocio;

        //Call to UsuarioVIPCAD

        oid = _IUsuarioVIPCAD.New_ (usuarioVIPEN);
        return oid;
}

public void Modify (string p_UsuarioVIP_OID, String p_pass, string p_nickname, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento, ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum p_orientacion_sexual, ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum p_genero, Nullable<DateTime> p_fecha_registro, int p_like_counter, bool p_esPremium, int p_numSocio)
{
        UsuarioVIPEN usuarioVIPEN = null;

        //Initialized UsuarioVIPEN
        usuarioVIPEN = new UsuarioVIPEN ();
        usuarioVIPEN.Email = p_UsuarioVIP_OID;
        usuarioVIPEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        usuarioVIPEN.Nickname = p_nickname;
        usuarioVIPEN.Nombre = p_nombre;
        usuarioVIPEN.Apellidos = p_apellidos;
        usuarioVIPEN.Fecha_nacimiento = p_fecha_nacimiento;
        usuarioVIPEN.Orientacion_sexual = p_orientacion_sexual;
        usuarioVIPEN.Genero = p_genero;
        usuarioVIPEN.Fecha_registro = p_fecha_registro;
        usuarioVIPEN.Like_counter = p_like_counter;
        usuarioVIPEN.EsPremium = p_esPremium;
        usuarioVIPEN.NumSocio = p_numSocio;
        //Call to UsuarioVIPCAD

        _IUsuarioVIPCAD.Modify (usuarioVIPEN);
}

public void Destroy (string email
                     )
{
        _IUsuarioVIPCAD.Destroy (email);
}

public UsuarioVIPEN ReadOID (string email
                             )
{
        UsuarioVIPEN usuarioVIPEN = null;

        usuarioVIPEN = _IUsuarioVIPCAD.ReadOID (email);
        return usuarioVIPEN;
}

public System.Collections.Generic.IList<UsuarioVIPEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioVIPEN> list = null;

        list = _IUsuarioVIPCAD.ReadAll (first, size);
        return list;
}
}
}
