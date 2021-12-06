
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


/*PROTECTED REGION ID(usingProyectoGenNHibernate.CEN.Proyecto_Usuario_desasignarPremium) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CEN.Proyecto
{
public partial class UsuarioCEN
{
public void DesasignarPremium (int p_Usuario_OID, int p_premium_OID)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CEN.Proyecto_Usuario_desasignarPremium_customized) ENABLED START*/


        //Call to UsuarioCAD
        UsuarioEN usuEN = _IUsuarioCAD.ReadOIDDefault (p_Usuario_OID);

        usuEN.EsPremium = false;
        _IUsuarioCAD.ModifyDefault (usuEN);

        _IUsuarioCAD.DesasignarPremium (p_Usuario_OID, p_premium_OID);

        /*PROTECTED REGION END*/
}
}
}
