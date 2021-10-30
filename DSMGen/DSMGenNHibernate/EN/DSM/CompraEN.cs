
using System;
// Definición clase CompraEN
namespace DSMGenNHibernate.EN.DSM
{
public partial class CompraEN
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
 *	Atributo precio
 */
private int precio;



/**
 *	Atributo estadoCompra
 */
private DSMGenNHibernate.Enumerated.DSM.EstadoCompraEnum estadoCompra;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual int Precio {
        get { return precio; } set { precio = value;  }
}



public virtual DSMGenNHibernate.Enumerated.DSM.EstadoCompraEnum EstadoCompra {
        get { return estadoCompra; } set { estadoCompra = value;  }
}





public CompraEN()
{
        usuario = new System.Collections.Generic.List<DSMGenNHibernate.EN.DSM.UsuarioEN>();
}



public CompraEN(int id, System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> usuario, int precio, DSMGenNHibernate.Enumerated.DSM.EstadoCompraEnum estadoCompra
                )
{
        this.init (Id, usuario, precio, estadoCompra);
}


public CompraEN(CompraEN compra)
{
        this.init (Id, compra.Usuario, compra.Precio, compra.EstadoCompra);
}

private void init (int id
                   , System.Collections.Generic.IList<DSMGenNHibernate.EN.DSM.UsuarioEN> usuario, int precio, DSMGenNHibernate.Enumerated.DSM.EstadoCompraEnum estadoCompra)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Precio = precio;

        this.EstadoCompra = estadoCompra;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CompraEN t = obj as CompraEN;
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
