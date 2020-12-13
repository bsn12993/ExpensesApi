namespace ExpensesApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        status = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        updated_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.expenses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        expense_date = c.DateTime(nullable: false),
                        amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        updated_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        last_name = c.String(),
                        password = c.String(),
                        email = c.String(),
                        created_at = c.DateTime(nullable: false),
                        updated_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.incomes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        income_date = c.DateTime(nullable: false),
                        amount = c.Decimal(precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        updated_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.user_has_category",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        updated_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.user_has_category", "UserId", "dbo.users");
            DropForeignKey("dbo.user_has_category", "CategoryId", "dbo.categories");
            DropForeignKey("dbo.incomes", "UserId", "dbo.users");
            DropForeignKey("dbo.expenses", "UserId", "dbo.users");
            DropForeignKey("dbo.expenses", "CategoryId", "dbo.categories");
            DropIndex("dbo.user_has_category", new[] { "CategoryId" });
            DropIndex("dbo.user_has_category", new[] { "UserId" });
            DropIndex("dbo.incomes", new[] { "UserId" });
            DropIndex("dbo.expenses", new[] { "UserId" });
            DropIndex("dbo.expenses", new[] { "CategoryId" });
            DropTable("dbo.user_has_category");
            DropTable("dbo.incomes");
            DropTable("dbo.users");
            DropTable("dbo.expenses");
            DropTable("dbo.categories");
        }
    }
}
