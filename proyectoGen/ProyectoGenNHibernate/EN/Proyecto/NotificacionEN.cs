
using System;
// Definición clase NotificacionEN
namespace ProyectoGenNHibernate.EN.Proyecto
{
public partial class NotificacionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo tipo
 */
private ProyectoGenNHibernate.Enumerated.Proyecto.TipoNotificacionEnum tipo;



/**
 *	Atributo contenido
 */
private string contenido;



/**
 *	Atributo id_tipo
 */
private string id_tipo;



/**
 *	Atributo sesion
 */
private ProyectoGenNHibernate.EN.Proyecto.SesionEN sesion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ProyectoGenNHibernate.Enumerated.Proyecto.TipoNotificacionEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual string Id_tipo {
        get { return id_tipo; } set { id_tipo = value;  }
}



public virtual ProyectoGenNHibernate.EN.Proyecto.SesionEN Sesion {
        get { return sesion; } set { sesion = value;  }
}





public NotificacionEN()
{
}



public NotificacionEN(int id, ProyectoGenNHibernate.Enumerated.Proyecto.TipoNotificacionEnum tipo, string contenido, string id_tipo, ProyectoGenNHibernate.EN.Proyecto.SesionEN sesion
                      )
{
        this.init (Id, tipo, contenido, id_tipo, sesion);
}


public NotificacionEN(NotificacionEN notificacion)
{
        this.init (Id, notificacion.Tipo, notificacion.Contenido, notificacion.Id_tipo, notificacion.Sesion);
}

private void init (int id
                   , ProyectoGenNHibernate.Enumerated.Proyecto.TipoNotificacionEnum tipo, string contenido, string id_tipo, ProyectoGenNHibernate.EN.Proyecto.SesionEN sesion)
{
        this.Id = id;


        this.Tipo = tipo;

        this.Contenido = contenido;

        this.Id_tipo = id_tipo;

        this.Sesion = sesion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionEN t = obj as NotificacionEN;
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
