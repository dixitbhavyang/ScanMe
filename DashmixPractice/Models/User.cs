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

        [Required(ErrorMessage = "* Name is Required. . . ")]
        public string Name { get; set; }

        public string ProfilePicturePath { get; set; }

        [Required(ErrorMessage = "* Username is Required. . . ")]
        public string Username { get; set; }

        [Required(ErrorMessage = "* Email is Required . . .")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Password is Required . . .")]
        [StringLength(8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "* Confirm Password is Required . . .")]
        [Compare("Password", ErrorMessage = "The Password and Confirmation password do not match.")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        public bool RememberMe { get; set; }
    }
}