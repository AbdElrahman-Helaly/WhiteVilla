using System.ComponentModel.DataAnnotations;
namespace whitelagon.Web.ViewModel
{
    public class LoginVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public string? RedirectUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
