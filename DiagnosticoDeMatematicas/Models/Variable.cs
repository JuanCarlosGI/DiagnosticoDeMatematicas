using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Models
{
    public class Variable
    {
        private static Random rnd = new Random();
        
        [Key, Column(Order = 0)]
        [Required(ErrorMessage = "Debes de indicar un simbolo para la variable.")]
        [Display(Name = "Simbolo")]
        [StringLength(1,MinimumLength = 1,ErrorMessage = "El simbolo debe de ser un caracter.")]
        public string Symbol { get; set; }
        [Key, ForeignKey("Question"), Column(Order = 1)]
        [Display(Name = "Pregunta")]
        public int QuestionID { get; set; }

        public int RandomValue
        {
            get
            {
                if (Ranges != null)
                {
                    var values = new List<int>();
                    foreach (var range in Ranges)
                    {
                        for (int i = range.Minimum; i <= range.Maximum; i++)
                        {
                            values.Add(i);
                        }
                    }

                    int r = rnd.Next(values.Count);
                    return values[r];
                }

                return 1;
            }
        }

        public virtual Question Question { get; set; }
        public virtual ICollection<Range> Ranges { get; set; }
    }
}