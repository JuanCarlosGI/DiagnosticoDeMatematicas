using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiagnosticoDeMatematicas.Models
{
    public class Exam
    {
        [Display(Name = "Examen")]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Activo")]
        public bool Active { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }
}