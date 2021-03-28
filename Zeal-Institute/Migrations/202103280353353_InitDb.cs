namespace Zeal_Institute.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Code = c.String(nullable: false, maxLength: 255),
                        CourseId = c.Int(nullable: false),
                        ListStudent = c.String(),
                        Description = c.String(unicode: false, storeType: "text"),
                        DateStart = c.DateTime(nullable: false, storeType: "date"),
                        DateEnd = c.DateTime(nullable: false, storeType: "date"),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        BatchId = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false, storeType: "date"),
                        ReceivedDate = c.DateTime(nullable: false, storeType: "date"),
                        Note = c.String(maxLength: 255),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.BatchId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false, maxLength: 255),
                        RollNumber = c.String(nullable: false, maxLength: 255),
                        Address = c.String(maxLength: 255),
                        Avatar = c.String(maxLength: 255),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false, storeType: "date"),
                        Status = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        BatchId = c.Int(nullable: false),
                        CoursePrice = c.Double(nullable: false),
                        DiscountValue = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.BatchId);
            
            CreateTable(
                "dbo.ExamDetails",
                c => new
                    {
                        ExamId = c.Int(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        Mark = c.Single(nullable: false),
                        Note = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => new { t.ExamId, t.ApplicationUserId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.ExamId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchId = c.Int(nullable: false),
                        DateExam = c.DateTime(nullable: false, storeType: "date"),
                        StartTime = c.Time(nullable: false, precision: 7),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .Index(t => t.BatchId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        BatchId = c.Int(nullable: false),
                        AmountPayable = c.Double(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        PayDate = c.DateTime(nullable: false, storeType: "date"),
                        Note = c.String(unicode: false, storeType: "text"),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.BatchId);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        BatchId = c.Int(nullable: false),
                        Note = c.String(maxLength: 255),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.BatchId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Code = c.String(nullable: false, maxLength: 255),
                        Price = c.Double(nullable: false),
                        Thumbnail = c.String(unicode: false, storeType: "text"),
                        Description = c.String(unicode: false, storeType: "text"),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FbEmail = c.String(maxLength: 255),
                        FbPhone = c.String(maxLength: 255),
                        FbName = c.String(maxLength: 255),
                        Type = c.Int(nullable: false),
                        Content = c.String(maxLength: 255),
                        Note = c.String(maxLength: 255),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Batches", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Certificates", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reminders", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Reminders", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Payments", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Payments", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ExamDetails", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Exams", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.ExamDetails", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Discounts", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Discounts", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Certificates", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Reminders", new[] { "BatchId" });
            DropIndex("dbo.Reminders", new[] { "ApplicationUserId" });
            DropIndex("dbo.Payments", new[] { "BatchId" });
            DropIndex("dbo.Payments", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Exams", new[] { "BatchId" });
            DropIndex("dbo.ExamDetails", new[] { "ApplicationUserId" });
            DropIndex("dbo.ExamDetails", new[] { "ExamId" });
            DropIndex("dbo.Discounts", new[] { "BatchId" });
            DropIndex("dbo.Discounts", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Certificates", new[] { "BatchId" });
            DropIndex("dbo.Certificates", new[] { "ApplicationUserId" });
            DropIndex("dbo.Batches", new[] { "CourseId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Courses");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Reminders");
            DropTable("dbo.Payments");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Exams");
            DropTable("dbo.ExamDetails");
            DropTable("dbo.Discounts");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Certificates");
            DropTable("dbo.Batches");
        }
    }
}
