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
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Code = c.String(nullable: false, maxLength: 255),
                        Price = c.Double(nullable: false),
                        Description = c.String(unicode: false, storeType: "text"),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false, storeType: "date"),
                        ReceivedDate = c.DateTime(nullable: false, storeType: "date"),
                        Note = c.String(maxLength: 255),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.CourseId);
            
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
                        CourseId = c.Int(nullable: false),
                        CoursePrice = c.Double(nullable: false),
                        DiscountValue = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        DateExam = c.DateTime(nullable: false, storeType: "date"),
                        StartTime = c.Time(nullable: false, precision: 7),
                        Mark = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.CourseId);
            
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
                        CourseId = c.Int(nullable: false),
                        AmountPayable = c.Double(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        PayDate = c.DateTime(nullable: false, storeType: "date"),
                        Note = c.String(unicode: false, storeType: "text"),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.CourseId);
            
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
            DropForeignKey("dbo.Certificates", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reminders", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Reminders", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Payments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Payments", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Exams", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Discounts", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Discounts", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Certificates", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Batches", "CourseId", "dbo.Courses");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Reminders", new[] { "CourseId" });
            DropIndex("dbo.Reminders", new[] { "ApplicationUserId" });
            DropIndex("dbo.Payments", new[] { "CourseId" });
            DropIndex("dbo.Payments", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropIndex("dbo.Exams", new[] { "ApplicationUserId" });
            DropIndex("dbo.Discounts", new[] { "CourseId" });
            DropIndex("dbo.Discounts", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Certificates", new[] { "CourseId" });
            DropIndex("dbo.Certificates", new[] { "ApplicationUserId" });
            DropIndex("dbo.Batches", new[] { "CourseId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Reminders");
            DropTable("dbo.Payments");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Exams");
            DropTable("dbo.Discounts");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Certificates");
            DropTable("dbo.Courses");
            DropTable("dbo.Batches");
        }
    }
}
