
using System;
// Definición clase UsuarioVIPEN
namespace ProyectoGenNHibernate.EN.Proyecto
{
public partial class UsuarioVIPEN                                                                   : ProyectoGenNHibernate.EN.Proyecto.UsuarioEN


{
/**
 *	Atributo numSocio
 */
private int numSocio;






public virtual int NumSocio {
        get { return numSocio; } set { numSocio = value;  }
}





public UsuarioVIPEN() : base ()
{
}



public UsuarioVIPEN(string email, int numSocio
                    , String pass, string nickname, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento, ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum orientacion_sexual, ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum genero, Nullable<DateTime> fecha_registro, int like_counter, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MatchEN> match_receptor, ProyectoGenNHibernate.EN.Proyecto.MatchEN match_emisor, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> mensaje_receptor, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> mensaje_emisor, ProyectoGenNHibernate.EN.Proyecto.PremiumEN premium, ProyectoGenNHibernate.EN.Proyecto.SesionEN sesion_activa, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.SesionEN> sesion_terminada, int edad, bool esPremium
                    )
{
        this.init (Email, numSocio, pass, nickname, nombre, apellidos, fecha_nacimiento, orientacion_sexual, genero, fecha_registro, like_counter, match_receptor, match_emisor, mensaje_receptor, mensaje_emisor, premium, sesion_activa, sesion_terminada, edad, esPremium);
}


public UsuarioVIPEN(UsuarioVIPEN usuarioVIP)
{
        this.init (Email, usuarioVIP.NumSocio, usuarioVIP.Pass, usuarioVIP.Nickname, usuarioVIP.Nombre, usuarioVIP.Apellidos, usuarioVIP.Fecha_nacimiento, usuarioVIP.Orientacion_sexual, usuarioVIP.Genero, usuarioVIP.Fecha_registro, usuarioVIP.Like_counter, usuarioVIP.Match_receptor, usuarioVIP.Match_emisor, usuarioVIP.Mensaje_receptor, usuarioVIP.Mensaje_emisor, usuarioVIP.Premium, usuarioVIP.Sesion_activa, usuarioVIP.Sesion_terminada, usuarioVIP.Edad, usuarioVIP.EsPremium);
}

private void init (string email
                   , int numSocio, String pass, string nickname, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento, ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum orientacion_sexual, ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum genero, Nullable<DateTime> fecha_registro, int like_counter, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MatchEN> match_receptor, ProyectoGenNHibernate.EN.Proyecto.MatchEN match_emisor, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> mensaje_receptor, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> mensaje_emisor, ProyectoGenNHibernate.EN.Proyecto.PremiumEN premium, ProyectoGenNHibernate.EN.Proyecto.SesionEN sesion_activa, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.SesionEN> sesion_terminada, int edad, bool esPremium)
{
        this.Email = email;


        this.NumSocio = numSocio;

        this.Pass = pass;

        this.Nickname = nickname;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Fecha_nacimiento = fecha_nacimiento;

        this.Orientacion_sexual = orientacion_sexual;

        this.Genero = genero;

        this.Fecha_registro = fecha_registro;

        this.Like_counter = like_counter;

        this.Match_receptor = match_receptor;

        this.Match_emisor = match_emisor;

        this.Mensaje_receptor = mensaje_receptor;

        this.Mensaje_emisor = mensaje_emisor;

        this.Premium = premium;

        this.Sesion_activa = sesion_activa;

        this.Sesion_terminada = sesion_terminada;

        this.Edad = edad;

        this.EsPremium = esPremium;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioVIPEN t = obj as UsuarioVIPEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
