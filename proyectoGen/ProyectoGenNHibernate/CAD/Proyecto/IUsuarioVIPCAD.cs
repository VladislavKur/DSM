
using System;
using ProyectoGenNHibernate.EN.Proyecto;

namespace ProyectoGenNHibernate.CAD.Proyecto
{
public partial interface IUsuarioVIPCAD
{
UsuarioVIPEN ReadOIDDefault (string email
                             );

void ModifyDefault (UsuarioVIPEN usuarioVIP);

System.Collections.Generic.IList<UsuarioVIPEN> ReadAllDefault (int first, int size);



string New_ (UsuarioVIPEN usuarioVIP);

void Modify (UsuarioVIPEN usuarioVIP);


void Destroy (string email
              );


UsuarioVIPEN ReadOID (string email
                      );


System.Collections.Generic.IList<UsuarioVIPEN> ReadAll (int first, int size);
}
}
