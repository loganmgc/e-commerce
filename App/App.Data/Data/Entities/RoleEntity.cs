﻿namespace App.Data.Data.Entities
{
    public class RoleEntity
    {
        public int RoleId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public ICollection<UserEntity> Users { get; set; }
    }
}
