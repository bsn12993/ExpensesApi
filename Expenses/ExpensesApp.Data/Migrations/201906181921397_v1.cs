namespace ExpensesApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "User_User_Id", "dbo.Users");
            DropIndex("dbo.Categories", new[] { "User_User_Id" });
            CreateTable(
                "dbo.UserCategory",
                c => new
                    {
                        idusercategory = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idusercategory)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Category_Id);
            
            DropColumn("dbo.Categories", "User_User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "User_User_Id", c => c.Int());
            DropForeignKey("dbo.UserCategory", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserCategory", "Category_Id", "dbo.Categories");
            DropIndex("dbo.UserCategory", new[] { "Category_Id" });
            DropIndex("dbo.UserCategory", new[] { "User_Id" });
            DropTable("dbo.UserCategory");
            CreateIndex("dbo.Categories", "User_User_Id");
            AddForeignKey("dbo.Categories", "User_User_Id", "dbo.Users", "iduser");
        }
    }
}
