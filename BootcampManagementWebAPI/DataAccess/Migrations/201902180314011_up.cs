namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "Employees_Id", c => c.Int());
            CreateIndex("dbo.Classes", "Employees_Id");
            AddForeignKey("dbo.Classes", "Employees_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "Employees_Id", "dbo.Employees");
            DropIndex("dbo.Classes", new[] { "Employees_Id" });
            DropColumn("dbo.Classes", "Employees_Id");
        }
    }
}
