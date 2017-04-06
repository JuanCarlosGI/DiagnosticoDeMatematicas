using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Helpers.CustomAnnotations
{
    public class ValidSqlDateAttribute : ValidationAttribute
    {
        private static readonly DateTime LowestSqlDate = new DateTime(1752,1,1);
        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            return dt >= LowestSqlDate;
        }
    }
}