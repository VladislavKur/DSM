
using System;
using DSMGenNHibernate.EN.DSM;

namespace DSMGenNHibernate.CAD.DSM
{
public partial interface IMatchCAD
{
MatchEN ReadOIDDefault (int id
                        );

void ModifyDefault (MatchEN match);

System.Collections.Generic.IList<MatchEN> ReadAllDefault (int first, int size);



int New_ (MatchEN match);

void Modify (MatchEN match);


void Destroy (int id
              );
}
}
