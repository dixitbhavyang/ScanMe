using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DashmixPractice.Models
{
    public class Contact_Information
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public User User { get; set; }

        public string Email { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string Address { get; set; }
    }
}