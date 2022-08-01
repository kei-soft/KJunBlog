using System.ComponentModel.DataAnnotations;

namespace Maui.BlazorAppTest.Models
{
    public class LoginUserModel
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
