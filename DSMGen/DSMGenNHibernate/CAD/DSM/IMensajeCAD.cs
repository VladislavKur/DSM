
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface IMensajeCAD
{
MensajeEN ReadOIDDefault (int idMensaje
                          );

void ModifyDefault (MensajeEN mensaje);

System.Collections.Generic.IList<MensajeEN> ReadAllDefault (int first, int size);



int New_ (MensajeEN mensaje);

void Modify (MensajeEN mensaje);


void Destroy (int idMensaje
              );


MensajeEN ReadOID (int idMensaje
                   );


System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size);
}
}
