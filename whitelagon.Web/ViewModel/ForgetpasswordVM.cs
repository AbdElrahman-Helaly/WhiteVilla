using System.ComponentModel.DataAnnotations;

namespace whitelagon.Web.ViewModel
{
    public class ForgetpasswordVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

 
    }
}
