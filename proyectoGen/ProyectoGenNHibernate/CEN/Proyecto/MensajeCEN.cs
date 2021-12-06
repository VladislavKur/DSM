

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

public void Modify (int p_Mensaje_OID, string p_contenido, ProyectoGenNHibernate.Enumerated.Proyecto.EstadoMensajeEnum p_estado, Nullable<DateTime> p_horaEnvio)
{
        MensajeEN mensajeEN = null;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Id = p_Mensaje_OID;
        mensajeEN.Contenido = p_contenido;
        mensajeEN.Estado = p_estado;
        mensajeEN.HoraEnvio = p_horaEnvio;
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
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> DameMensajesEmisor (int p_id)
{
        return _IMensajeCAD.DameMensajesEmisor (p_id);
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> DameMensajesReceptor (int p_id)
{
        return _IMensajeCAD.DameMensajesReceptor (p_id);
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> DameMensajes (int p_idUsuario)
{
        return _IMensajeCAD.DameMensajes (p_idUsuario);
}
public System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> DameMensajesEntreEstos2 (int p_idUsuario, int p_idUsuarioReceptor)
{
        return _IMensajeCAD.DameMensajesEntreEstos2 (p_idUsuario, p_idUsuarioReceptor);
}
}
}
