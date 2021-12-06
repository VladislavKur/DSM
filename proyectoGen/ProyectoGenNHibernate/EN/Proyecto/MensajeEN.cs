
using System;
// Definición clase MensajeEN
namespace ProyectoGenNHibernate.EN.Proyecto
{
public partial class MensajeEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo contenido
 */
private string contenido;



/**
 *	Atributo estado
 */
private ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMensajeEnum estado;



/**
 *	Atributo usuario_receptor
 */
private ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_receptor;



/**
 *	Atributo usuario_emisor
 */
private ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_emisor;



/**
 *	Atributo horaEnvio
 */
private Nullable<DateTime> horaEnvio;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMensajeEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual ProyectoGenNHibernate.EN.Proyecto.UsuarioEN Usuario_receptor {
        get { return usuario_receptor; } set { usuario_receptor = value;  }
}



public virtual ProyectoGenNHibernate.EN.Proyecto.UsuarioEN Usuario_emisor {
        get { return usuario_emisor; } set { usuario_emisor = value;  }
}



public virtual Nullable<DateTime> HoraEnvio {
        get { return horaEnvio; } set { horaEnvio = value;  }
}





public MensajeEN()
{
}



public MensajeEN(int id, string contenido, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMensajeEnum estado, ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_receptor, ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_emisor, Nullable<DateTime> horaEnvio
                 )
{
        this.init (Id, contenido, estado, usuario_receptor, usuario_emisor, horaEnvio);
}


public MensajeEN(MensajeEN mensaje)
{
        this.init (Id, mensaje.Contenido, mensaje.Estado, mensaje.Usuario_receptor, mensaje.Usuario_emisor, mensaje.HoraEnvio);
}

private void init (int id
                   , string contenido, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMensajeEnum estado, ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_receptor, ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_emisor, Nullable<DateTime> horaEnvio)
{
        this.Id = id;


        this.Contenido = contenido;

        this.Estado = estado;

        this.Usuario_receptor = usuario_receptor;

        this.Usuario_emisor = usuario_emisor;

        this.HoraEnvio = horaEnvio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MensajeEN t = obj as MensajeEN;
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
