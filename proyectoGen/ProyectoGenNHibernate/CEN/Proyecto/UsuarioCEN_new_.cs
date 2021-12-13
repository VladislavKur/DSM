
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


/*PROTECTED REGION ID(usingProyectoGenNHibernate.CEN.Proyecto_Usuario_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CEN.Proyecto
{
    public partial class UsuarioCEN
    {
        public int New_(String p_pass, string p_email, string p_nickname, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento, ProyectoGenNHibernate.Enumerated.Proyecto.OrientacionSexualEnum p_orientacion_sexual, ProyectoGenNHibernate.Enumerated.Proyecto.GeneroUsuarioEnum p_genero, Nullable<DateTime> p_fecha_registro, int p_like_counter, string p_foto)
        {
            /*PROTECTED REGION ID(ProyectoGenNHibernate.CEN.Proyecto_Usuario_new__customized) START*/

            UsuarioEN usuarioEN = null;

            int oid;

            //Initialized UsuarioEN
            usuarioEN = new UsuarioEN();
            usuarioEN.Pass = Utils.Util.GetEncondeMD5(p_pass);

            usuarioEN.Email = p_email;

            usuarioEN.Nickname = p_nickname;

            usuarioEN.Nombre = p_nombre;

            usuarioEN.Apellidos = p_apellidos;

            usuarioEN.Fecha_nacimiento = p_fecha_nacimiento;

            usuarioEN.Orientacion_sexual = p_orientacion_sexual;

            usuarioEN.Genero = p_genero;

            usuarioEN.Fecha_registro = p_fecha_registro;

            usuarioEN.Like_counter = p_like_counter;

            usuarioEN.Foto = p_foto;

            //Call to UsuarioCAD

            oid = _IUsuarioCAD.New_(usuarioEN);
            return oid;
            /*PROTECTED REGION END*/
        }
    }
}
