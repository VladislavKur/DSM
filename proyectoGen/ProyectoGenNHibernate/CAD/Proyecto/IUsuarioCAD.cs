
using System;
using ProyectoGenNHibernate.EN.Proyecto;

namespace ProyectoGenNHibernate.CAD.Proyecto
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string email
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);




string New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (string email
              );


UsuarioEN ReadOID (string email
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);


System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> FiltroDefecto ();


System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> FiltroBusqueda ();



void AsignarPremium (string p_Usuario_OID, int p_premium_OID);




void DesasignarPremium (string p_Usuario_OID, int p_premium_OID);





void EditarPerfil2 (UsuarioEN usuario);


System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> FiltroMatch ();


System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DameUsuariosPremium ();


System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DamePorOrientacion (ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum ? p_orientacion);


System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DamePorEdad (int? p_edad_min, int ? p_edad_max);


System.Collections.Generic.IList<ProyectoGenNHibernate.EN.Proyecto.UsuarioEN> DamePorGenero (ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum ? p_genero);
}
}
