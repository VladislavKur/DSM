

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGenNHibernate.Exceptions;

using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.CAD.DSM;


namespace DSMGenNHibernate.CEN.DSM
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

public int New_ (string p_usuario_emisor, string p_usuario_receptor, string p_contenido, DSMGenNHibernate.Enumerated.DSM.EstadoMensajeEnum p_estadoMensaje)
{
        MensajeEN mensajeEN = null;
        int oid;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();

        if (p_usuario_emisor != null) {
                // El argumento p_usuario_emisor -> Property usuario_emisor es oid = false
                // Lista de oids idMensaje
                mensajeEN.Usuario_emisor = new DSMGenNHibernate.EN.DSM.UsuarioEN ();
                mensajeEN.Usuario_emisor.Email = p_usuario_emisor;
        }


        if (p_usuario_receptor != null) {
                // El argumento p_usuario_receptor -> Property usuario_receptor es oid = false
                // Lista de oids idMensaje
                mensajeEN.Usuario_receptor = new DSMGenNHibernate.EN.DSM.UsuarioEN ();
                mensajeEN.Usuario_receptor.Email = p_usuario_receptor;
        }

        mensajeEN.Contenido = p_contenido;

        mensajeEN.EstadoMensaje = p_estadoMensaje;

        //Call to MensajeCAD

        oid = _IMensajeCAD.New_ (mensajeEN);
        return oid;
}

public void Modify (int p_Mensaje_OID, string p_contenido, DSMGenNHibernate.Enumerated.DSM.EstadoMensajeEnum p_estadoMensaje)
{
        MensajeEN mensajeEN = null;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.IdMensaje = p_Mensaje_OID;
        mensajeEN.Contenido = p_contenido;
        mensajeEN.EstadoMensaje = p_estadoMensaje;
        //Call to MensajeCAD

        _IMensajeCAD.Modify (mensajeEN);
}

public void Destroy (int idMensaje
                     )
{
        _IMensajeCAD.Destroy (idMensaje);
}

public MensajeEN ReadOID (int idMensaje
                          )
{
        MensajeEN mensajeEN = null;

        mensajeEN = _IMensajeCAD.ReadOID (idMensaje);
        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> list = null;

        list = _IMensajeCAD.ReadAll (first, size);
        return list;
}
}
}
