using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Models
{
    public class Response
    {
        [Display(Name = "Respuesta")]
        public int ID { get; set; }
        [Required]
        [ForeignKey("User")]
        [Display(Name = "Usuario")]
        public string UserID { get; set; }
        [Required]
        [Display(Name = "Examen")]
        public int ExamID { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

        [Display(Name = "Calificacion")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double Grade
        {
            get
            {
                if (Answers != null)
                {
                    var count = 0.0;
                    foreach (Answer answer in Answers) if (answer.IsCorrect) count++;
                    return count / Answers.Count * 100;
                }
                return 0;
            }
        }

        public virtual Exam Exam { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }

    public class ResponseWithAnswers
    {
        public int ID { get; set; }
        [Required]
        [ForeignKey("User")]
        [Display(Name = "Usuario")]
        public string UserID { get; set; }
        [Required]
        [Display(Name = "Examen")]
        public int ExamID { get; set; }
        public List<QuestionAnswer> Choices { get; set; }

        public Exam Exam { get; set; }
    }

    public class QuestionAnswer
    {
        public int QuestionID { get; set; }
        public int SelectedOption { get; set; }
    }
}