using ProyectoGenNHibernate.Enumerated.Proyecto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace frontDSM.Models
{
    public class MensajeViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }


        [Display(Prompt = "El tipo de notificacion", Description = "El tipo de notificacion", Name = "Tipo de Notificación")]
        [Required(ErrorMessage = "Debe indicar el tipo de notificación")]
        public EstadoMensajeEnum Estado { get; set; }

        [Display(Prompt = "El contenido de la notificación", Description = "El contenido de la notificación", Name = "Contenido")]
        [Required(ErrorMessage = "Debe indicar el contenido de la notificación")]
        [StringLength(maximumLength: 2000, ErrorMessage = "La notificacion no puede tener más de 2000 caracateres")]
        public string Contenido { get; set; }
        
    }
}