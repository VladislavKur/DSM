
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


/*PROTECTED REGION ID(usingProyectoGenNHibernate.CEN.Proyecto_Usuario_incrementaLikes) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CEN.Proyecto
{
public partial class UsuarioCEN
{
public void IncrementaLikes (string p_oid)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CEN.Proyecto_Usuario_incrementaLikes) ENABLED START*/

        // Write here your custom code...

        UsuarioEN usuEN = _IUsuarioCAD.ReadOIDDefault (p_oid);

        /*if (!(usuEN.Like_counter >= 1))
         * {
         *  throw new ModelException("No tienes ning�n like");
         * }*/
        int likepre = usuEN.Like_counter;

        usuEN.Like_counter++;

        if (!(usuEN.Like_counter == likepre + 1))
                throw new ModelException ("No se ha incrementado");

        _IUsuarioCAD.ModifyDefault (usuEN);

        /*PROTECTED REGION END*/
}
}
}
