using System.ComponentModel.DataAnnotations;

namespace DiagnosticoDeMatematicas.Models.ViewModels.Home
{
    public class SignInViewModel
    {
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Success { get; set; } = false;
    }
}