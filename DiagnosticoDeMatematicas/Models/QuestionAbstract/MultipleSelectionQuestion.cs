using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Models
{
    [Table("MultipleSelectionQuestion")]
    public class MultipleSelectionQuestion : SelectionQuestion
    {
    }

    public class MultipleSelectionQuestionWithOptionsViewModel
    {
        public int Id { get; set; }

        public int ExamId { get; set; }
        public string Description { get; set; }

        public List<QuestionOption> Options { get; set; }
    }
}