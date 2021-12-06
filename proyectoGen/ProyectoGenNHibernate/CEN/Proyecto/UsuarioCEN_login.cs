
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


/*PROTECTED REGION ID(usingProyectoGenNHibernate.CEN.Proyecto_Usuario_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CEN.Proyecto
{
public partial class UsuarioCEN
{
public string Login (string p_email, string p_pass)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CEN.Proyecto_Usuario_login) ENABLED START*/
        string result = null;

        IList<UsuarioEN> listaEn = DameUsuarioPorEmail (p_email);
        if (listaEn.Count > 0) {
                UsuarioEN en = listaEn [0];
                if (en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                        result = this.GetToken (en.Id);
        }



        return result;
        /*PROTECTED REGION END*/
}
}
}
