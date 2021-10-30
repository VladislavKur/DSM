
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface ICompraCAD
{
CompraEN ReadOIDDefault (int id
                         );

void ModifyDefault (CompraEN compra);

System.Collections.Generic.IList<CompraEN> ReadAllDefault (int first, int size);



CompraEN ReadOID (int id
                  );


System.Collections.Generic.IList<CompraEN> ReadAll (int first, int size);


int New_ (CompraEN compra);

void Modify (CompraEN compra);


void Destroy (int id
              );
}
}
