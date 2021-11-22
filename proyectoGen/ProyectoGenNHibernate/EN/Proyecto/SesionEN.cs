
using System;
// Definición clase SesionEN
namespace ProyectoGenNHibernate.EN.Proyecto
{
public partial class SesionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo hora_inicio
 */
private Nullable<DateTime> hora_inicio;



/**
 *	Atributo hora_fin
 */
private Nullable<DateTime> hora_fin;



/**
 *	Atributo usuario
 */
private ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario;



/**
 *	Atributo usuario_0
 */
private ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_0;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.NotificacionEN> notificacion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Hora_inicio {
        get { return hora_inicio; } set { hora_inicio = value;  }
}



public virtual Nullable<DateTime> Hora_fin {
        get { return hora_fin; } set { hora_fin = value;  }
}



public virtual ProyectoGenNHibernate.EN.Proyecto.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual ProyectoGenNHibernate.EN.Proyecto.UsuarioEN Usuario_0 {
        get { return usuario_0; } set { usuario_0 = value;  }
}



public virtual System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}





public SesionEN()
{
        notificacion = new System.Collections.Generic.List<ProyectoGenNHibernate.EN.Proyecto.NotificacionEN>();
}



public SesionEN(int id, Nullable<DateTime> hora_inicio, Nullable<DateTime> hora_fin, ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario, ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_0, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.NotificacionEN> notificacion
                )
{
        this.init (Id, hora_inicio, hora_fin, usuario, usuario_0, notificacion);
}


public SesionEN(SesionEN sesion)
{
        this.init (Id, sesion.Hora_inicio, sesion.Hora_fin, sesion.Usuario, sesion.Usuario_0, sesion.Notificacion);
}

private void init (int id
                   , Nullable<DateTime> hora_inicio, Nullable<DateTime> hora_fin, ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario, ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_0, System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.NotificacionEN> notificacion)
{
        this.Id = id;


        this.Hora_inicio = hora_inicio;

        this.Hora_fin = hora_fin;

        this.Usuario = usuario;

        this.Usuario_0 = usuario_0;

        this.Notificacion = notificacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SesionEN t = obj as SesionEN;
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
