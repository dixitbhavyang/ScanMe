using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DashmixPractice.Models
{
    public class QRCode
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public User User { get; set; }

        [ForeignKey("QRCode_Template")]
        public int Template_Id { get; set; }
        public QRCode_Template QRCode_Template { get; set; }

        public string QR_Image_Path { get; set; }

        public DateTime Creation_Date { get; set; }
    }
}