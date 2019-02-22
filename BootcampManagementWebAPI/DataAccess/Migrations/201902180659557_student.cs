namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Classes_Id", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "Classes_Id" });
            AddColumn("dbo.Students", "Religions_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Villages_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Students", "Classes_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "Classes_Id");
            CreateIndex("dbo.Students", "Religions_Id");
            CreateIndex("dbo.Students", "Villages_Id");
            AddForeignKey("dbo.Students", "Religions_Id", "dbo.Religions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Villages_Id", "dbo.Villages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Classes_Id", "dbo.Classes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Classes_Id", "dbo.Classes");
            DropForeignKey("dbo.Students", "Villages_Id", "dbo.Villages");
            DropForeignKey("dbo.Students", "Religions_Id", "dbo.Religions");
            DropIndex("dbo.Students", new[] { "Villages_Id" });
            DropIndex("dbo.Students", new[] { "Religions_Id" });
            DropIndex("dbo.Students", new[] { "Classes_Id" });
            AlterColumn("dbo.Students", "Classes_Id", c => c.Int());
            AlterColumn("dbo.Students", "Status", c => c.String());
            AlterColumn("dbo.Students", "Password", c => c.String());
            AlterColumn("dbo.Students", "Username", c => c.String());
            AlterColumn("dbo.Students", "Email", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            DropColumn("dbo.Students", "Villages_Id");
            DropColumn("dbo.Students", "Religions_Id");
            CreateIndex("dbo.Students", "Classes_Id");
            AddForeignKey("dbo.Students", "Classes_Id", "dbo.Classes", "Id");
        }
    }
}
