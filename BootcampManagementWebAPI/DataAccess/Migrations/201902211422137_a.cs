namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Students_Id)
                .Index(t => t.Students_Id);
            
            CreateTable(
                "dbo.HistoryPlacements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                        Description = c.String(),
                        DateStart = c.DateTimeOffset(nullable: false, precision: 7),
                        DateEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Placements_Id = c.Int(),
                        Students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Placements", t => t.Placements_Id)
                .ForeignKey("dbo.Students", t => t.Students_Id)
                .Index(t => t.Placements_Id)
                .Index(t => t.Students_Id);
            
            CreateTable(
                "dbo.Placements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Villages_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Villages", t => t.Villages_Id)
                .Index(t => t.Villages_Id);
            
            CreateTable(
                "dbo.Lockers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Students_Id)
                .Index(t => t.Students_Id);
            
            CreateTable(
                "dbo.StudentAccesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Accesses_Id = c.Int(),
                        Students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accesses", t => t.Accesses_Id)
                .ForeignKey("dbo.Students", t => t.Students_Id)
                .Index(t => t.Accesses_Id)
                .Index(t => t.Students_Id);
            
            CreateTable(
                "dbo.StudentLockers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Lockers_Id = c.Int(),
                        Students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lockers", t => t.Lockers_Id)
                .ForeignKey("dbo.Students", t => t.Students_Id)
                .Index(t => t.Lockers_Id)
                .Index(t => t.Students_Id);
            
            CreateTable(
                "dbo.WorkExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.String(),
                        DateStart = c.DateTimeOffset(nullable: false, precision: 7),
                        DateEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Students_Id)
                .Index(t => t.Students_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperiences", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.StudentLockers", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.StudentLockers", "Lockers_Id", "dbo.Lockers");
            DropForeignKey("dbo.StudentAccesses", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.StudentAccesses", "Accesses_Id", "dbo.Accesses");
            DropForeignKey("dbo.Organizations", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.HistoryPlacements", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.HistoryPlacements", "Placements_Id", "dbo.Placements");
            DropForeignKey("dbo.Placements", "Villages_Id", "dbo.Villages");
            DropForeignKey("dbo.Achievements", "Students_Id", "dbo.Students");
            DropIndex("dbo.WorkExperiences", new[] { "Students_Id" });
            DropIndex("dbo.StudentLockers", new[] { "Students_Id" });
            DropIndex("dbo.StudentLockers", new[] { "Lockers_Id" });
            DropIndex("dbo.StudentAccesses", new[] { "Students_Id" });
            DropIndex("dbo.StudentAccesses", new[] { "Accesses_Id" });
            DropIndex("dbo.Organizations", new[] { "Students_Id" });
            DropIndex("dbo.Placements", new[] { "Villages_Id" });
            DropIndex("dbo.HistoryPlacements", new[] { "Students_Id" });
            DropIndex("dbo.HistoryPlacements", new[] { "Placements_Id" });
            DropIndex("dbo.Achievements", new[] { "Students_Id" });
            DropTable("dbo.WorkExperiences");
            DropTable("dbo.StudentLockers");
            DropTable("dbo.StudentAccesses");
            DropTable("dbo.Organizations");
            DropTable("dbo.Lockers");
            DropTable("dbo.Placements");
            DropTable("dbo.HistoryPlacements");
            DropTable("dbo.Achievements");
            DropTable("dbo.Accesses");
        }
    }
}
