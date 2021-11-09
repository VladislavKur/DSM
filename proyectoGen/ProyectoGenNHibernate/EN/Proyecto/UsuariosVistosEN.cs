
using System;
// Definición clase UsuariosVistosEN
namespace ProyectoGenNHibernate.EN.Proyecto
{
public partial class UsuariosVistosEN
{
/**
 *	Atributo id
 */
private int id;






public virtual int Id {
        get { return id; } set { id = value;  }
}





public UsuariosVistosEN()
{
}



public UsuariosVistosEN(int id
                        )
{
        this.init (Id);
}


public UsuariosVistosEN(UsuariosVistosEN usuariosVistos)
{
        this.init (Id);
}

private void init (int id
                   )
{
        this.Id = id;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuariosVistosEN t = obj as UsuariosVistosEN;
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
