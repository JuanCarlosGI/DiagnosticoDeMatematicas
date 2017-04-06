using System.ComponentModel.DataAnnotations;

namespace DiagnosticoDeMatematicas.Models.ViewModels.Home
{
    public class ChangeEvaluationViewModel
    {
        [Required]
        public int Evaluation { get; set; }

        [Required]
        public int ExamId { get; set; }
    }
}