using ProyectoGenNHibernate.Enumerated.Proyecto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace frontDSM.Models
{
    public class SesionViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Hora a la que se ha conectado", Description = "Hora a la que se ha conectado", Name = "Hora de inicio")]
        [Required(ErrorMessage = "Debe indicar una fecha de compra")]
        public DateTime Hora_inicio { get; set; }

        [Display(Prompt = "Hora a la que se ha desconectado", Description = "Hora a la que se ha desconectado", Name = "Hora de fin")]
        public DateTime Hora_fin { get; set; }
    }
}