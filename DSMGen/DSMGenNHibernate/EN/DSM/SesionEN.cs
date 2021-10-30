
using System;
// Definición clase SesionEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class SesionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> usuario;



/**
 *	Atributo notificaciones
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.NotificacionesEN> notificaciones;



/**
 *	Atributo hora_inicio
 */
private Nullable<DateTime> hora_inicio;



/**
 *	Atributo hora_fin
 */
private Nullable<DateTime> hora_fin;



/**
 *	Atributo usuario_0
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> usuario_0;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.NotificacionesEN> Notificaciones {
        get { return notificaciones; } set { notificaciones = value;  }
}



public virtual Nullable<DateTime> Hora_inicio {
        get { return hora_inicio; } set { hora_inicio = value;  }
}



public virtual Nullable<DateTime> Hora_fin {
        get { return hora_fin; } set { hora_fin = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> Usuario_0 {
        get { return usuario_0; } set { usuario_0 = value;  }
}





public SesionEN()
{
        usuario = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.UsuarioEN>();
        notificaciones = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.NotificacionesEN>();
        usuario_0 = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.UsuarioEN>();
}



public SesionEN(int id, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> usuario, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.NotificacionesEN> notificaciones, Nullable<DateTime> hora_inicio, Nullable<DateTime> hora_fin, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> usuario_0
                )
{
        this.init (Id, usuario, notificaciones, hora_inicio, hora_fin, usuario_0);
}


public SesionEN(SesionEN sesion)
{
        this.init (Id, sesion.Usuario, sesion.Notificaciones, sesion.Hora_inicio, sesion.Hora_fin, sesion.Usuario_0);
}

private void init (int id
                   , System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> usuario, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.NotificacionesEN> notificaciones, Nullable<DateTime> hora_inicio, Nullable<DateTime> hora_fin, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> usuario_0)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Notificaciones = notificaciones;

        this.Hora_inicio = hora_inicio;

        this.Hora_fin = hora_fin;

        this.Usuario_0 = usuario_0;
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
