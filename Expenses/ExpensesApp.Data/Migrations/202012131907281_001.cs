namespace ExpensesApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.categories", "updated_at", c => c.DateTime());
            AlterColumn("dbo.categories", "deleted_at", c => c.DateTime());
            AlterColumn("dbo.expenses", "updated_at", c => c.DateTime());
            AlterColumn("dbo.expenses", "deleted_at", c => c.DateTime());
            AlterColumn("dbo.users", "updated_at", c => c.DateTime());
            AlterColumn("dbo.users", "deleted_at", c => c.DateTime());
            AlterColumn("dbo.incomes", "updated_at", c => c.DateTime());
            AlterColumn("dbo.incomes", "deleted_at", c => c.DateTime());
            AlterColumn("dbo.user_has_category", "updated_at", c => c.DateTime());
            AlterColumn("dbo.user_has_category", "deleted_at", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.user_has_category", "deleted_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.user_has_category", "updated_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.incomes", "deleted_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.incomes", "updated_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.users", "deleted_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.users", "updated_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.expenses", "deleted_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.expenses", "updated_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.categories", "deleted_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.categories", "updated_at", c => c.DateTime(nullable: false));
        }
    }
}
