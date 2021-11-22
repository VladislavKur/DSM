
using System;
// Definición clase MatchEN
namespace ProyectoGenNHibernate.EN.Proyecto
{
public partial class MatchEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo estado
 */
private ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMatchEnum estado;



/**
 *	Atributo usuario_emisor
 */
private ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_emisor;



/**
 *	Atributo usuario_receptor
 */
private ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_receptor;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMatchEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual ProyectoGenNHibernate.EN.Proyecto.UsuarioEN Usuario_emisor {
        get { return usuario_emisor; } set { usuario_emisor = value;  }
}



public virtual ProyectoGenNHibernate.EN.Proyecto.UsuarioEN Usuario_receptor {
        get { return usuario_receptor; } set { usuario_receptor = value;  }
}





public MatchEN()
{
}



public MatchEN(int id, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMatchEnum estado, ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_emisor, ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_receptor
               )
{
        this.init (Id, estado, usuario_emisor, usuario_receptor);
}


public MatchEN(MatchEN match)
{
        this.init (Id, match.Estado, match.Usuario_emisor, match.Usuario_receptor);
}

private void init (int id
                   , ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMatchEnum estado, ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_emisor, ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario_receptor)
{
        this.Id = id;


        this.Estado = estado;

        this.Usuario_emisor = usuario_emisor;

        this.Usuario_receptor = usuario_receptor;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MatchEN t = obj as MatchEN;
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
