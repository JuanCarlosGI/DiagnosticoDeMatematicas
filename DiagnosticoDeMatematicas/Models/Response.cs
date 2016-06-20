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
        public Question Question { get; set; }
        public int SelectedOption { get; set; }
        public Guid Guid { set; get; }

        private static Random Random = new Random();
        private static Dictionary<Guid, int[]> SwapDictionary = new Dictionary<Guid, int[]>();

        public void Shuffle()
        {
            int[] swaps = { 0, 1, 2, 3 };
            int n = 4;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                int value = swaps[k];
                swaps[k] = swaps[n];
                swaps[n] = value;
            }

            QuestionAnswer aux = new QuestionAnswer
            {
                Question = new Question
                {
                    OptionA = Question.OptionA,
                    OptionB = Question.OptionB,
                    OptionC = Question.OptionC,
                    OptionD = Question.OptionD
                }
            };

            Question.OptionA = aux.GetQuestion(swaps[0]);
            Question.OptionB = aux.GetQuestion(swaps[1]);
            Question.OptionC = aux.GetQuestion(swaps[2]);
            Question.OptionD = aux.GetQuestion(swaps[3]);

            Guid = Guid.NewGuid();
            SwapDictionary.Add(Guid, swaps);
        }

        public int GetAnswer()
        {
            var swaps = SwapDictionary[Guid];
            SwapDictionary.Remove(Guid);
            return swaps[SelectedOption];
        }

        private string GetQuestion(int Option)
        {
            switch(Option)
            {
                case 0: return Question.OptionA;
                case 1: return Question.OptionB;
                case 2: return Question.OptionC;
                case 3: return Question.OptionD;
                default: return null;
            }
        }
    }
}