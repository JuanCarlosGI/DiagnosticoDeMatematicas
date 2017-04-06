using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticoDeMatematicas.Models.ViewModels.Users
{
    public class UserWithRoleStringViewModel
    {
        public User User { get; set; }
        public string Roles { get; set; }
    }
}