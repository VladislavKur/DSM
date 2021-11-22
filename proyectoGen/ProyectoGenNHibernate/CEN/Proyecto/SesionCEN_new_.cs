
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


/*PROTECTED REGION ID(usingProyectoGenNHibernate.CEN.Proyecto_Sesion_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CEN.Proyecto
{
public partial class SesionCEN
{
public int New_ (Nullable<DateTime> p_hora_inicio, string p_usuario, string p_usuario_0, Nullable<DateTime> p_hora_fin)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CEN.Proyecto_Sesion_new__customized) START*/

        SesionEN sesionEN = null;

        int oid;

        //Initialized SesionEN
        sesionEN = new SesionEN ();
        sesionEN.Hora_inicio = p_hora_inicio;


        if (p_usuario != null) {
                sesionEN.Usuario = new ProyectoGenNHibernate.EN.Proyecto.UsuarioEN ();
                sesionEN.Usuario.Email = p_usuario;
        }


        if (p_usuario_0 != null) {
                sesionEN.Usuario_0 = new ProyectoGenNHibernate.EN.Proyecto.UsuarioEN ();
                sesionEN.Usuario_0.Email = p_usuario_0;
        }

        sesionEN.Hora_fin = p_hora_fin;

        //Call to SesionCAD

        oid = _ISesionCAD.New_ (sesionEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
