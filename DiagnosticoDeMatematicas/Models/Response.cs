namespace DiagnosticoDeMatematicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Model representing a response to an exam.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Gets or sets the ID of the response.
        /// </summary>
        [Display(Name = "Respuesta")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user that this response belongs to.
        /// </summary>
        [Required]
        [ForeignKey("User")]
        [Display(Name = "Usuario")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the exam being answered.
        /// </summary>
        [Required]
        [ForeignKey("Exam")]
        [Display(Name = "Examen")]
        public int ExamId { get; set; }

        /// <summary>
        /// Gets or sets the date on which the response was created.
        /// </summary>
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets the grade of the response.
        /// </summary>
        [Display(Name = "Calificacion")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double Grade
        {
            get
            {
                if (Answers != null)
                {
                    if (Answers.Count == 0) return 0;

                    var count = 0.0;
                    foreach (var answer in Answers)
                    {
                        if (answer != null && answer.IsCorrect)
                        {
                            count++;
                        }
                    }

                    return count / Answers.Count * 100;
                }

                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the exam that is being answered.
        /// </summary>
        public virtual Exam Exam { get; set; }

        /// <summary>
        /// Gets or sets the user to which this response belongs to.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the answers belonging to this response.
        /// </summary>
        public virtual ICollection<Answer> Answers { get; set; }
    }
}