﻿namespace App.Service.Models.ContactFormDTOs
{
    public class AddContactFormDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
