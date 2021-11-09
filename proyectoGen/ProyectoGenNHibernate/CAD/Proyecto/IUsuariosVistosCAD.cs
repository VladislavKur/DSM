
using System;
using ProyectoGenNHibernate.EN.Proyecto;

namespace ProyectoGenNHibernate.CAD.Proyecto
{
public partial interface IUsuariosVistosCAD
{
UsuariosVistosEN ReadOIDDefault (int id
                                 );

void ModifyDefault (UsuariosVistosEN usuariosVistos);

System.Collections.Generic.IList<UsuariosVistosEN> ReadAllDefault (int first, int size);



int New_ (UsuariosVistosEN usuariosVistos);

void Modify (UsuariosVistosEN usuariosVistos);


void Destroy (int id
              );


UsuariosVistosEN ReadOID (int id
                          );


System.Collections.Generic.IList<UsuariosVistosEN> ReadAll (int first, int size);
}
}
