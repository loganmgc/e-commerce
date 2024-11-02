﻿namespace App.Service.Models.UserDTOs
{
    public class GetUserWithIdDto : BaseUserDto
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}