
using System;
// Definición clase MatchEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class MatchEN
{
/**
 *	Atributo estado
 */
private DSMGenNHibernate.Enumerated.DSM.EstadoMatchEnum estado;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario_emisor
 */
private DSMGenNHibernate.EN.DSM.UsuarioEN usuario_emisor;



/**
 *	Atributo usuario_receptor
 */
private DSMGenNHibernate.EN.DSM.UsuarioEN usuario_receptor;






public virtual DSMGenNHibernate.Enumerated.DSM.EstadoMatchEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.UsuarioEN Usuario_emisor {
        get { return usuario_emisor; } set { usuario_emisor = value;  }
}



public virtual DSMGenNHibernate.EN.DSM.UsuarioEN Usuario_receptor {
        get { return usuario_receptor; } set { usuario_receptor = value;  }
}





public MatchEN()
{
}



public MatchEN(int id, DSMGenNHibernate.Enumerated.DSM.EstadoMatchEnum estado, DSMGenNHibernate.EN.DSM.UsuarioEN usuario_emisor, DSMGenNHibernate.EN.DSM.UsuarioEN usuario_receptor
               )
{
        this.init (Id, estado, usuario_emisor, usuario_receptor);
}


public MatchEN(MatchEN match)
{
        this.init (Id, match.Estado, match.Usuario_emisor, match.Usuario_receptor);
}

private void init (int id
                   , DSMGenNHibernate.Enumerated.DSM.EstadoMatchEnum estado, DSMGenNHibernate.EN.DSM.UsuarioEN usuario_emisor, DSMGenNHibernate.EN.DSM.UsuarioEN usuario_receptor)
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
