namespace newapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        CatagoryId = c.Int(nullable: false, identity: true),
                        CName = c.String(),
                    })
                .PrimaryKey(t => t.CatagoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        PName = c.String(),
                        CatagoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Catagories", t => t.CatagoryId, cascadeDelete: true)
                .Index(t => t.CatagoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CatagoryId", "dbo.Catagories");
            DropIndex("dbo.Products", new[] { "CatagoryId" });
            DropTable("dbo.Products");
            DropTable("dbo.Catagories");
        }
    }
}
