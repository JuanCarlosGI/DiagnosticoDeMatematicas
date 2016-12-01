using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Models
{
    [Table("SelectionQuestion")]
    public class SelectionQuestion : QuestionAbstract
    {
        public virtual ICollection<QuestionOption> Options { get; set; }
    }

    public class SelectionQuestionWithOptionsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        public List<QuestionOption> Options { get; set; }
    }
}