using DiagnosticoDeMatematicas.Helpers.CustomAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

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
    /// Model representing a user.
    /// </summary>
    public class User : IdentityUser
    {
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
        /// Gets or sets the date of birth of the user.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de nacimiento")]
        [ValidSqlDate(ErrorMessage = "La fecha tiene que ser mayor a 1/1/1753")]
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
        /// Gets or sets the responses belonging to the user.
        /// </summary>
        public virtual ICollection<Response> Responses { get; set; }
    }
}