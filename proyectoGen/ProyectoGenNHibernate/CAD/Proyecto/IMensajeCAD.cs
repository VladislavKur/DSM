
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

System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> DameMensajesEmisor (int p_id);


System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> DameMensajesReceptor (int p_id);


System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> DameMensajes (int p_idUsuario);


System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.MensajeEN> DameMensajesEntreEstos2 (int p_idUsuario, int p_idUsuarioReceptor);
}
}
