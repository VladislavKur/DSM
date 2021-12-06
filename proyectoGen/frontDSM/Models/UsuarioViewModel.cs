using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProyectoGenNHibernate.Enumerated.Proyecto;

namespace frontDSM.Models
{
    public class UsuarioViewModel : RegisterViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Pass { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Pass", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPass { get; set; }

        [Display(Prompt = "El email asociado a tu cuenta", Description = "El email asociado a tu cuenta", Name = "Correo electronico")]
        [Required(ErrorMessage = "Debe indicar un correo electrónico para su usuario")]
        [StringLength(maximumLength: 256, ErrorMessage = "Su correo no puede superar los 256 caracteres")]
        public string Email { get; set; }

        [Display(Prompt = "Nombre que se mostrará a los demás", Description = "Nombre que se mostrará a los demás", Name = "Nombre de usuario")]
        [Required(ErrorMessage = "Debe indicar un nombre de usuario para su usuario")]
        [StringLength(maximumLength: 20, ErrorMessage = "Su nombre no puede superar los 20 caracteres")]
        public string Nickname { get; set; }

        [Display(Prompt = "Su nombre real", Description = "Su nombre real", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para su usuario")]
        [StringLength(maximumLength: 20, ErrorMessage = "Su nombre no puede superar los 20 caracteres")]
        public string Nombre { get; set; }


        [Display(Prompt = "Apellidos", Description = "Sus apellidos", Name = "Apellidos")]
        [Required(ErrorMessage = "Debe indicar un nombre de usuario para su usuario")]
        [StringLength(maximumLength: 50, ErrorMessage = "Sus apellidos no puede superar los 20 caracteres")]
        public string Apellidos { get; set; }

        [Display(Prompt = "La fecha de nacimiento", Description = "La fecha de nacimiento", Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "Debe indicar una fecha de nacimiento para su usuario")]
        public DateTime Fecha_nacimiento { get; set; }

        [Display(Prompt = "Tu Orientacion Sexual", Description = "Tu Orientacion Sexual", Name = "Orientación Sexual")]
        [Required(ErrorMessage = "Debe indicar una orientación sexual para su usuario")]
        public OrientacionSexualEnum Orientacion_sexual { get; set; }

        [Display(Prompt = "El genero con el que identificas", Description = "El genero con el que identificas", Name = "Genero")]
        [Required(ErrorMessage = "Debe indicar un género para su usuario")]
        public GeneroUsuarioEnum Genero { get; set; }

        [Display(Prompt = "Fecha de registro", Description = "Fecha de registro", Name = "Fecha de registro")]
        [Required(ErrorMessage = "Debe indicar una fecha de registro para su usuario")]
        public DateTime Fecha_registro { get; set; }

        [Display(Prompt = "Contador de likes", Description = "Contador de likes", Name = "Likes")]
        public int Like_counter { get; set; }

        [Display(Prompt = "Edad del usuario", Description = "Edad del usuario", Name = "Edad")]
        [Required(ErrorMessage = "Debe indicar una edad para su usuario")]
        public int Edad { get; set; }

        [Display(Prompt = "Si es premium", Description = "Si es Premium", Name = "Es premium")]

        public Boolean EsPremium { get; set; }



    }
}