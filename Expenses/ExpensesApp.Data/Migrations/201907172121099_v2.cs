namespace ExpensesApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        idcategory = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idcategory);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        idexpense = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idexpense)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        iduser = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        lastName = c.String(),
                        password = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.iduser);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        idincome = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        amount = c.Decimal(precision: 18, scale: 2),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idincome)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCategory", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserCategory", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Incomes", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Expenses", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Expenses", "Category_Id", "dbo.Categories");
            DropIndex("dbo.UserCategory", new[] { "Category_Id" });
            DropIndex("dbo.UserCategory", new[] { "User_Id" });
            DropIndex("dbo.Incomes", new[] { "User_Id" });
            DropIndex("dbo.Expenses", new[] { "User_Id" });
            DropIndex("dbo.Expenses", new[] { "Category_Id" });
            DropTable("dbo.UserCategory");
            DropTable("dbo.Incomes");
            DropTable("dbo.Users");
            DropTable("dbo.Expenses");
            DropTable("dbo.Categories");
        }
    }
}
