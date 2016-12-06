namespace DiagnosticoDeMatematicas.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Model representing a question.
    /// </summary>
    [Table("SingleSelectionQuestion")]
    public class SingleSelectionQuestion : SelectionQuestion
    {

    }

    public class SingleSelectionQuestionWithOptionsViewModel
    {
        public int Id { get; set; }

        public int ExamId { get; set; }
        public string Description { get; set; }

        public List<QuestionOption> Options { get; set; }
    }
}