using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DashmixPractice.Models
{
    public class ScanMeDBContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<QRCode> QRCode { get; set; }
        public DbSet<QRCode_Template> QRCode_Template { get; set; }
        public DbSet<Digital_Card_Details> Digital_Card_Details { get; set; }
        public DbSet<Digital_Card> Digital_Card { get; set; }
        public DbSet<Digital_Card_Template> Digital_Card_Template { get; set; }
        public DbSet<Social_Media_Links> Social_Media_Links { get; set; }
        public DbSet<Contact_Information> Contact_Information { get; set; }
    }
}