namespace ExpensesApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "User_User_Id", c => c.Int());
            CreateIndex("dbo.Categories", "User_User_Id");
            AddForeignKey("dbo.Categories", "User_User_Id", "dbo.Users", "iduser");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "User_User_Id", "dbo.Users");
            DropIndex("dbo.Categories", new[] { "User_User_Id" });
            DropColumn("dbo.Categories", "User_User_Id");
        }
    }
}
