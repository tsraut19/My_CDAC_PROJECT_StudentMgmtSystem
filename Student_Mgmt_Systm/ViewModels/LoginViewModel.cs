using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace miniProject.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter LoginName")]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool CheckBox { get; set; }
        
    }
}
