
using System;
// Definición clase UsuarioEN
namespace DSMGenNHibernate.EN.DSM
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
 *	Atributo nombre_Real
 */
private string nombre_Real;



/**
 *	Atributo apellido
 */
private string apellido;



/**
 *	Atributo fecha_de_nacimiento
 */
private Nullable<DateTime> fecha_de_nacimiento;



/**
 *	Atributo orientacion_sexual
 */
private string orientacion_sexual;



/**
 *	Atributo genero
 */
private bool genero;



/**
 *	Atributo nickname
 */
private string nickname;



/**
 *	Atributo fecha_de_registro
 */
private Nullable<DateTime> fecha_de_registro;



/**
 *	Atributo likecounter
 */
private int likecounter;



/**
 *	Atributo match_receptor
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MatchEN> match_receptor;



/**
 *	Atributo match_emisor
 */
private DSMGenNHibernate.EN.DSM.MatchEN match_emisor;



/**
 *	Atributo mensaje_receptor
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje_receptor;



/**
 *	Atributo mensaje_emisor
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje_emisor;



/**
 *	Atributo compra
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.CompraEN> compra;



/**
 *	Atributo sesion_activa
 */
private DSMGenNHibernate.EN.DSM.SesionEN sesion_activa;



/**
 *	Atributo sesion_terminada
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.SesionEN> sesion_terminada;






public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Nombre_Real {
        get { return nombre_Real; } set { nombre_Real = value;  }
}



public virtual string Apellido {
        get { return apellido; } set { apellido = value;  }
}



public virtual Nullable<DateTime> Fecha_de_nacimiento {
        get { return fecha_de_nacimiento; } set { fecha_de_nacimiento = value;  }
}



public virtual string Orientacion_sexual {
        get { return orientacion_sexual; } set { orientacion_sexual = value;  }
}



public virtual bool Genero {
        get { return genero; } set { genero = value;  }
}



public virtual string Nickname {
        get { return nickname; } set { nickname = value;  }
}



public virtual Nullable<DateTime> Fecha_de_registro {
        get { return fecha_de_registro; } set { fecha_de_registro = value;  }
}



public virtual int Likecounter {
        get { return likecounter; } set { likecounter = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MatchEN> Match_receptor {
        get { return match_receptor; } set { match_receptor = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.MatchEN Match_emisor {
        get { return match_emisor; } set { match_emisor = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> Mensaje_receptor {
        get { return mensaje_receptor; } set { mensaje_receptor = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> Mensaje_emisor {
        get { return mensaje_emisor; } set { mensaje_emisor = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.CompraEN> Compra {
        get { return compra; } set { compra = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.SesionEN Sesion_activa {
        get { return sesion_activa; } set { sesion_activa = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.SesionEN> Sesion_terminada {
        get { return sesion_terminada; } set { sesion_terminada = value;  }
}





public UsuarioEN()
{
        match_receptor = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.MatchEN>();
        mensaje_receptor = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.MensajeEN>();
        mensaje_emisor = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.MensajeEN>();
        compra = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.CompraEN>();
        sesion_terminada = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.SesionEN>();
}



public UsuarioEN(string email, String pass, string nombre_Real, string apellido, Nullable<DateTime> fecha_de_nacimiento, string orientacion_sexual, bool genero, string nickname, Nullable<DateTime> fecha_de_registro, int likecounter, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MatchEN> match_receptor, DSMGenNHibernate.EN.DSM.MatchEN match_emisor, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje_receptor, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje_emisor, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.CompraEN> compra, DSMGenNHibernate.EN.DSM.SesionEN sesion_activa, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.SesionEN> sesion_terminada
                 )
{
        this.init (Email, pass, nombre_Real, apellido, fecha_de_nacimiento, orientacion_sexual, genero, nickname, fecha_de_registro, likecounter, match_receptor, match_emisor, mensaje_receptor, mensaje_emisor, compra, sesion_activa, sesion_terminada);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Email, usuario.Pass, usuario.Nombre_Real, usuario.Apellido, usuario.Fecha_de_nacimiento, usuario.Orientacion_sexual, usuario.Genero, usuario.Nickname, usuario.Fecha_de_registro, usuario.Likecounter, usuario.Match_receptor, usuario.Match_emisor, usuario.Mensaje_receptor, usuario.Mensaje_emisor, usuario.Compra, usuario.Sesion_activa, usuario.Sesion_terminada);
}

private void init (string email
                   , String pass, string nombre_Real, string apellido, Nullable<DateTime> fecha_de_nacimiento, string orientacion_sexual, bool genero, string nickname, Nullable<DateTime> fecha_de_registro, int likecounter, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MatchEN> match_receptor, DSMGenNHibernate.EN.DSM.MatchEN match_emisor, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje_receptor, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.MensajeEN> mensaje_emisor, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.CompraEN> compra, DSMGenNHibernate.EN.DSM.SesionEN sesion_activa, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.SesionEN> sesion_terminada)
{
        this.Email = email;


        this.Pass = pass;

        this.Nombre_Real = nombre_Real;

        this.Apellido = apellido;

        this.Fecha_de_nacimiento = fecha_de_nacimiento;

        this.Orientacion_sexual = orientacion_sexual;

        this.Genero = genero;

        this.Nickname = nickname;

        this.Fecha_de_registro = fecha_de_registro;

        this.Likecounter = likecounter;

        this.Match_receptor = match_receptor;

        this.Match_emisor = match_emisor;

        this.Mensaje_receptor = mensaje_receptor;

        this.Mensaje_emisor = mensaje_emisor;

        this.Compra = compra;

        this.Sesion_activa = sesion_activa;

        this.Sesion_terminada = sesion_terminada;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
