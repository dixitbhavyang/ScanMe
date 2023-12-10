namespace DashmixPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedQRCodeandQRCode_TemplateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QRCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Template_Id = c.Int(nullable: false),
                        QR_Image_Path = c.String(),
                        Creation_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QRCode_Template", t => t.Template_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Template_Id);
            
            CreateTable(
                "dbo.QRCode_Template",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Template_Name = c.String(),
                        Template_Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QRCodes", "User_Id", "dbo.Users");
            DropForeignKey("dbo.QRCodes", "Template_Id", "dbo.QRCode_Template");
            DropIndex("dbo.QRCodes", new[] { "Template_Id" });
            DropIndex("dbo.QRCodes", new[] { "User_Id" });
            DropTable("dbo.QRCode_Template");
            DropTable("dbo.QRCodes");
        }
    }
}
