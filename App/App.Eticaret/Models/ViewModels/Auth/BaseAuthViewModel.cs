﻿using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.Auth
{
    public abstract class BaseAuthViewModel
    {
        [Required(ErrorMessage = "Email is required"),
            EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required"),
            DataType(DataType.Password),
            MinLength(1)]
        public string Password { get; set; } = null!;
    }
}
