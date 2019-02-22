namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addemp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "Employees_Id", c => c.Int());
            CreateIndex("dbo.Lessons", "Employees_Id");
            AddForeignKey("dbo.Lessons", "Employees_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "Employees_Id", "dbo.Employees");
            DropIndex("dbo.Lessons", new[] { "Employees_Id" });
            DropColumn("dbo.Lessons", "Employees_Id");
        }
    }
}
