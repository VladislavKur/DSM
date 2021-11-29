using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.Enumerated.Proyecto;

namespace frontDSM.Models
{
    public class BusquedaViewModel
    {
        #region Properties
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Su contraseña", Description = "Su orientacion", Name = "Orientacion")]
        public OrientacionSexualEnum? Orientacion_sexual { get; set; }

        [Display(Prompt = "El genero por el que quieres filtrar", Description = "El genero por el que quieres filtrar", Name = "Genero")]
        public GeneroUsuarioEnum? Genero { get; set; }

        [Display(Prompt = "Nombre que se mostrará a los demás", Description = "Nombre que se mostrará a los demás", Name = "Edad minima")]
        [Range(minimum: 18, maximum: 60, ErrorMessage = "La edad tiene que estar entre 18 y 60 años")]
        public int? Edad_min { get; set; }

        [Display(Prompt = "Edad maxima", Description = "Edad maxima", Name = "Edad maxima")]
        [Range(minimum: 18, maximum: 60, ErrorMessage = "La edad tiene que estar entre 18 y 60 años")]
        public int? Edad_max { get; set; }


        //coleccion de resultados
        public List<UsuarioEN> Busqueda { get; set; }
        #endregion 

        //constructor?
        public BusquedaViewModel()
        {
            Orientacion_sexual = null;
            Genero = null;
            Edad_min = null;
            Edad_max = null;

            Busqueda = new List<UsuarioEN>();
        }

    }
}