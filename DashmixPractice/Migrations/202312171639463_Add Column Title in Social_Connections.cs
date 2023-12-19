namespace DashmixPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnTitleinSocial_Connections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Social_Connections", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Social_Connections", "Title");
        }
    }
}
