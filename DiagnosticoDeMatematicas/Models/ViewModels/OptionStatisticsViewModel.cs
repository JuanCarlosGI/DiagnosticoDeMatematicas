namespace DiagnosticoDeMatematicas.Models.ViewModels
{
    /// <summary>
    /// Represents the statistics of an option of a question.
    /// </summary>
    public class OptionStatisticsViewModel
    {
        /// <summary>
        /// Gets or sets the percentage of times it is selected.
        /// </summary>
        public double Percentage { get; set; }

        /// <summary>
        /// Gets or sets the description of the option.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the option is correct or not.
        /// </summary>
        public bool IsCorrect { get; set; }
    }
}