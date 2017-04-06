using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DiagnosticoDeMatematicas.Helpers.CustomAnnotations;
using Foolproof;

namespace DiagnosticoDeMatematicas.Models.ViewModels.Users
{
    public class CreateUserViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de nacimiento")]
        [ValidSqlDate(ErrorMessage = "La fecha tiene que ser mayor a 1/1/1753")]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        [Display(Name = "Genero")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        
        [Required]
        [Display(Name = "Interés por las matemáticas")]
        [EnumDataType(typeof(Scale))]
        public Scale Interest { get; set; }
        
        [Required]
        [Display(Name = "Facilidad para las matemáticas")]
        [EnumDataType(typeof(Scale))]
        public Scale Facility { get; set; }
        
        [Required]
        [Display(Name = "Gusto por las matemáticas")]
        [EnumDataType(typeof(Scale))]
        public Scale Liking { get; set; }

        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [Display(Name="Contrseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Repite contrseña")]
        [DataType(DataType.Password)]
        [EqualTo("Password", ErrorMessage = "Las contraseñas no son iguales.")]
        public string RepeatPassword { get; set; }

        [Required]
        [Display(Name = "Correo")]
        public string Email { get; set; }
    }
}