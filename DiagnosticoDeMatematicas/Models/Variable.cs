namespace DiagnosticoDeMatematicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Model representing a variable inside a question.
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// Object used to generate random values consistently.
        /// </summary>
        private static Random rnd = new Random();
        
        /// <summary>
        /// Gets or sets the symbol representing the variable.
        /// </summary>
        [Key, Column(Order = 0)]
        [Required(ErrorMessage = "Debes de indicar un simbolo para la variable.")]
        [Display(Name = "Simbolo")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "El simbolo debe de ser un caracter.")]
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the ID of the question to which the variable belongs to.
        /// </summary>
        [Key, ForeignKey("Question"), Column(Order = 1)]
        [Display(Name = "Pregunta")]
        public int QuestionID { get; set; }

        /// <summary>
        /// Gets or sets the question to which the variable belongs to.
        /// </summary>
        public virtual Question Question { get; set; }

        /// <summary>
        /// Gets or sets the ranges belonging to the variable.
        /// </summary>
        public virtual ICollection<Range> Ranges { get; set; }

        /// <summary>
        /// Generates a random value for the variable to take.
        /// </summary>
        /// <returns>A random value.</returns>
        public int RandomValue()
        {
            if (Ranges != null)
            {
                var values = new List<int>();
                foreach (var range in Ranges)
                {
                    for (int i = range.Minimum; i <= range.Maximum; i++)
                    {
                        values.Add(i);
                    }
                }

                int r = rnd.Next(values.Count);
                return values[r];
            }

            return 1;
        }
    }
}