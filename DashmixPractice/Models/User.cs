using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DashmixPractice.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ProfilePicturePath { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [StringLength(8)]
        public string Password { get; set; }

        [NotMapped]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        public bool RememberMe { get; set; }
    }
}