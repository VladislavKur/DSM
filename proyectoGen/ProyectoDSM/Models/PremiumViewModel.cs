using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProyectoGenNHibernate.Enumerated.Proyecto;

namespace ProyectoDSM.Models
{
    public class PremiumViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "El precio del premium", Description = "El precio del premium", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar una contraseña para su usuario")]
        [Range(minimum:0.0,maximum: 2000.0,ErrorMessage = "El precio debe estar entre 0 y 2000€")]
        public double Precio { get; set; }

        [Display(Prompt = "El estado de la compra", Description = "El estado de la compra", Name = "Estado de la compra")]
        [Required(ErrorMessage = "Debe indicar un estado de la compra")]
        public EstadoCompraEnum EstadoCompra { get; set; }

        [Display(Prompt = "Fecha de la compra", Description = "Fecha de la compra", Name = "Fecha de la compra")]
        [Required(ErrorMessage = "Debe indicar una fecha de compra")]
        public DateTime Fecha_compra { get; set; }

        [Display(Prompt = "Fecha caduca", Description = "Fecha caduca", Name = "Fecha expira")]
        public DateTime Fecha_caduca { get; set; }

    }
}