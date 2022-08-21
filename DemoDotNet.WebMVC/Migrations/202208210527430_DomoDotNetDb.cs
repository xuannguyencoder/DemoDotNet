namespace DemoDotNet.WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DomoDotNetDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(maxLength: 500),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        CategoryID = c.Int(nullable: false),
                        Image = c.String(maxLength: 500),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 500),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategory", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CategoryID", "dbo.ProductCategory");
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropTable("dbo.Product");
            DropTable("dbo.ProductCategory");
        }
    }
}
