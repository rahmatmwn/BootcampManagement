namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailyScores", "lessons_Id", c => c.Int());
            AddColumn("dbo.DailyScores", "students_Id", c => c.Int());
            AddColumn("dbo.HistoryEducations", "Students_Id", c => c.Int());
            AddColumn("dbo.WeeklyScores", "Students_Id", c => c.Int());
            CreateIndex("dbo.DailyScores", "lessons_Id");
            CreateIndex("dbo.DailyScores", "students_Id");
            CreateIndex("dbo.HistoryEducations", "Students_Id");
            CreateIndex("dbo.WeeklyScores", "Students_Id");
            AddForeignKey("dbo.DailyScores", "lessons_Id", "dbo.Lessons", "Id");
            AddForeignKey("dbo.DailyScores", "students_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.HistoryEducations", "Students_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.WeeklyScores", "Students_Id", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeeklyScores", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.HistoryEducations", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.DailyScores", "students_Id", "dbo.Students");
            DropForeignKey("dbo.DailyScores", "lessons_Id", "dbo.Lessons");
            DropIndex("dbo.WeeklyScores", new[] { "Students_Id" });
            DropIndex("dbo.HistoryEducations", new[] { "Students_Id" });
            DropIndex("dbo.DailyScores", new[] { "students_Id" });
            DropIndex("dbo.DailyScores", new[] { "lessons_Id" });
            DropColumn("dbo.WeeklyScores", "Students_Id");
            DropColumn("dbo.HistoryEducations", "Students_Id");
            DropColumn("dbo.DailyScores", "students_Id");
            DropColumn("dbo.DailyScores", "lessons_Id");
        }
    }
}
