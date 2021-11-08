
using System;
using ProyectoGenNHibernate.EN.Proyecto;

namespace ProyectoGenNHibernate.CAD.Proyecto
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


MatchEN ReadOID (int id
                 );


System.Collections.Generic.IList<MatchEN> ReadAll (int first, int size);
}
}