
using System;
// Definición clase NotificacionesEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class NotificacionesEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo sessionInicio
 */
private System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.SesionEN> sessionInicio;



/**
 *	Atributo tipoNotificacion
 */
private DSMGenNHibernate.Enumerated.DSM.TipoNotificacionEnum tipoNotificacion;



/**
 *	Atributo contenido
 */
private string contenido;



/**
 *	Atributo id_tipo
 */
private int id_tipo;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.SesionEN> SessionInicio {
        get { return sessionInicio; } set { sessionInicio = value;  }
}



public virtual DSMGenNHibernate.Enumerated.DSM.TipoNotificacionEnum TipoNotificacion {
        get { return tipoNotificacion; } set { tipoNotificacion = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual int Id_tipo {
        get { return id_tipo; } set { id_tipo = value;  }
}





public NotificacionesEN()
{
        sessionInicio = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.SesionEN>();
}



public NotificacionesEN(int id, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.SesionEN> sessionInicio, DSMGenNHibernate.Enumerated.DSM.TipoNotificacionEnum tipoNotificacion, string contenido, int id_tipo
                        )
{
        this.init (Id, sessionInicio, tipoNotificacion, contenido, id_tipo);
}


public NotificacionesEN(NotificacionesEN notificaciones)
{
        this.init (Id, notificaciones.SessionInicio, notificaciones.TipoNotificacion, notificaciones.Contenido, notificaciones.Id_tipo);
}

private void init (int id
                   , System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.SesionEN> sessionInicio, DSMGenNHibernate.Enumerated.DSM.TipoNotificacionEnum tipoNotificacion, string contenido, int id_tipo)
{
        this.Id = id;


        this.SessionInicio = sessionInicio;

        this.TipoNotificacion = tipoNotificacion;

        this.Contenido = contenido;

        this.Id_tipo = id_tipo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionesEN t = obj as NotificacionesEN;
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
