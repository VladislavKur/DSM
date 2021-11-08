
using System;
using ProyectoGenNHibernate.EN.Proyecto;

namespace ProyectoGenNHibernate.CAD.Proyecto
{
public partial interface INotificacionCAD
{
NotificacionEN ReadOIDDefault (int id
                               );

void ModifyDefault (NotificacionEN notificacion);

System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size);



int New_ (NotificacionEN notificacion);

void Modify (NotificacionEN notificacion);


void Destroy (int id
              );


NotificacionEN ReadOID (int id
                        );


System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size);


void AsignarSesion (int p_Notificacion_OID, int p_sesion_OID);
}
}
