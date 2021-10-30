
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface ISesionCAD
{
SesionEN ReadOIDDefault (int id
                         );

void ModifyDefault (SesionEN sesion);

System.Collections.Generic.IList<SesionEN> ReadAllDefault (int first, int size);



int New_ (SesionEN sesion);

void Modify (SesionEN sesion);


void Destroy (int id
              );


SesionEN ReadOID (int id
                  );


System.Collections.Generic.IList<SesionEN> ReadAll (int first, int size);
}
}
