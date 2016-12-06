namespace DiagnosticoDeMatematicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Possible genders for a user.
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Male gender.
        /// </summary>
        Masculino,

        /// <summary>
        /// Female gender.
        /// </summary>
        Femenino
    }

    /// <summary>
    /// Possible occupations for a user.
    /// </summary>
    public enum Occupation
    {
        /// <summary>
        /// Student
        /// </summary>
        Estudiante,

        /// <summary>
        /// Professor
        /// </summary>
        Profesor,

        /// <summary>
        /// Professional
        /// </summary>
        Profesionista,

        /// <summary>
        /// Other
        /// </summary>
        Otro
    }

    /// <summary>
    /// Scale for measuring, from Extremely to Not at all.
    /// </summary>
    public enum Scale
    {
        /// <summary>
        /// Extremely
        /// </summary>
        Extremadamente,

        /// <summary>
        /// A lot
        /// </summary>
        Mucho,

        /// <summary>
        /// Moderately
        /// </summary>
        Moderadamente,

        /// <summary>
        /// Not much
        /// </summary>
        Poco,

        /// <summary>
        /// Not at all.
        /// </summary>
        Nada
    }

    /// <summary>
    /// Possible user roles
    /// </summary>
    public enum Role
    {
        /// <summary>
        /// Administrator
        /// </summary>
        Administrador,

        /// <summary>
        /// Normal user
        /// </summary>
        Usuario
    }

    /// <summary>
    /// Model representing a user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [Display(Name = "Correo electronico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        [Display(Name = "Rol")]
        [EnumDataType(typeof(Role))]
        [Required]
        public Role Role { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        [Required]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        [Required]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the user.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the gender of the user.
        /// </summary>
        [Required]
        [Display(Name = "Genero")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets the interest level of the user.
        /// </summary>
        [Required]
        [Display(Name = "Interés por las matemáticas")]
        [EnumDataType(typeof(Scale))]
        public Scale Interest { get; set; }

        /// <summary>
        /// Gets or sets the facility level of the user.
        /// </summary>
        [Required]
        [Display(Name = "Facilidad para las matemáticas")]
        [EnumDataType(typeof(Scale))]
        public Scale Facility { get; set; }

        /// <summary>
        /// Gets or sets the liking level oh the user.
        /// </summary>
        [Required]
        [Display(Name = "Gusto por las matemáticas")]
        [EnumDataType(typeof(Scale))]
        public Scale Liking { get; set; }

        /// <summary>
        /// Gets the age of the user.
        /// </summary>
        [Display(Name = "Edad")]
        public int Age
        {
            get
            {
                var years = DateTime.Now.Year - DateOfBirth.Year;
                if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear)
                {
                    years--;
                }

                return years;
            }
        }

        /// <summary>
        /// Gets the full name of the user.
        /// </summary>
        [Display(Name = "Nombre completo")]
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Gets or sets the responses belonging to the user.
        /// </summary>
        public virtual ICollection<Response> Responses { get; set; }
    }
}