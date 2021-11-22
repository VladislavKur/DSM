
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProyectoGenNHibernate.Exceptions;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.CAD.Proyecto;


/*PROTECTED REGION ID(usingProyectoGenNHibernate.CEN.Proyecto_Usuario_editarPerfil2) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CEN.Proyecto
{
public partial class UsuarioCEN
{
public void EditarPerfil2 (int p_Usuario_OID, String p_pass, string p_nickname, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento, ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum p_orientacion_sexual, ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum p_genero)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CEN.Proyecto_Usuario_editarPerfil2_customized) START*/

        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Id = p_Usuario_OID;
        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        usuarioEN.Nickname = p_nickname;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Apellidos = p_apellidos;
        usuarioEN.Fecha_nacimiento = p_fecha_nacimiento;
        usuarioEN.Orientacion_sexual = p_orientacion_sexual;
        usuarioEN.Genero = p_genero;
        //Call to UsuarioCAD

        _IUsuarioCAD.EditarPerfil2 (usuarioEN);

        /*PROTECTED REGION END*/
}
}
}
