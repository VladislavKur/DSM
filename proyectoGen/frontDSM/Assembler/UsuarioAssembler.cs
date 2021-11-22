using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using frontDSM.Models;
using ProyectoGenNHibernate.EN.Proyecto;

namespace frontDSM.Assembler
{
    public class UsuarioAssembler
    {
        public UsuarioViewModel ConvertENToModelUI(UsuarioEN en)
        {
            UsuarioViewModel usu = new UsuarioViewModel();
            usu.Id = en.Id;
            usu.Pass = en.Pass;
            usu.Email = en.Email;
            usu.Nickname = en.Nickname;
            usu.Nombre = en.Nombre;
            usu.Apellidos = en.Apellidos;
            usu.Fecha_nacimiento = (DateTime)en.Fecha_nacimiento;
            usu.Genero = en.Genero;
            usu.Orientacion_sexual = en.Orientacion_sexual;
            usu.Fecha_registro = (DateTime)en.Fecha_registro;
            usu.Like_counter = en.Like_counter;
            usu.Edad = en.Edad;
            usu.EsPremium = en.EsPremium;


            return usu;
        }

        public IList<UsuarioViewModel> ConvertListENToModel(IList<UsuarioEN> ens)
        {

            IList<UsuarioViewModel> usus = new List<UsuarioViewModel>();
            foreach (UsuarioEN en in ens)
            {
                usus.Add(ConvertENToModelUI(en));
            }
            return usus;
        }

    }
}