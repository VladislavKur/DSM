
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface INotificacionesCAD
{
NotificacionesEN ReadOIDDefault (int id
                                 );

void ModifyDefault (NotificacionesEN notificaciones);

System.Collections.Generic.IList<NotificacionesEN> ReadAllDefault (int first, int size);



int New_ (NotificacionesEN notificaciones);

void Modify (NotificacionesEN notificaciones);


void Destroy (int id
              );


NotificacionesEN ReadOID (int id
                          );


System.Collections.Generic.IList<NotificacionesEN> ReadAll (int first, int size);
}
}
