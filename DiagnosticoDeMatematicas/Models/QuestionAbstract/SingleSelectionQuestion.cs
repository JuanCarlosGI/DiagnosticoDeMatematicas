namespace DiagnosticoDeMatematicas.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Model representing a question.
    /// </summary>
    [Table("SingleSelectionQuestion")]
    public class SingleSelectionQuestion : SelectionQuestion
    {
        /// <summary>
        /// Creates a shallow copy of the Question.
        /// </summary>
        /// <returns>A copy of the question.</returns>
        //public SingleSelectionQuestion Copy()
        //{
        //    return new SingleSelectionQuestion
        //    {
        //        Id = Id,
        //        ExamID = ExamID,

        //        Description = string.Copy(Description),
        //        OptionA = string.Copy(OptionA),
        //        OptionB = string.Copy(OptionB),
        //        OptionC = string.Copy(OptionC),
        //        OptionD = string.Copy(OptionD),
        //        OptionAFeedback = string.Copy(OptionAFeedback),
        //        OptionBFeedback = string.Copy(OptionBFeedback),
        //        OptionCFeedback = string.Copy(OptionCFeedback),
        //        OptionDFeedback = string.Copy(OptionDFeedback),
        //        OptionACorrect = OptionACorrect,
        //        OptionBCorrect = OptionBCorrect,
        //        OptionCCorrect = OptionCCorrect,
        //        OptionDCorrect = OptionDCorrect,

        //        Exam = Exam,
        //        Answers = Answers,
        //        Variables = Variables
        //    };
        //}
    }
}