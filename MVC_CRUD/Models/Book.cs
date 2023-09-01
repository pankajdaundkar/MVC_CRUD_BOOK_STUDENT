﻿using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
    public class Book
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Author { get; set; }
        [ScaffoldColumn(false)]
        public int isActive { get; set; }

    }
}
