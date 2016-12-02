using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiagnosticoDeMatematicas.Models
{
    public class BinaryOptionSelection
    {
        [Key, Column(Order = 0)]
        public int ResponseId { get; set; }

        [Key, Column(Order = 1)]
        public int MultipleSelectionQuestionId { get; set; }

        [Key, Column(Order = 2)]
        public int QuestionOptionId { get; set; }

        public bool Selected { get; set; }

        public bool IsCorrect()
        {
            return QuestionOption?.IsCorrect == Selected;
        }

        [ForeignKey("ResponseId,MultipleSelectionQuestionId")]
        public virtual MultipleSelectionAnswer MultipleSelectionAnswer { get; set; }

        [ForeignKey("QuestionOptionId")]
        public virtual QuestionOption QuestionOption { get; set; }
    }
}