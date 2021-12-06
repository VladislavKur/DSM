
using System;
// Definición clase UsuarioEN
namespace ProyectoGenNHibernate.EN.Proyecto
{
public partial class UsuarioEN
{
/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo nickname
 */
private string nickname;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo fecha_nacimiento
 */
private Nullable<DateTime> fecha_nacimiento;



/**
 *	Atributo orientacion_sexual
 */
private ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum orientacion_sexual;



/**
 *	Atributo genero
 */
private ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum genero;



/**
 *	Atributo fecha_registro
 */
private Nullable<DateTime> fecha_registro;



/**
 *	Atributo like_counter
 */
private int like_counter;



/**
 *	Atributo match_emisor
 */
private System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MatchEN> match_emisor;



/**
 *	Atributo match_receptor
 */
private System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MatchEN> match_receptor;



/**
 *	Atributo mensaje_receptor
 */
private System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> mensaje_receptor;



/**
 *	Atributo mensaje_emisor
 */
private System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> mensaje_emisor;



/**
 *	Atributo premium
 */
private ProyectoGenNHibernate.EN.Proyecto.PremiumEN premium;



/**
 *	Atributo sesion_activa
 */
private ProyectoGenNHibernate.EN.Proyecto.SesionEN sesion_activa;



/**
 *	Atributo sesion_terminada
 */
private System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.SesionEN> sesion_terminada;



/**
 *	Atributo edad
 */
private int edad;



/**
 *	Atributo esPremium
 */
private bool esPremium;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo foto
 */
private string foto;






public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Nickname {
        get { return nickname; } set { nickname = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual Nullable<DateTime> Fecha_nacimiento {
        get { return fecha_nacimiento; } set { fecha_nacimiento = value;  }
}



public virtual ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum Orientacion_sexual {
        get { return orientacion_sexual; } set { orientacion_sexual = value;  }
}



public virtual ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum Genero {
        get { return genero; } set { genero = value;  }
}



public virtual Nullable<DateTime> Fecha_registro {
        get { return fecha_registro; } set { fecha_registro = value;  }
}



public virtual int Like_counter {
        get { return like_counter; } set { like_counter = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MatchEN> Match_emisor {
        get { return match_emisor; } set { match_emisor = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MatchEN> Match_receptor {
        get { return match_receptor; } set { match_receptor = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> Mensaje_receptor {
        get { return mensaje_receptor; } set { mensaje_receptor = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> Mensaje_emisor {
        get { return mensaje_emisor; } set { mensaje_emisor = value;  }
}



public virtual ProyectoGenNHibernate.EN.Proyecto.PremiumEN Premium {
        get { return premium; } set { premium = value;  }
}



public virtual ProyectoGenNHibernate.EN.Proyecto.SesionEN Sesion_activa {
        get { return sesion_activa; } set { sesion_activa = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.SesionEN> Sesion_terminada {
        get { return sesion_terminada; } set { sesion_terminada = value;  }
}



public virtual int Edad {
        get { return edad; } set { edad = value;  }
}



public virtual bool EsPremium {
        get { return esPremium; } set { esPremium = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}





public UsuarioEN()
{
        match_emisor = new System.Collections.Generic.List<ProyectoGenNHibernate.EN.Proyecto.MatchEN>();
        match_receptor = new System.Collections.Generic.List<ProyectoGenNHibernate.EN.Proyecto.MatchEN>();
        mensaje_receptor = new System.Collections.Generic.List<ProyectoGenNHibernate.EN.Proyecto.MensajeEN>();
        mensaje_emisor = new System.Collections.Generic.List<ProyectoGenNHibernate.EN.Proyecto.MensajeEN>();
        sesion_terminada = new System.Collections.Generic.List<ProyectoGenNHibernate.EN.Proyecto.SesionEN>();
}



public UsuarioEN(int id, String pass, string email, string nickname, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento, ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum orientacion_sexual, ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum genero, Nullable<DateTime> fecha_registro, int like_counter, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MatchEN> match_emisor, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MatchEN> match_receptor, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> mensaje_receptor, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> mensaje_emisor, ProyectoGenNHibernate.EN.Proyecto.PremiumEN premium, ProyectoGenNHibernate.EN.Proyecto.SesionEN sesion_activa, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.SesionEN> sesion_terminada, int edad, bool esPremium, string foto
                 )
{
        this.init (Id, pass, email, nickname, nombre, apellidos, fecha_nacimiento, orientacion_sexual, genero, fecha_registro, like_counter, match_emisor, match_receptor, mensaje_receptor, mensaje_emisor, premium, sesion_activa, sesion_terminada, edad, esPremium, foto);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Id, usuario.Pass, usuario.Email, usuario.Nickname, usuario.Nombre, usuario.Apellidos, usuario.Fecha_nacimiento, usuario.Orientacion_sexual, usuario.Genero, usuario.Fecha_registro, usuario.Like_counter, usuario.Match_emisor, usuario.Match_receptor, usuario.Mensaje_receptor, usuario.Mensaje_emisor, usuario.Premium, usuario.Sesion_activa, usuario.Sesion_terminada, usuario.Edad, usuario.EsPremium, usuario.Foto);
}

private void init (int id
                   , String pass, string email, string nickname, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento, ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum orientacion_sexual, ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum genero, Nullable<DateTime> fecha_registro, int like_counter, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MatchEN> match_emisor, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MatchEN> match_receptor, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> mensaje_receptor, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> mensaje_emisor, ProyectoGenNHibernate.EN.Proyecto.PremiumEN premium, ProyectoGenNHibernate.EN.Proyecto.SesionEN sesion_activa, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.SesionEN> sesion_terminada, int edad, bool esPremium, string foto)
{
        this.Id = id;


        this.Pass = pass;

        this.Email = email;

        this.Nickname = nickname;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Fecha_nacimiento = fecha_nacimiento;

        this.Orientacion_sexual = orientacion_sexual;

        this.Genero = genero;

        this.Fecha_registro = fecha_registro;

        this.Like_counter = like_counter;

        this.Match_emisor = match_emisor;

        this.Match_receptor = match_receptor;

        this.Mensaje_receptor = mensaje_receptor;

        this.Mensaje_emisor = mensaje_emisor;

        this.Premium = premium;

        this.Sesion_activa = sesion_activa;

        this.Sesion_terminada = sesion_terminada;

        this.Edad = edad;

        this.EsPremium = esPremium;

        this.Foto = foto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
