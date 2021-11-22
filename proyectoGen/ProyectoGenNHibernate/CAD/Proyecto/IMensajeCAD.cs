
using System;
using ProyectoGenNHibernate.EN.Proyecto;

namespace ProyectoGenNHibernate.CAD.Proyecto
{
public partial interface IMensajeCAD
{
MensajeEN ReadOIDDefault (int id
                          );

void ModifyDefault (MensajeEN mensaje);

System.Collections.Generic.IList<MensajeEN> ReadAllDefault (int first, int size);



void Modify (MensajeEN mensaje);


void Destroy (int id
              );


MensajeEN ReadOID (int id
                   );


System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size);


int New_ (MensajeEN mensaje);
}
}
