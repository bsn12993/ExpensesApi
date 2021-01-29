namespace ExpensesApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_image_colum : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.user_has_category", new[] { "UserId" });
            DropIndex("dbo.user_has_category", new[] { "CategoryId" });
            AddColumn("dbo.users", "image", c => c.String());
            CreateIndex("dbo.user_has_category", "userId");
            CreateIndex("dbo.user_has_category", "categoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.user_has_category", new[] { "categoryId" });
            DropIndex("dbo.user_has_category", new[] { "userId" });
            DropColumn("dbo.users", "image");
            CreateIndex("dbo.user_has_category", "CategoryId");
            CreateIndex("dbo.user_has_category", "UserId");
        }
    }
}
