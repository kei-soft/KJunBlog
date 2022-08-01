using System.ComponentModel.DataAnnotations;

namespace Maui.BlazorAppTest.Models
{
    public class LoginModel
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
