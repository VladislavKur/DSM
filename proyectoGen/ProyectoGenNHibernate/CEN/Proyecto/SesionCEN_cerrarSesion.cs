
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


/*PROTECTED REGION ID(usingProyectoGenNHibernate.CEN.Proyecto_Sesion_cerrarSesion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CEN.Proyecto
{
public partial class SesionCEN
{
public void CerrarSesion (int p_oid)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CEN.Proyecto_Sesion_cerrarSesion) ENABLED START*/

        // Write here your custom code...

        SesionEN sesEN = _ISesionCAD.ReadOIDDefault (p_oid);

        if (!(sesEN.Hora_fin != null)) {
                throw new ModelException ("No puedes terminar una sesion ya finalizada");
        }
        DateTime hora_fin_pre = (DateTime)sesEN.Hora_fin;

        sesEN.Hora_fin = DateTime.Now;


        if (!(sesEN.Hora_fin != hora_fin_pre))
                throw new ModelException ("No se ha asignado la hora de fin");

        _ISesionCAD.ModifyDefault (sesEN);




        /*PROTECTED REGION END*/
}
}
}
