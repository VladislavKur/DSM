
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


/*PROTECTED REGION ID(usingProyectoGenNHibernate.CEN.Proyecto_Usuario_calcularEdad) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ProyectoGenNHibernate.CEN.Proyecto
{
public partial class UsuarioCEN
{
public void CalcularEdad (int p_oid)
{
        /*PROTECTED REGION ID(ProyectoGenNHibernate.CEN.Proyecto_Usuario_calcularEdad) ENABLED START*/

        // Write here your custom code...
        UsuarioEN usuEN = _IUsuarioCAD.ReadOIDDefault (p_oid);

        /*---------------*/
        /*
         * if (!usuEN.Fecha_nacimiento.HasValue)
         * {
         *  DateTime Now = DateTime.Now;
         *  int Years = new DateTime(DateTime.Now.Subtract((DateTime)usuEN.Fecha_nacimiento).Ticks).Year - 1;
         *  DateTime PastYearDate = ((DateTime)usuEN.Fecha_nacimiento).AddYears(Years);
         *  int Months = 0;
         *  for (int i = 1; i <= 12; i++)
         *  {
         *      if (PastYearDate.AddMonths(i) == Now)
         *      {
         *          Months = i;
         *          break;
         *      }
         *      else if (PastYearDate.AddMonths(i) >= Now)
         *      {
         *          Months = i - 1;
         *          break;
         *      }
         *  }
         *  int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
         *  int Hours = Now.Subtract(PastYearDate).Hours;
         *  int Minutes = Now.Subtract(PastYearDate).Minutes;
         *  int Seconds = Now.Subtract(PastYearDate).Seconds;
         *  string edadString=String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)",
         *  Years, Months, Days, Hours, Seconds);
         *
         *  Console.WriteLine(edadString);
         *
         * }*/

        int age = 0;
        int agepre = age;

        usuEN.Edad = DateTime.Now.Year - ((DateTime)usuEN.Fecha_nacimiento).Year;
        if (DateTime.Now.DayOfYear < ((DateTime)usuEN.Fecha_nacimiento).DayOfYear) {
                usuEN.Edad--;
        }

        if (usuEN.Edad == agepre) {
                throw new ModelException ("No se ha modificado la edad");
        }


        _IUsuarioCAD.ModifyDefault (usuEN);


        /*PROTECTED REGION END*/
}
}
}
