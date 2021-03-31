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

            // date now
            DateTime date = DateTime.Now;

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

            IList<string> listIdStudent2 = new List<string>();
            listIdStudent2.Add("9");
            listIdStudent2.Add("10");
            listIdStudent2.Add("11");
            listIdStudent2.Add("12");
            listIdStudent2.Add("13");

            var listStudent = "";
            var listStudent2 = "";
            foreach (var item in listIdStudent)
            {
                listStudent += item + ",";
            }

            foreach (var item in listIdStudent2)
            {
                listStudent2 += item + ",";
            }

            // list course
            IList<Course> courses = new List<Course>();

            courses.Add(new Course() { Id = 1, Name = "ASP .Net Mvc", Code = "ASPNETMCV", Price = 400, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 2, Name = "Swift IOS", Code = "SWIFT", Price = 450, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 3, Name = "Node Js", Code = "NODEJS", Price = 400, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 4, Name = "Java Spring Boot", Code = "JAVAWEB", Price = 450, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 5, Name = "Kotlin Android", Code = "KOTLIN", Price = 450, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 6, Name = "HTML&CSS JS", Code = "HTMLCSS", Price = 250, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            courses.Add(new Course() { Id = 7, Name = "PHP Laravel", Code = "PHPL", Price = 350, Description = "hello", Status = Course.CourseStatus.ACTIVE });
            context.Courses.AddRange(courses);

            // list batch
            IList<Batch> batches = new List<Batch>();

            batches.Add(new Batch() { Id = 1, Name = "Web Frontend 01", Code = "FE001", CourseId = 5, ListStudent = listStudent, Description = null, DateStart = date.AddDays(-30), DateEnd = date.AddDays(-25), Status = Batch.BatchStatus.ACTIVE }); ;
            batches.Add(new Batch() { Id = 2, Name = "Web Frontend 02", Code = "FE002", CourseId = 5, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(-25), DateEnd = date.AddDays(-20), Status = Batch.BatchStatus.ACTIVE }); ;
            batches.Add(new Batch() { Id = 3, Name = ".Net Backend 01", Code = "BE001", CourseId = 1, ListStudent = listStudent, Description = null, DateStart = date.AddDays(-25), DateEnd = date.AddDays(-20), Status = Batch.BatchStatus.ACTIVE }); ;
            batches.Add(new Batch() { Id = 4, Name = ".Net Backend 02", Code = "BE002", CourseId = 1, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(-20), DateEnd = date.AddDays(-15), Status = Batch.BatchStatus.ACTIVE }); ;
            batches.Add(new Batch() { Id = 5, Name = "Java Spring Boot 01", Code = "BE003", CourseId = 4, ListStudent = listStudent, Description = null, DateStart = date.AddDays(-20), DateEnd = date.AddDays(-15), Status = Batch.BatchStatus.ACTIVE }); ;
            batches.Add(new Batch() { Id = 6, Name = "Java Spring Boot 02", Code = "BE004", CourseId = 4, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(-15), DateEnd = date.AddDays(-10), Status = Batch.BatchStatus.ACTIVE }); ;
            batches.Add(new Batch() { Id = 7, Name = "Node JS Backend 01", Code = "BE005", CourseId = 3, ListStudent = listStudent, Description = null, DateStart = date.AddDays(-15), DateEnd = date.AddDays(-10), Status = Batch.BatchStatus.ACTIVE }); ;
            batches.Add(new Batch() { Id = 8, Name = "Node JS Backend 02", Code = "BE006", CourseId = 3, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(-10), DateEnd = date.AddDays(-5), Status = Batch.BatchStatus.ACTIVE }); ;
            batches.Add(new Batch() { Id = 9, Name = "PHP Laravel 01", Code = "BE007", CourseId = 7, ListStudent = listStudent, Description = null, DateStart = date.AddDays(-10), DateEnd = date.AddDays(-5), Status = Batch.BatchStatus.ACTIVE }); ;
            batches.Add(new Batch() { Id = 10, Name = "PHP Laravel 02", Code = "BE008", CourseId = 7, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(-5), DateEnd = date.AddDays(0), Status = Batch.BatchStatus.ACTIVE }); ;
            batches.Add(new Batch() { Id = 11, Name = "Mobile Dev 01", Code = "MB001", CourseId = 2, ListStudent = listStudent, Description = null, DateStart = date.AddDays(-5), DateEnd = date.AddDays(0), Status = Batch.BatchStatus.ACTIVE }); ;
            batches.Add(new Batch() { Id = 12, Name = "Mobile Dev 02", Code = "MB002", CourseId = 2, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(0), DateEnd = date.AddDays(5), Status = Batch.BatchStatus.ACTIVE }); ;
            batches.Add(new Batch() { Id = 13, Name = "Mobile Dev 03", Code = "MB003", CourseId = 5, ListStudent = listStudent, Description = null, DateStart = date.AddDays(0), DateEnd = date.AddDays(5), Status = Batch.BatchStatus.ACTIVE }); ;
            batches.Add(new Batch() { Id = 14, Name = "Mobile Dev 04", Code = "MB004", CourseId = 5, ListStudent = listStudent2, Description = null, DateStart = date.AddDays(5), DateEnd = date.AddDays(10), Status = Batch.BatchStatus.ACTIVE }); ;
            context.Batches.AddRange(batches);

            // list exam
            IList<Exam> exams = new List<Exam>();
            exams.Add(new Exam() { Id = 1, BatchId = 1, DateExam = date.AddDays(-25), StartTime = new TimeSpan(9,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 2, BatchId = 2, DateExam = date.AddDays(-20), StartTime = new TimeSpan(10,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 3, BatchId = 3, DateExam = date.AddDays(-20), StartTime = new TimeSpan(17,30,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 4, BatchId = 4, DateExam = date.AddDays(-15), StartTime = new TimeSpan(13,30,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 5, BatchId = 5, DateExam = date.AddDays(-15), StartTime = new TimeSpan(8,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 6, BatchId = 6, DateExam = date.AddDays(-10), StartTime = new TimeSpan(17,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 7, BatchId = 7, DateExam = date.AddDays(-10), StartTime = new TimeSpan(15,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 8, BatchId = 8, DateExam = date.AddDays(-5), StartTime = new TimeSpan(9,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 9, BatchId = 9, DateExam = date.AddDays(-5), StartTime = new TimeSpan(20,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 10, BatchId = 10, DateExam = date.AddDays(0), StartTime = new TimeSpan(10,0,0), Status = Exam.ExamStatus.DONE });
            exams.Add(new Exam() { Id = 11, BatchId = 11, DateExam = date.AddDays(0), StartTime = new TimeSpan(9,0,0), Status = Exam.ExamStatus.DONE });
            context.Exams.AddRange(exams);

            // list exam detail
            IList<ExamDetail> examDetails = new List<ExamDetail>();

            // exam id = 1
            examDetails.Add(new ExamDetail() { ExamId = 1, ApplicationUserId = "4", Mark = 40, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 1, ApplicationUserId = "5", Mark = 35, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 1, ApplicationUserId = "6", Mark = 90, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 1, ApplicationUserId = "7", Mark = 85, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 1, ApplicationUserId = "8", Mark = 70, Note = null });

            // exam id = 2
            examDetails.Add(new ExamDetail() { ExamId = 2, ApplicationUserId = "9", Mark = 50, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 2, ApplicationUserId = "10", Mark = 55, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 2, ApplicationUserId = "11", Mark = 70, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 2, ApplicationUserId = "12", Mark = 85, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 2, ApplicationUserId = "13", Mark = 60, Note = null });

            // exam id = 3
            examDetails.Add(new ExamDetail() { ExamId = 3, ApplicationUserId = "4", Mark = 20, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 3, ApplicationUserId = "5", Mark = 35, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 3, ApplicationUserId = "6", Mark = 70, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 3, ApplicationUserId = "7", Mark = 85, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 3, ApplicationUserId = "8", Mark = 80, Note = null });

            // exam id = 4
            examDetails.Add(new ExamDetail() { ExamId = 4, ApplicationUserId = "9", Mark = 60, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 4, ApplicationUserId = "10", Mark = 65, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 4, ApplicationUserId = "11", Mark = 40, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 4, ApplicationUserId = "12", Mark = 75, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 4, ApplicationUserId = "13", Mark = 90, Note = null });

            // exam id = 5
            examDetails.Add(new ExamDetail() { ExamId = 5, ApplicationUserId = "4", Mark = 40, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 5, ApplicationUserId = "5", Mark = 35, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 5, ApplicationUserId = "6", Mark = 90, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 5, ApplicationUserId = "7", Mark = 85, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 5, ApplicationUserId = "8", Mark = 70, Note = null });

            // exam id = 6
            examDetails.Add(new ExamDetail() { ExamId = 6, ApplicationUserId = "9", Mark = 50, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 6, ApplicationUserId = "10", Mark = 55, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 6, ApplicationUserId = "11", Mark = 70, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 6, ApplicationUserId = "12", Mark = 85, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 6, ApplicationUserId = "13", Mark = 60, Note = null });

            // exam id = 7
            examDetails.Add(new ExamDetail() { ExamId = 7, ApplicationUserId = "4", Mark = 65, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 7, ApplicationUserId = "5", Mark = 70, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 7, ApplicationUserId = "6", Mark = 50, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 7, ApplicationUserId = "7", Mark = 95, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 7, ApplicationUserId = "8", Mark = 100, Note = null });

            // exam id = 8
            examDetails.Add(new ExamDetail() { ExamId = 8, ApplicationUserId = "9", Mark = 50, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 8, ApplicationUserId = "10", Mark = 75, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 8, ApplicationUserId = "11", Mark = 70, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 8, ApplicationUserId = "12", Mark = 25, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 8, ApplicationUserId = "13", Mark = 60, Note = null });

            // exam id = 9
            examDetails.Add(new ExamDetail() { ExamId = 9, ApplicationUserId = "4", Mark = 35, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 9, ApplicationUserId = "5", Mark = 80, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 9, ApplicationUserId = "6", Mark = 55, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 9, ApplicationUserId = "7", Mark = 95, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 9, ApplicationUserId = "8", Mark = 65, Note = null });

            // exam id = 10
            examDetails.Add(new ExamDetail() { ExamId = 10, ApplicationUserId = "9", Mark = 55, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 10, ApplicationUserId = "10", Mark = 45, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 10, ApplicationUserId = "11", Mark = 75, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 10, ApplicationUserId = "12", Mark = 40, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 10, ApplicationUserId = "13", Mark = 60, Note = null });

            // exam id = 11
            examDetails.Add(new ExamDetail() { ExamId = 11, ApplicationUserId = "4", Mark = 45, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 11, ApplicationUserId = "5", Mark = 45, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 11, ApplicationUserId = "6", Mark = 70, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 11, ApplicationUserId = "7", Mark = 90, Note = null });
            examDetails.Add(new ExamDetail() { ExamId = 11, ApplicationUserId = "8", Mark = 80, Note = null });
            context.ExamDetails.AddRange(examDetails);

            base.Seed(context);
        }
    }
}
