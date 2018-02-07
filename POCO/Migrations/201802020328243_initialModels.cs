namespace POCO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Churches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address1 = c.String(nullable: false, maxLength: 255),
                        Address2 = c.String(nullable: false, maxLength: 255),
                        State = c.String(nullable: false, maxLength: 2),
                        ZipCode = c.String(nullable: false, maxLength: 5),
                        Description = c.String(nullable: false, maxLength: 255),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContributorGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contributors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(nullable: false, maxLength: 12),
                        Email = c.String(nullable: false, maxLength: 55),
                        Address1 = c.String(nullable: false, maxLength: 255),
                        Address2 = c.String(nullable: false, maxLength: 255),
                        State = c.String(nullable: false, maxLength: 2),
                        ZipCode = c.String(nullable: false, maxLength: 5),
                        IsActive = c.Boolean(nullable: false),
                        Group = c.Int(nullable: false),
                        Key = c.String(maxLength: 255),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContributorGroups", t => t.Group, cascadeDelete: true)
                .ForeignKey("dbo.ContributorKeys", t => t.Key)
                .Index(t => t.Group)
                .Index(t => t.Key);
            
            CreateTable(
                "dbo.ContributorKeys",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description1 = c.String(maxLength: 255),
                        Description2 = c.String(maxLength: 255),
                        Type = c.String(nullable: false, maxLength: 1),
                        ContributorId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contributors", t => t.ContributorId, cascadeDelete: true)
                .ForeignKey("dbo.TransactionTypes", t => t.Type, cascadeDelete: true)
                .Index(t => t.Type)
                .Index(t => t.ContributorId);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        Type = c.String(nullable: false, maxLength: 1),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Type);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "Type", "dbo.TransactionTypes");
            DropForeignKey("dbo.Donations", "ContributorId", "dbo.Contributors");
            DropForeignKey("dbo.Contributors", "Key", "dbo.ContributorKeys");
            DropForeignKey("dbo.Contributors", "Group", "dbo.ContributorGroups");
            DropIndex("dbo.Donations", new[] { "ContributorId" });
            DropIndex("dbo.Donations", new[] { "Type" });
            DropIndex("dbo.Contributors", new[] { "Key" });
            DropIndex("dbo.Contributors", new[] { "Group" });
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Donations");
            DropTable("dbo.ContributorKeys");
            DropTable("dbo.Contributors");
            DropTable("dbo.ContributorGroups");
            DropTable("dbo.Churches");
        }
    }
}
