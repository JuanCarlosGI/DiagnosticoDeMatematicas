namespace DiagnosticoDeMatematicas.Models.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// View Model for view Responses/Create.
    /// </summary>
    public class ResponseWithAnswersViewModel
    {
        /// <summary>
        /// Gets or sets the ID of the response.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        [Required]
        [ForeignKey("User")]
        [Display(Name = "Usuario")]
        public string UserID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the exam being answered.
        /// </summary>
        [Required]
        [Display(Name = "Examen")]
        public int ExamID { get; set; }

        /// <summary>
        /// Gets or sets a list of all questions and its answers.
        /// </summary>
        public List<QuestionAnswer> Choices { get; set; }

        /// <summary>
        /// Gets or sets the exam that is being answered.
        /// </summary>
        public Exam Exam { get; set; }
    }
}