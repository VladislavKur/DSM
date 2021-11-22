
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


/*PROTECTED REGION ID(usingProyectoGenNHibernate.CEN.Proyecto_Usuario_editarPerfil) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CEN.Proyecto
{
public partial class UsuarioCEN
{
public void EditarPerfil (int p_oid, string p_nickname, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento, ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum p_orientacion_sexual, ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum p_genero, String p_pass)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CEN.Proyecto_Usuario_editarPerfil) ENABLED START*/

        // Write here your custom code...
        UsuarioEN usuEN = _IUsuarioCAD.ReadOIDDefault (p_oid);

        if (!((p_nickname != null && p_nombre != null && p_apellidos != null && p_fecha_nacimiento != null && p_pass != null)
              && (p_nickname != "" && p_nombre != "" && p_apellidos != "" && p_pass != ""))) {
                throw new ModelException ("No se puede dejar ningun campo vacio");
        }



        usuEN.Nickname = p_nickname;
        usuEN.Nombre = p_nombre;
        usuEN.Apellidos = p_apellidos;
        usuEN.Fecha_nacimiento = p_fecha_nacimiento;
        usuEN.Orientacion_sexual = p_orientacion_sexual;
        usuEN.Genero = p_genero;
        usuEN.Pass = p_pass;

        _IUsuarioCAD.ModifyDefault (usuEN);


        /*PROTECTED REGION END*/
}
}
}
