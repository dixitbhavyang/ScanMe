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
        public DbSet<Business_Card_Details> Business_Card_Details { get; set; }
        public DbSet<Business_Card> Business_Card { get; set; }
        public DbSet<Business_Card_Template> Business_Card_Template { get; set; }
        public DbSet<Social_Connections> Social_Connections { get; set; }
        public DbSet<Contact_Information> Contact_Information { get; set; }
    }
}