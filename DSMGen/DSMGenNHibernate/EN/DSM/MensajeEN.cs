
using System;
// Definición clase MensajeEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class MensajeEN
{
/**
 *	Atributo idMensaje
 */
private int idMensaje;



/**
 *	Atributo usuario_emisor
 */
private DSMGenNHibernate.EN.DSM.UsuarioEN usuario_emisor;



/**
 *	Atributo usuario_receptor
 */
private DSMGenNHibernate.EN.DSM.UsuarioEN usuario_receptor;



/**
 *	Atributo contenido
 */
private string contenido;



/**
 *	Atributo estadoMensaje
 */
private DSMGenNHibernate.Enumerated.DSM.EstadoMensajeEnum estadoMensaje;






public virtual int IdMensaje {
        get { return idMensaje; } set { idMensaje = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.UsuarioEN Usuario_emisor {
        get { return usuario_emisor; } set { usuario_emisor = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.UsuarioEN Usuario_receptor {
        get { return usuario_receptor; } set { usuario_receptor = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual DSMGenNHibernate.Enumerated.DSM.EstadoMensajeEnum EstadoMensaje {
        get { return estadoMensaje; } set { estadoMensaje = value;  }
}





public MensajeEN()
{
}



public MensajeEN(int idMensaje, DSMGenNHibernate.EN.DSM.UsuarioEN usuario_emisor, DSMGenNHibernate.EN.DSM.UsuarioEN usuario_receptor, string contenido, DSMGenNHibernate.Enumerated.DSM.EstadoMensajeEnum estadoMensaje
                 )
{
        this.init (IdMensaje, usuario_emisor, usuario_receptor, contenido, estadoMensaje);
}


public MensajeEN(MensajeEN mensaje)
{
        this.init (IdMensaje, mensaje.Usuario_emisor, mensaje.Usuario_receptor, mensaje.Contenido, mensaje.EstadoMensaje);
}

private void init (int idMensaje
                   , DSMGenNHibernate.EN.DSM.UsuarioEN usuario_emisor, DSMGenNHibernate.EN.DSM.UsuarioEN usuario_receptor, string contenido, DSMGenNHibernate.Enumerated.DSM.EstadoMensajeEnum estadoMensaje)
{
        this.IdMensaje = idMensaje;


        this.Usuario_emisor = usuario_emisor;

        this.Usuario_receptor = usuario_receptor;

        this.Contenido = contenido;

        this.EstadoMensaje = estadoMensaje;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MensajeEN t = obj as MensajeEN;
        if (t == null)
                return false;
        if (IdMensaje.Equals (t.IdMensaje))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdMensaje.GetHashCode ();
        return hash;
}
}
}
