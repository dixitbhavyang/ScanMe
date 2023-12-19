using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DashmixPractice.Models
{
    public class Business_Card
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public User User { get; set; }

        [ForeignKey("Digital_Card_Template")]
        public int Template_Id { get; set; }
        public Business_Card_Template Digital_Card_Template { get; set; }

        public string Card_Name { get; set; }

        public DateTime Creation_Date { get; set; }
    }
}