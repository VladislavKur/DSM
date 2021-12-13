
using System;
using ProyectoGenNHibernate.EN.Proyecto;

namespace ProyectoGenNHibernate.CAD.Proyecto
{
public partial interface IPremiumCAD
{
PremiumEN ReadOIDDefault (int id
                          );

void ModifyDefault (PremiumEN premium);

System.Collections.Generic.IList<PremiumEN> ReadAllDefault (int first, int size);



int New_ (PremiumEN premium);

void Modify (PremiumEN premium);


void Destroy (int id
              );


PremiumEN ReadOID (int id
                   );


System.Collections.Generic.IList<PremiumEN> ReadAll (int first, int size);


void ModificaPremium (PremiumEN premium);
}
}
