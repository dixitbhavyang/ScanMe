﻿namespace DashmixPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColunmLinktoUsernameinSocial_Connections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Social_Connections", "Username", c => c.String());
            DropColumn("dbo.Social_Connections", "Link");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Social_Connections", "Link", c => c.String());
            DropColumn("dbo.Social_Connections", "Username");
        }
    }
}
