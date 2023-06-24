using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace miniProject.ViewModels
{
    public class RegisterViewModel
    {
        [Key]
        [Display(Name = "User Id")]
        public int UserNo { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please enter Login name")]
        public string LoginName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public string Gender { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter emailId")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+?([6-9]{1})\)?([0-9]{9})$",
                   ErrorMessage = "Entered valid phone number.")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirm password should be the same")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please select Degree")]
        public int DegreeNo { get; set; }
        
        public IEnumerable<SelectListItem> Degree { get; set; }
    }
}
