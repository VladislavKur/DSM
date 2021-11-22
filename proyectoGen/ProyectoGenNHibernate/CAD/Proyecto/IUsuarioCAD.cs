
using System;
using ProyectoGenNHibernate.EN.Proyecto;

namespace ProyectoGenNHibernate.CAD.Proyecto
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (int id
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);




int New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (int id
              );


UsuarioEN ReadOID (int id
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);


System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> FiltroDefecto (ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum? p_orientacion_sexual, ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum ? p_genero);


System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> FiltroBusqueda (ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum? p_orientacion, ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum? p_genero, int? p_edad_min, int ? p_edad_max);



void AsignarPremium (int p_Usuario_OID, int p_premium_OID);




void DesasignarPremium (int p_Usuario_OID, int p_premium_OID);





void EditarPerfil2 (UsuarioEN usuario);


System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DameUsuariosPremium ();
}
}
