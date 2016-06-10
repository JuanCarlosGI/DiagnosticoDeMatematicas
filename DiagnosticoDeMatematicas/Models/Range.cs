using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Foolproof;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiagnosticoDeMatematicas.Models
{
    public class Range
    {
        [Display(Name = "Rango")]
        public int ID { set; get; }
        [Required]
        [ForeignKey("Variable"), Column(Order = 1)]
        [Display(Name = "Pregunta")]
        public int QuestionId { set; get; }
        [Required]
        [ForeignKey("Variable"), Column(Order = 0)]
        [Display(Name = "Variable")]
        public string Symbol { set; get; }
        [Required]
        [Display(Name = "Mínimo")]
        public int Minimum { get; set; }
        [Required]
        [Display(Name = "Máximo")]
        [GreaterThanOrEqualTo("Minimum", ErrorMessage = "Debe de ser un valor igual o mayor al mínimo.")]
        public int Maximum { get; set; }

        public virtual Variable Variable { get; set; }
    }
}