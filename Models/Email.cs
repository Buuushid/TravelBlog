﻿using System.ComponentModel.DataAnnotations;

namespace TravelBlog.Models
{
    public class Email
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }
    }
}
