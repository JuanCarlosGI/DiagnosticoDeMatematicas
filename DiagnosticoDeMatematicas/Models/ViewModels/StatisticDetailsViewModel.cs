namespace DiagnosticoDeMatematicas.Models.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Foolproof;

    /// <summary>
    /// View Model for the view Responses/StatisticDetails
    /// </summary>
    public class StatisticDetailsViewModel
    {
        /// <summary>
        /// Gets or sets the ID of the exam that is being analyzed.
        /// </summary>
        [Display(Name = "Examen")]
        public int? ExamId { get; set; }

        /// <summary>
        /// Gets or sets the minimum for the Date value of responses in order for them to be considered. If it is null, there is no minimum.
        /// </summary>
        [Display(Name = "Fecha de inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the maximum for the Date value of responses in order for them to be considered. If it is null, there is no maximum.
        /// </summary>
        [Display(Name = "Fecha de terminación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [GreaterThanOrEqualTo("StartDate")]
        public DateTime? EndDate { get; set; }
    }
}