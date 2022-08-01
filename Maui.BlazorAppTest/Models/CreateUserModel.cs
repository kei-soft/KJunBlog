﻿using System.ComponentModel.DataAnnotations;

namespace Maui.BlazorAppTest.Models
{
    public class CreateUserModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
