using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DashmixPractice.Models
{
    public class Business_Card_Details
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Digital_Card")]
        public int Digital_Card_Id { get; set; }
        public Business_Card Digital_Card { get; set; }

        public string Field_Name { get; set; }

        public string Field_Value { get; set; }
    }
}