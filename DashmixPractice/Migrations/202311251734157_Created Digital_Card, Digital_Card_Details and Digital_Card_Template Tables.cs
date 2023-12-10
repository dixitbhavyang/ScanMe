namespace DashmixPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDigital_CardDigital_Card_DetailsandDigital_Card_TemplateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Digital_Card",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Template_Id = c.Int(nullable: false),
                        Card_Name = c.String(),
                        Creation_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Digital_Card_Template", t => t.Template_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Template_Id);
            
            CreateTable(
                "dbo.Digital_Card_Template",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Template_Name = c.String(),
                        Template_Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Digital_Card_Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Digital_Card_Id = c.Int(nullable: false),
                        Field_Name = c.String(),
                        Field_Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Digital_Card", t => t.Digital_Card_Id, cascadeDelete: true)
                .Index(t => t.Digital_Card_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Digital_Card_Details", "Digital_Card_Id", "dbo.Digital_Card");
            DropForeignKey("dbo.Digital_Card", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Digital_Card", "Template_Id", "dbo.Digital_Card_Template");
            DropIndex("dbo.Digital_Card_Details", new[] { "Digital_Card_Id" });
            DropIndex("dbo.Digital_Card", new[] { "Template_Id" });
            DropIndex("dbo.Digital_Card", new[] { "User_Id" });
            DropTable("dbo.Digital_Card_Details");
            DropTable("dbo.Digital_Card_Template");
            DropTable("dbo.Digital_Card");
        }
    }
}
