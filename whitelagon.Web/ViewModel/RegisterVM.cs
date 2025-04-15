using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace whitelagon.Web.ViewModel
{
    public class RegisterVM
    {
    
       
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
      
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage ="The password and confirmation password do not match.")]
        [Display(Name="Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name="Phone number")]
        public string Phonenumber { get; set; }

        public string? RedirectUrl { get; set; }

       public string? Role { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? Rolelist { get; set; }



    }
}
