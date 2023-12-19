namespace DashmixPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTableNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Digital_Card", newName: "Business_Card");
            RenameTable(name: "dbo.Digital_Card_Template", newName: "Business_Card_Template");
            RenameTable(name: "dbo.Digital_Card_Details", newName: "Business_Card_Details");
            RenameTable(name: "dbo.Social_Media_Links", newName: "Social_Connections");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Social_Connections", newName: "Social_Media_Links");
            RenameTable(name: "dbo.Business_Card_Details", newName: "Digital_Card_Details");
            RenameTable(name: "dbo.Business_Card_Template", newName: "Digital_Card_Template");
            RenameTable(name: "dbo.Business_Card", newName: "Digital_Card");
        }
    }
}
