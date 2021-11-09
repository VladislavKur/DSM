
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.CAD.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;



/*PROTECTED REGION ID(usingProyectoGenNHibernate.CP.Proyecto_Usuario_addUsuario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CP.Proyecto
{
public partial class UsuarioCP : BasicCP
{
public void AddUsuario (int p_Usuario_OID, int p_Usuario_receptor_OID)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CP.Proyecto_Usuario_addUsuario) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;

        IUsuarioCAD usuarioCAD2 = null;
        UsuarioCEN usuarioCEN2 = null;


        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCAD2 = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);




                // Write here your custom transaction ...

                throw new NotImplementedException ("Method AddUsuario() not yet implemented.");



                SessionCommit ();


                /*Relationer de premium*/
                /*SessionInitializeTransaction ();
                 * usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                 * ProyectoGenNHibernate.EN.Proyecto.PremiumEN premiumENAux = null;
                 * if (usuarioEN.Premium == null) {
                 *      usuarioEN.Premium = new System.Collections.Generic.List<ProyectoGenNHibernate.EN.Proyecto.PremiumEN>();
                 * }
                 *
                 * foreach (int item in p_premium_OIDs) {
                 *      premiumENAux = new ProyectoGenNHibernate.EN.Proyecto.PremiumEN ();
                 *      premiumENAux = (ProyectoGenNHibernate.EN.Proyecto.PremiumEN)session.Load (typeof(ProyectoGenNHibernate.EN.Proyecto.PremiumEN), item);
                 *      premiumENAux.Usuario.Add (usuarioEN);
                 *
                 *      usuarioEN.Premium.Add (premiumENAux);
                 * }
                 *
                 *
                 * session.Update (usuarioEN);
                 * SessionCommit ();*/
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
