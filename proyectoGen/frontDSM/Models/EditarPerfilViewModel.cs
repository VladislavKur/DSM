using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace frontDSM.Models
{
    public class EditarPerfilViewModel
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

        [Display(Prompt = "Edad del Usuario", Description = "El contenido de la edad", Name = "Edad")]
        [Required(ErrorMessage = "Debe indicar el contenido de la edad")]
        [StringLength(maximumLength: 400, ErrorMessage = "La edad no puede tener más de 400 caracateres")]
        public int Edad { get; set; }

        [Display(Prompt = "Genero del Usuario", Description = "El contenido del genero", Name = "Genero")]
        [Required(ErrorMessage = "Debe indicar el contenido del genero")]
        [StringLength(maximumLength: 400, ErrorMessage = "El genero no puede tener más de 400 caracateres")]
        public Enum Genero { get; set; }

        [Display(Prompt = "Interes del Usuario", Description = "El contenido del interes", Name = "Interes")]
        [Required(ErrorMessage = "Debe indicar el contenido del interes")]
        [StringLength(maximumLength: 400, ErrorMessage = "El interes no puede tener más de 400 caracateres")]
        public Enum Interes { get; set; }

    }
}