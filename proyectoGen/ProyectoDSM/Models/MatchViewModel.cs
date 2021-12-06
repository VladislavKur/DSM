using ProyectoGenNHibernate.Enumerated.Proyecto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoDSM.Models
{
    public class MatchViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }


        [Display(Prompt = "El estado del match", Description = "El estado del match", Name = "Estado de Match")]
        [Required(ErrorMessage = "Debe indicar el estado del match")]
        public EstadoMatchEnum Estado { get; set; }

        
    }
}