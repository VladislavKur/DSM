using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace frontDSM.Models
{
    public class PerfilUsuarioViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nombre del Usuario", Description = "El contenido del nombre", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar el contenido del nombre")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracateres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Nickname del Usuario", Description = "El contenido del nickname", Name = "Nickname")]
        [Required(ErrorMessage = "Debe indicar el contenido del nickname")]
        [StringLength(maximumLength: 400, ErrorMessage = "El nickname no puede tener más de 400 caracateres")]
        public string Nickname { get; set; }

        /*[Display(Prompt = "Descripcion del Usuario", Description = "El contenido de la descripcion", Name = "Descripcion")]
        [Required(ErrorMessage = "Debe indicar el contenido de la descripcion")]
        [StringLength(maximumLength: 4000, ErrorMessage = "La descripcion no puede tener más de 4000 caracateres")]
        public int Descripcion { get; set; }*/
    }
}