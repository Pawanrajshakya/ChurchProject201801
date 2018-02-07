namespace POCO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contributor_Field_Changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contributors", "Phone", c => c.String(maxLength: 12));
            AlterColumn("dbo.Contributors", "Email", c => c.String(maxLength: 55));
            AlterColumn("dbo.Contributors", "Address1", c => c.String(maxLength: 255));
            AlterColumn("dbo.Contributors", "Address2", c => c.String(maxLength: 255));
            AlterColumn("dbo.TransactionTypes", "Description", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TransactionTypes", "Description", c => c.String(maxLength: 255));
            AlterColumn("dbo.Contributors", "Address2", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Contributors", "Address1", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Contributors", "Email", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.Contributors", "Phone", c => c.String(nullable: false, maxLength: 12));
        }
    }
}
