namespace DashmixPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAnnotationsforProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
    }
}
