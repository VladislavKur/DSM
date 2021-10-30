

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
 *      Definition of the class NotificacionesCEN
 *
 */
public partial class NotificacionesCEN
{
private INotificacionesCAD _INotificacionesCAD;

public NotificacionesCEN()
{
        this._INotificacionesCAD = new NotificacionesCAD ();
}

public NotificacionesCEN(INotificacionesCAD _INotificacionesCAD)
{
        this._INotificacionesCAD = _INotificacionesCAD;
}

public INotificacionesCAD get_INotificacionesCAD ()
{
        return this._INotificacionesCAD;
}

public int New_ (DSMGenNHibernate.Enumerated.DSM.TipoNotificacionEnum p_tipoNotificacion, string p_contenido, int p_id_tipo)
{
        NotificacionesEN notificacionesEN = null;
        int oid;

        //Initialized NotificacionesEN
        notificacionesEN = new NotificacionesEN ();
        notificacionesEN.TipoNotificacion = p_tipoNotificacion;

        notificacionesEN.Contenido = p_contenido;

        notificacionesEN.Id_tipo = p_id_tipo;

        //Call to NotificacionesCAD

        oid = _INotificacionesCAD.New_ (notificacionesEN);
        return oid;
}

public void Modify (int p_Notificaciones_OID, DSMGenNHibernate.Enumerated.DSM.TipoNotificacionEnum p_tipoNotificacion, string p_contenido, int p_id_tipo)
{
        NotificacionesEN notificacionesEN = null;

        //Initialized NotificacionesEN
        notificacionesEN = new NotificacionesEN ();
        notificacionesEN.Id = p_Notificaciones_OID;
        notificacionesEN.TipoNotificacion = p_tipoNotificacion;
        notificacionesEN.Contenido = p_contenido;
        notificacionesEN.Id_tipo = p_id_tipo;
        //Call to NotificacionesCAD

        _INotificacionesCAD.Modify (notificacionesEN);
}

public void Destroy (int id
                     )
{
        _INotificacionesCAD.Destroy (id);
}

public NotificacionesEN ReadOID (int id
                                 )
{
        NotificacionesEN notificacionesEN = null;

        notificacionesEN = _INotificacionesCAD.ReadOID (id);
        return notificacionesEN;
}

public System.Collections.Generic.IList<NotificacionesEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionesEN> list = null;

        list = _INotificacionesCAD.ReadAll (first, size);
        return list;
}
}
}
