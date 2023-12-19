using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DashmixPractice.Models
{
    public class Business_Card_Template
    {
        [Key]
        public int Id { get; set; }

        public string Template_Name { get; set; }

        public string Template_Description { get; set; }
    }
}