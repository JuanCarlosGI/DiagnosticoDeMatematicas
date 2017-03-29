using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Models.ViewModels
{
    public class ChangeEvaluationViewModel
    {
        [Required]
        public int Evaluation { get; set; }

        [Required]
        public int ExamId { get; set; }
    }
}