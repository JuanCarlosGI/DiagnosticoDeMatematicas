namespace DiagnosticoDeMatematicas.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Model representing an exam.
    /// </summary>
    public class Exam
    {
        /// <summary>
        /// Gets or sets the ID of the exam.
        /// </summary>
        [Display(Name = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the exam.
        /// </summary>
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the exam.
        /// </summary>
        [Required]
        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets additional comments for when a user is answering the exam.
        /// </summary>
        [Display(Name = "Comentarios")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the exam is active or not.
        /// </summary>
        [Display(Name = "Activo")]
        public bool Active { get; set; }

        /// <summary>
        /// Gets the average grade of all responses belonging to this exam. If no responses are found, the average is 0.
        /// </summary>
        public decimal AverageGrade
        {
            get
            {
                if (Responses == null)
                {
                    return 0;
                }

                var sum = 0.0;
                foreach (var response in Responses)
                {
                    sum += response.Grade;
                }

                return (decimal)(sum / Responses.Count);
            }
        }

        /// <summary>
        /// Gets or sets the questions that the exam has.
        /// </summary>
        public virtual ICollection<QuestionAbstract> Questions { get; set; }

        /// <summary>
        /// Gets or sets the responses that the exam has.
        /// </summary>
        public virtual ICollection<Response> Responses { get; set; }
    }
}