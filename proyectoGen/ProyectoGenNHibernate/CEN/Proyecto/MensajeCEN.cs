

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProyectoGenNHibernate.Exceptions;

using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.CAD.Proyecto;


namespace ProyectoGenNHibernate.CEN.Proyecto
{
/*
 *      Definition of the class MensajeCEN
 *
 */
public partial class MensajeCEN
{
private IMensajeCAD _IMensajeCAD;

public MensajeCEN()
{
        this._IMensajeCAD = new MensajeCAD ();
}

public MensajeCEN(IMensajeCAD _IMensajeCAD)
{
        this._IMensajeCAD = _IMensajeCAD;
}

public IMensajeCAD get_IMensajeCAD ()
{
        return this._IMensajeCAD;
}

public void Modify (int p_Mensaje_OID, string p_contenido, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMensajeEnum p_estado)
{
        MensajeEN mensajeEN = null;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Id = p_Mensaje_OID;
        mensajeEN.Contenido = p_contenido;
        mensajeEN.Estado = p_estado;
        //Call to MensajeCAD

        _IMensajeCAD.Modify (mensajeEN);
}

public void Destroy (int id
                     )
{
        _IMensajeCAD.Destroy (id);
}

public MensajeEN ReadOID (int id
                          )
{
        MensajeEN mensajeEN = null;

        mensajeEN = _IMensajeCAD.ReadOID (id);
        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> list = null;

        list = _IMensajeCAD.ReadAll (first, size);
        return list;
}
public int New_ (string p_contenido, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMensajeEnum p_estado, int p_usuario_emisor, int p_usuario_receptor)
{
        MensajeEN mensajeEN = null;
        int oid;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Contenido = p_contenido;

        mensajeEN.Estado = p_estado;


        if (p_usuario_emisor != -1) {
                // El argumento p_usuario_emisor -> Property usuario_emisor es oid = false
                // Lista de oids id
                mensajeEN.Usuario_emisor = new ProyectoGenNHibernate.EN.Proyecto.UsuarioEN ();
                mensajeEN.Usuario_emisor.Id = p_usuario_emisor;
        }


        if (p_usuario_receptor != -1) {
                // El argumento p_usuario_receptor -> Property usuario_receptor es oid = false
                // Lista de oids id
                mensajeEN.Usuario_receptor = new ProyectoGenNHibernate.EN.Proyecto.UsuarioEN ();
                mensajeEN.Usuario_receptor.Id = p_usuario_receptor;
        }

        //Call to MensajeCAD

        oid = _IMensajeCAD.New_ (mensajeEN);
        return oid;
}
}
}
