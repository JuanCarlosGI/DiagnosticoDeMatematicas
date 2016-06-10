using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiagnosticoDeMatematicas.Models
{
    public enum Choice
    {
        A = 'A', B, C, D
    }

    public class Answer
    {
        [Key,Column(Order = 0)]
        [ForeignKey("Response")]
        [Display(Name = "Entrega")]
        public int ResponseID { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Question")]
        [Display(Name = "Pregunta")]
        public int QuestionID { get; set; }
        [Required]
        [Display(Name = "Eleccion")]
        [EnumDataType(typeof(Choice))]
        public Choice Choice { get; set; }

        [Display(Name = "Es correcta")]
        public bool IsCorrect
        {
            get
            {
                return Question.CorrectAnswers.Contains((char)Choice);
            }
        }

        public virtual Response Response { get; set; }
        public virtual Question Question { get; set; }
    }
}