using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Models.ViewModels
{
    public class OptionStatisticsViewModel
    {
        public double Percentage { get; set; }

        public string Description { get; set; }

        public bool IsCorrect { get; set; }
    }
}