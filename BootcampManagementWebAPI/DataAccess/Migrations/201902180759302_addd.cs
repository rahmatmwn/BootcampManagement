namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Religions_Id", "dbo.Religions");
            DropForeignKey("dbo.Students", "Villages_Id", "dbo.Villages");
            DropIndex("dbo.Students", new[] { "Religions_Id" });
            DropIndex("dbo.Students", new[] { "Villages_Id" });
            AlterColumn("dbo.Students", "DateOfBirth", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Students", "Status", c => c.Boolean());
            AlterColumn("dbo.Students", "Religions_Id", c => c.Int());
            AlterColumn("dbo.Students", "Villages_Id", c => c.Int());
            CreateIndex("dbo.Students", "Religions_Id");
            CreateIndex("dbo.Students", "Villages_Id");
            AddForeignKey("dbo.Students", "Religions_Id", "dbo.Religions", "Id");
            AddForeignKey("dbo.Students", "Villages_Id", "dbo.Villages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Villages_Id", "dbo.Villages");
            DropForeignKey("dbo.Students", "Religions_Id", "dbo.Religions");
            DropIndex("dbo.Students", new[] { "Villages_Id" });
            DropIndex("dbo.Students", new[] { "Religions_Id" });
            AlterColumn("dbo.Students", "Villages_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Religions_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Students", "DateOfBirth", c => c.DateTimeOffset(nullable: false, precision: 7));
            CreateIndex("dbo.Students", "Villages_Id");
            CreateIndex("dbo.Students", "Religions_Id");
            AddForeignKey("dbo.Students", "Villages_Id", "dbo.Villages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Religions_Id", "dbo.Religions", "Id", cascadeDelete: true);
        }
    }
}
