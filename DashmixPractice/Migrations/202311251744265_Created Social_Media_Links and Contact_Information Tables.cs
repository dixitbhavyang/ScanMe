namespace DashmixPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedSocial_Media_LinksandContact_InformationTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact_Information",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Email = c.String(),
                        Phone = c.String(maxLength: 10),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Social_Media_Links",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Platform = c.String(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Social_Media_Links", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Contact_Information", "User_Id", "dbo.Users");
            DropIndex("dbo.Social_Media_Links", new[] { "User_Id" });
            DropIndex("dbo.Contact_Information", new[] { "User_Id" });
            DropTable("dbo.Social_Media_Links");
            DropTable("dbo.Contact_Information");
        }
    }
}
