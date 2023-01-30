using System.ComponentModel.DataAnnotations;

namespace Bus.Web.Models
{
    public class Credentials
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool IsRememberMe { get; set; }
    }
}
