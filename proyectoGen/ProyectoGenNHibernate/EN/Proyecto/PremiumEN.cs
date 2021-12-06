
using System;
// Definición clase PremiumEN
namespace ProyectoGenNHibernate.EN.Proyecto
{
public partial class PremiumEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo estadoCompra
 */
private ProyectoGenNHibernate.Enumerated.Proyecto.EstadoCompraEnum estadoCompra;



/**
 *	Atributo fecha_compra
 */
private Nullable<DateTime> fecha_compra;



/**
 *	Atributo fecha_caduca
 */
private Nullable<DateTime> fecha_caduca;



/**
 *	Atributo usuario
 */
private ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual ProyectoGenNHibernate.Enumerated.Proyecto.EstadoCompraEnum EstadoCompra {
        get { return estadoCompra; } set { estadoCompra = value;  }
}



public virtual Nullable<DateTime> Fecha_compra {
        get { return fecha_compra; } set { fecha_compra = value;  }
}



public virtual Nullable<DateTime> Fecha_caduca {
        get { return fecha_caduca; } set { fecha_caduca = value;  }
}



public virtual ProyectoGenNHibernate.EN.Proyecto.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public PremiumEN()
{
}



public PremiumEN(int id, double precio, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoCompraEnum estadoCompra, Nullable<DateTime> fecha_compra, Nullable<DateTime> fecha_caduca, ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario
                 )
{
        this.init (Id, precio, estadoCompra, fecha_compra, fecha_caduca, usuario);
}


public PremiumEN(PremiumEN premium)
{
        this.init (Id, premium.Precio, premium.EstadoCompra, premium.Fecha_compra, premium.Fecha_caduca, premium.Usuario);
}

private void init (int id
                   , double precio, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoCompraEnum estadoCompra, Nullable<DateTime> fecha_compra, Nullable<DateTime> fecha_caduca, ProyectoGenNHibernate.EN.Proyecto.UsuarioEN usuario)
{
        this.Id = id;


        this.Precio = precio;

        this.EstadoCompra = estadoCompra;

        this.Fecha_compra = fecha_compra;

        this.Fecha_caduca = fecha_caduca;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PremiumEN t = obj as PremiumEN;
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
