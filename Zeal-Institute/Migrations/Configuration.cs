namespace Zeal_Institute.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Zeal_Institute.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Zeal_Institute.Models.ApplicationDbContext>
    {
        UserManager<ApplicationUser> UserManager = null;
        RoleManager<IdentityRole> RoleManager = null;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Zeal_Institute.Models.ApplicationDbContext context)
        {
            context.Database.ExecuteSqlCommand("DELETE FROM Batches");
            context.Database.ExecuteSqlCommand("DELETE FROM Certificates");
            context.Database.ExecuteSqlCommand("DELETE FROM Courses");
            context.Database.ExecuteSqlCommand("DELETE FROM Discounts");
            context.Database.ExecuteSqlCommand("DELETE FROM Exams");
            context.Database.ExecuteSqlCommand("DELETE FROM Feedbacks");
            context.Database.ExecuteSqlCommand("DELETE FROM Payments");
            context.Database.ExecuteSqlCommand("DELETE FROM Reminders");
            context.Database.ExecuteSqlCommand("DELETE FROM ExamDetails");

            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Batches', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Certificates', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Courses', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Discounts', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Exams', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Feedbacks', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Payments', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Reminders', RESEED, 0)");

            if (RoleManager == null)
            {
                RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            }

            if (UserManager == null)
            {
                UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            }

            var role1 = new IdentityRole { Name = "Admin" };
            var role2 = new IdentityRole { Name = "Manager" };
            var role3 = new IdentityRole { Name = "Faculty" };
            var role4 = new IdentityRole { Name = "Student" };
            RoleManager.Create(role1);
            RoleManager.Create(role2);
            RoleManager.Create(role3);
            RoleManager.Create(role4);

            // create user
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("123456");

            context.Users.AddOrUpdate(new ApplicationUser() { Id = "1", FullName = "Admin", Email = "admin@gmail.com", UserName = "admin@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Admin", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "Admin", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "2", FullName = "Hong Hanh", Email = "honghanh@gmail.com", UserName = "honghanh@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Giao Vu", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "2", RollNumber = "MSG1", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "3", FullName = "Dao Hong Luyen", Email = "hongluyenh@gmail.com", UserName = "hongluyen@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Giao Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "GV1", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "4", FullName = "La Phuong", Email = "laphuong@gmail.com", UserName = "laphuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00631", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "5", FullName = "Van Hien", Email = "vanhien@gmail.com", UserName = "vanhien@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00632", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "6", FullName = "Dinh Nam", Email = "dinhnam@gmail.com", UserName = "dinhnam@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00633", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "7", FullName = "Van Quy", Email = "vanquy@gmail.com", UserName = "vanquy@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00634", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "8", FullName = "Duc Tung", Email = "ductung@gmail.com", UserName = "ductung@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00635", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "9", FullName = "Huy Cuong", Email = "huycuong@gmail.com", UserName = "huycuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00636", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "10", FullName = "Van Loi", Email = "vanloi@gmail.com", UserName = "vanloi@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00637", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "11", FullName = "Le Vinh", Email = "levinh@gmail.com", UserName = "levinh@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00638", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "12", FullName = "Duy Phuong", Email = "duyphuong@gmail.com", UserName = "duyphuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00639", CreatedAt = DateTime.Now });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "13", FullName = "Kim Nghi", Email = "kimnghi@gmail.com", UserName = "kimnghi@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.UserStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00640", CreatedAt = DateTime.Now });

            UserManager.AddToRole("1", "Admin");
            UserManager.AddToRole("2", "Manager");
            UserManager.AddToRole("3", "Faculty");
            UserManager.AddToRole("4", "Student");
            UserManager.AddToRole("5", "Student");
            UserManager.AddToRole("6", "Student");
            UserManager.AddToRole("7", "Student");
            UserManager.AddToRole("8", "Student");
            UserManager.AddToRole("9", "Student");
            UserManager.AddToRole("10", "Student");
            UserManager.AddToRole("11", "Student");
            UserManager.AddToRole("12", "Student");
            UserManager.AddToRole("13", "Student");

            IList<string> listIdStudent = new List<string>();
            listIdStudent.Add("4");
            listIdStudent.Add("5");
            listIdStudent.Add("6");
            listIdStudent.Add("7");
            listIdStudent.Add("8");
            listIdStudent.Add("9");
            listIdStudent.Add("10");
            listIdStudent.Add("11");
            listIdStudent.Add("12");
            listIdStudent.Add("13");

            var listStudent = "";
            foreach (var item in listIdStudent)
            {
                listStudent += item + ",";
            }

            // list course
            IList<Course> courses = new List<Course>();

            courses.Add(new Course() { Id = 1, Name = "ASP .Net Mvc", Code = "ASPNETMCV", Price = 400, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 2, Name = "Swift IOS", Code = "SWIFT", Price = 450, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 3, Name = "Node Js", Code = "NODEJS", Price = 400, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 4, Name = "Java Spring Boot", Code = "JAVAWEB", Price = 450, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 5, Name = "Kotlin Android", Code = "KOTLIN", Price = 450, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            context.Courses.AddRange(courses);



            base.Seed(context);
        }
    }
}
