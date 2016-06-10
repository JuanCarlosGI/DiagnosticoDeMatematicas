using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Models
{
    public enum Gender
    {
        Masculino,
        Femenino
    }

    public enum Occupation
    {
        Estudiante,
        Profesor,
        Profesionista,
        Otro
    }

    public enum Scale
    {
        Extremadamente,
        Mucho,
        Moderadamente,
        Poco,
        Nada
    }

    public enum Role
    {
        Administrador,
        Usuario
    }

    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [Display(Name = "Correo electronico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Rol")]
        [EnumDataType(typeof(Role))]
        [Required]
        public Role Role { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Sexo")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        [Required]
        [Display(Name = "Interes")]
        [EnumDataType(typeof(Scale))]
        public Scale Interest { get; set; }
        [Required]
        [Display(Name = "Facilidad")]
        [EnumDataType(typeof(Scale))]
        public Scale Facility { get; set; }
        [Required]
        [Display(Name = "Gusto")]
        [EnumDataType(typeof(Scale))]
        public Scale Liking { get; set; }

        [Display(Name = "Edad")]
        public int Age
        {
            get
            {
                var years = DateTime.Now.Year - DateOfBirth.Year;
                if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear) years--;

                return years;
            }
        }

        [Display(Name = "Nombre completo")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public virtual ICollection<Response> Responses { get; set; }
    }
}